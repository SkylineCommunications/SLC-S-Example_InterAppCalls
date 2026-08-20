// Ignore Spelling: App dma

namespace Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallBulk;
	using Skyline.DataMiner.Core.InterAppCalls.Common.Shared;
	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.Net.Messages;

	/// <summary>
	/// Provides a typed wrapper for sending inter-application messages to an element
	/// running the example connector.
	/// </summary>
	public class ExampleInterAppCalls : IExampleInterAppCalls
	{
		private TimeSpan defaultTimeout = TimeSpan.FromSeconds(60);

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ExampleInterAppCalls"/> class
		/// by resolving an element by name.
		/// </summary>
		/// <param name="connection">The connection interface.</param>
		/// <param name="elementName">The name of the target element in DataMiner.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="connection"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="elementName"/> is empty, the element cannot be found, or the element does not use the example connector.</exception>
		public ExampleInterAppCalls(IConnection connection, string elementName)
		{
			if (String.IsNullOrEmpty(elementName))
			{
				throw new ArgumentException("Please provide a valid Element name.", nameof(elementName));
			}

			SLNetConnection = connection ?? throw new ArgumentNullException(nameof(connection));

			ElementInfoEventMessage elementInfo;
			try
			{
				elementInfo = (ElementInfoEventMessage)SLNetConnection.HandleSingleResponseMessage(new GetElementByNameMessage
				{
					ElementName = elementName,
				});
			}
			catch (Exception)
			{
				throw new ArgumentException($"The element does not exists with name '{elementName}'", nameof(elementName));
			}

			if (elementInfo.Protocol != Constants.ProtocolName)
			{
				throw new ArgumentException($"The element is not running protocol '{Constants.ProtocolName}'", nameof(elementName));
			}

			AgentId = elementInfo.DataMinerID;
			ElementId = elementInfo.ElementID;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ExampleInterAppCalls"/> class
		/// by identifying the target element by DataMiner Agent and element identifiers.
		/// </summary>
		/// <param name="connection">The connection interface.</param>
		/// <param name="dmaId">The identifier of the DataMiner Agent hosting the element.</param>
		/// <param name="elementId">The identifier of the element in DataMiner.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="connection"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">Thrown when either identifier is zero, the element cannot be found, or the element does not use the example connector.</exception>
		public ExampleInterAppCalls(IConnection connection, int dmaId, int elementId)
		{
			if (dmaId == default)
			{
				throw new ArgumentException("Please provide a valid DMA ID.", nameof(dmaId));
			}

			if (elementId == default)
			{
				throw new ArgumentException("Please provide a valid Element ID.", nameof(elementId));
			}

			SLNetConnection = connection ?? throw new ArgumentNullException(nameof(connection));
			AgentId = dmaId;
			ElementId = elementId;

			ElementInfoEventMessage elementInfo;
			try
			{
				elementInfo = (ElementInfoEventMessage)SLNetConnection.HandleSingleResponseMessage(new GetElementByIDMessage
				{
					DataMinerID = dmaId,
					ElementID = elementId,
				});
			}
			catch
			{
				throw new ArgumentException($"The element does not exists with id '{dmaId}/{elementId}'", nameof(elementId));
			}

			if (elementInfo.Protocol != Constants.ProtocolName)
			{
				throw new ArgumentException($"The element is not running protocol '{Constants.ProtocolName}'", nameof(elementId));
			}
		}
		#endregion

		/// <summary>
		/// Gets or sets the SLNet connection used to send inter-application calls.
		/// </summary>
		public IConnection SLNetConnection { get; set; }

		/// <summary>
		/// Gets the identifier of the DataMiner Agent hosting the target element.
		/// </summary>
		public int AgentId { get; }

		/// <summary>
		/// Gets the identifier of the target element in DataMiner.
		/// </summary>
		public int ElementId { get; }

		/// <summary>
		/// Sends the specified messages to the target element without waiting for responses.
		/// </summary>
		/// <param name="messages">The messages to send.</param>
		public void SendMessageNoResponse(params IExampleRequest[] messages)
		{
			IInterAppCall myCommands = InterAppCallFactory.CreateNew();

			myCommands.ReturnAddress = new ReturnAddress(AgentId, ElementId, Constants.InterAppResponsePID);
			myCommands.Messages.AddMessage(messages.Select(Messages.Types.ToMessage).ToArray());

			myCommands.Send(SLNetConnection, AgentId, ElementId, Constants.InterAppReceiverPID, Messages.Types.KnownTypes);
		}

		/// <summary>
		/// Sends the specified messages to the target element and waits for the responses.
		/// </summary>
		/// <param name="messages">The messages to send.</param>
		/// <param name="timeout">The maximum time to wait for responses. The implementation default is used when this is <see cref="TimeSpan.Zero"/>.</param>
		/// <returns>The responses returned by the target element.</returns>
		public IEnumerable<IExampleResponse> SendMessages(IExampleRequest[] messages, TimeSpan timeout = default)
		{
			var interAppCallTimeout = timeout;
			if (timeout == default)
			{
				interAppCallTimeout = defaultTimeout;
			}

			IInterAppCall myCommands = InterAppCallFactory.CreateNew();

			myCommands.ReturnAddress = new ReturnAddress(AgentId, ElementId, Constants.InterAppResponsePID);
			myCommands.Messages.AddMessage(messages.Select(Messages.Types.ToMessage).ToArray());

			var internalResults = myCommands.Send(SLNetConnection, AgentId, ElementId, Constants.InterAppReceiverPID, interAppCallTimeout, Messages.Types.KnownTypes);
			return internalResults.Select(result => Messages.Types.FromMessage(result));
		}

		/// <summary>
		/// Sends a message to the target element and waits for its response.
		/// </summary>
		/// <param name="message">The message to send.</param>
		/// <param name="timeout">The maximum time to wait for a response. The implementation default is used when this is <see cref="TimeSpan.Zero"/>.</param>
		/// <returns>The response returned by the target element.</returns>
		public IExampleResponse SendSingleResponseMessage(IExampleRequest message, TimeSpan timeout = default)
		{
			var interAppCallTimeout = timeout;
			if (timeout == default)
			{
				interAppCallTimeout = defaultTimeout;
			}

			IInterAppCall myCommand = InterAppCallFactory.CreateNew();

			myCommand.ReturnAddress = new ReturnAddress(AgentId, ElementId, Constants.InterAppResponsePID);
			myCommand.Messages.AddMessage(Messages.Types.ToMessage(message));

			var internalResult = myCommand.Send(SLNetConnection, AgentId, ElementId, Constants.InterAppReceiverPID, interAppCallTimeout, Messages.Types.KnownTypes).First();
			return Messages.Types.FromMessage(internalResult);
		}

		/// <summary>
		/// Sends a message to the target element and returns its response as the requested type.
		/// </summary>
		/// <typeparam name="T">The type of the expected response, which must implement <see cref="IExampleResponse"/>.</typeparam>
		/// <param name="message">The message to send.</param>
		/// <param name="timeout">The maximum time to wait for a response. The implementation default is used when this is <see cref="TimeSpan.Zero"/>.</param>
		/// <returns>The response returned by the target element.</returns>
		public T SendSingleResponseMessage<T>(IExampleRequest message, TimeSpan timeout = default)
			where T : IExampleResponse
		{
			var result = SendSingleResponseMessage(message, timeout);
			return (T)result;
		}
	}
}
