// Ignore Spelling: App dma

namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.InterAppMessages;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallBulk;
	using Skyline.DataMiner.Core.InterAppCalls.Common.Shared;
	using Skyline.DataMiner.Net;
	using Skyline.DataMiner.Net.Messages;

	/// <summary>
	/// Represents a DataMiner element using the 'Skyline Example InterAppCalls' connector, that can handle InterApp Messages.
	/// </summary>
	public class ExampleInterAppCalls : IExampleInterAppCalls
	{
		private TimeSpan defaultTimeout = TimeSpan.FromSeconds(60);

		#region Constructors

		/// <summary>
		/// Initialize a new instance of the <see cref="ExampleInterAppCalls"/> class.
		/// </summary>
		/// <param name="connection">The connection interface.</param>
		/// <param name="elementName">The name of the element in DataMiner.</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
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
		/// Initialize a new instance of the <see cref="ExampleInterAppCalls"/> class.
		/// </summary>
		/// <param name="connection">The connection interface.</param>
		/// <param name="dmaId">The id of the DataMiner that is hosting the element.</param>
		/// <param name="elementId">The id of the element in DataMiner.</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
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

		/// <inheritdoc/>
		public IConnection SLNetConnection { get; set; }

		/// <inheritdoc/>
		public int AgentId { get; }

		/// <inheritdoc/>
		public int ElementId { get; }

		/// <inheritdoc/>
		public void SendMessageNoResponse(params IExampleRequest[] messages)
		{
			IInterAppCall myCommands = InterAppCallFactory.CreateNew();

			myCommands.ReturnAddress = new ReturnAddress(AgentId, ElementId, Constants.InterAppResponsePID);
			myCommands.Messages.AddMessage(messages.Select(Messages.Types.ToMessage).ToArray());

			myCommands.Send(SLNetConnection, AgentId, ElementId, Constants.InterAppReceiverPID, Messages.Types.KnownTypes);
		}

		/// <inheritdoc/>
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

		/// <inheritdoc/>
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

		/// <inheritdoc/>
		public T SendSingleResponseMessage<T>(IExampleRequest message, TimeSpan timeout = default)
			where T : IExampleResponse
		{
			var result = SendSingleResponseMessage(message, timeout);
			return (T)result;
		}
	}
}
