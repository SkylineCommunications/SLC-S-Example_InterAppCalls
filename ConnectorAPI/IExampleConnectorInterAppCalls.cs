namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls
{
	using System;
	using System.Collections.Generic;
    using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls.Tables.Example;
    using Skyline.DataMiner.Core.DataMinerSystem.Common;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;
	using Skyline.DataMiner.Net;

	/// <summary>
	/// Defines an Example Connector InterApp Calls element.
	/// </summary>
	public interface IExampleConnectorInterAppCalls
	{
		/// <summary>
		/// DataMiner Element Interface.
		/// </summary>
		IDmsElement Element { get; }

		/// <summary>
		/// The SLNet Connection to use.
		/// </summary>
		IConnection SLNetConnection { get; set; }

		/// <summary>
		/// The rows of the Example Table.
		/// </summary>
		IEnumerable<IExampleRow> Examples { get; }

		/// <summary>
		/// Enable caching for the tables, this way it fetch the table once the first time you access it..
		/// </summary>
		void DisableCaching();

		/// <summary>
		/// Disables caching for the tables, this way it fetches the table every time you access it.
		/// </summary>
		void EnableCaching();

		/// <summary>
		/// Sends the specified messages to the element using InterApp and do not wait for a response.
		/// </summary>
		/// <param name="messages">The messages that need to be send.</param>
		void SendMessageNoResponse(params Message[] messages);

		/// <summary>
		/// Sends the specified messages to the element using InterApp and wait for the responses.
		/// </summary>
		/// <param name="messages">The messages that need to be send.</param>
		/// <param name="timeout">The time the method needs to wait for a response.</param>
		/// <returns></returns>
		IEnumerable<Message> SendMessages(Message[] messages, TimeSpan timeout = default);

		/// <summary>
		/// Sends the specified message to the element using InterApp and wait for the responses.
		/// </summary>
		/// <param name="message">The message that needs to be send.</param>
		/// <param name="timeout">The time the method needs to wait for a response.</param>
		/// <returns></returns>
		Message SendSingleResponseMessage(Message message, TimeSpan timeout = default);
	}
}