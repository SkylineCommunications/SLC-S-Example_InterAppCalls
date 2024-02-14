namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls.Tables.Example;
	using Skyline.DataMiner.Core.DataMinerSystem.Common;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallBulk;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;
	using Skyline.DataMiner.Core.InterAppCalls.Common.Shared;
	using Skyline.DataMiner.Net;

	internal class ExampleConnectorInterAppCalls : IExampleConnectorInterAppCalls
	{
		private TimeSpan defaultTimeout = TimeSpan.FromSeconds(30);
		private ExampleRow[] exampleRows;
		internal bool caching = true;


		/// <summary>
		/// Internal constructor used in the extensions methods to create an instance.
		/// </summary>
		/// <param name="connection">The connection interface.</param>
		/// <param name="element">The element in DataMiner.</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		internal ExampleConnectorInterAppCalls(IConnection connection, IDmsElement element)
		{
			if (Element == null)
			{
				throw new ArgumentNullException(nameof(element));
			}

			if (element.Protocol.Name != Constants.ProtocolName)
			{
				throw new ArgumentException($"The element is not running protocol '{Constants.ProtocolName}'", nameof(element));
			}

			Element = element;
			SLNetConnection = connection;
		}

		/// <inheritdoc/>
		public IConnection SLNetConnection { get; set; }

		/// <inheritdoc/>
		public IDmsElement Element { get; private set; }

		#region Optionally we could wrap the InterAppMessages even further
		public IEnumerable<IExampleRow> Examples
		{
			get
			{
				if (exampleRows == null || !caching)
				{
					exampleRows = ExampleRow.GetExampleRows(this);
				}

				return exampleRows;
			}
		}


		/// <inheritdoc/>
		public void DisableCaching()
		{
			caching = false;
		}

		/// <inheritdoc/>
		public void EnableCaching()
		{
			caching = true;
		}
		#endregion

		/// <summary>
		/// Sends the specified messages to the element using InterApp and do not wait for a response.
		/// </summary>
		/// <param name="messages">The messages that need to be send.</param>
		public void SendMessageNoResponse(params Message[] messages)
		{
			
			IInterAppCall myCommands = InterAppCallFactory.CreateNew();
			myCommands.ReturnAddress = new ReturnAddress(Element.DmsElementId.AgentId, Element.DmsElementId.ElementId, Constants.InterAppResponsePID);
			myCommands.Messages.AddMessage(messages);
			myCommands.Send(SLNetConnection, Element.DmsElementId.AgentId, Element.DmsElementId.ElementId, Constants.InterAppReceiverPID, Messages.Types.KnownTypes);
		}

		/// <summary>
		/// Sends the specified messages to the element using InterApp and wait for the responses.
		/// </summary>
		/// <param name="messages">The messages that need to be send.</param>
		/// <param name="timeout">The time the method needs to wait for a response.</param>
		/// <returns></returns>
		public IEnumerable<Message> SendMessages(Message[] messages, TimeSpan timeout = default)
		{
			var interAppCallTimeout = timeout;
			if (timeout == default)
			{
				interAppCallTimeout = defaultTimeout;
			}

			IInterAppCall myCommands = InterAppCallFactory.CreateNew();
			myCommands.ReturnAddress = new ReturnAddress(Element.DmsElementId.AgentId, Element.DmsElementId.ElementId, Constants.InterAppResponsePID);
			myCommands.Messages.AddMessage(messages);
			return myCommands.Send(SLNetConnection, Element.DmsElementId.AgentId, Element.DmsElementId.ElementId, Constants.InterAppReceiverPID, interAppCallTimeout, Messages.Types.KnownTypes);
		}

		/// <summary>
		/// Sends the specified message to the element using InterApp and wait for the responses.
		/// </summary>
		/// <param name="message">The message that needs to be send.</param>
		/// <param name="timeout">The time the method needs to wait for a response.</param>
		/// <returns></returns>
		public Message SendSingleResponseMessage(Message message, TimeSpan timeout = default)
		{
			var interAppCallTimeout = timeout;
			if (timeout == default)
			{
				interAppCallTimeout = defaultTimeout;
			}

			IInterAppCall myCommand = InterAppCallFactory.CreateNew();
			myCommand.ReturnAddress = new ReturnAddress(Element.DmsElementId.AgentId, Element.DmsElementId.ElementId, Constants.InterAppResponsePID);
			myCommand.Messages.AddMessage(message);
			return myCommand.Send(SLNetConnection, Element.DmsElementId.AgentId, Element.DmsElementId.ElementId, Constants.InterAppReceiverPID, interAppCallTimeout, Messages.Types.KnownTypes).First();
		}
	}
}
