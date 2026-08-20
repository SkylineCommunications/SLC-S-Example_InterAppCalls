// Ignore Spelling: App dma

namespace Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls
{
	using System;
	using System.Collections.Generic;

	using Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages;
	using Skyline.DataMiner.Net;

	/// <summary>
	/// Defines the methods for inter-application communication involving example requests and responses.
	/// </summary>
	public interface IExampleInterAppCalls
	{
		/// <summary>
		/// Gets or sets the SLNet connection used to send inter-application calls.
		/// </summary>
		IConnection SLNetConnection { get; set; }

		/// <summary>
		/// Gets the identifier of the DataMiner Agent hosting the target element.
		/// </summary>
		int AgentId { get; }

		/// <summary>
		/// Gets the identifier of the target element in DataMiner.
		/// </summary>
		int ElementId { get; }

		/// <summary>
		/// Sends the specified messages to the target element without waiting for responses.
		/// </summary>
		/// <param name="messages">The messages that need to be send.</param>
		void SendMessageNoResponse(params IExampleRequest[] messages);

		/// <summary>
		/// Sends the specified messages to the target element and waits for the responses.
		/// </summary>
		/// <param name="messages">The messages to send.</param>
		/// <param name="timeout">The maximum time to wait for responses. The implementation default is used when this is <see cref="TimeSpan.Zero"/>.</param>
		/// <returns>The responses returned by the target element.</returns>
		IEnumerable<IExampleResponse> SendMessages(IExampleRequest[] messages, TimeSpan timeout = default);

		/// <summary>
		/// Sends a message to the target element and waits for its response.
		/// </summary>
		/// <param name="message">The message to send.</param>
		/// <param name="timeout">The maximum time to wait for a response. The implementation default is used when this is <see cref="TimeSpan.Zero"/>.</param>
		/// <returns>The response returned by the target element.</returns>
		IExampleResponse SendSingleResponseMessage(IExampleRequest message, TimeSpan timeout = default);

		/// <summary>
		/// Sends a message to the target element and returns its response as the requested type.
		/// </summary>
		/// <param name="message">The message to send.</param>
		/// <param name="timeout">The maximum time to wait for a response. The implementation default is used when this is <see cref="TimeSpan.Zero"/>.</param>
		/// <returns>The response returned by the target element.</returns>
		/// <typeparam name="T">The type of the expected response, which must implement <see cref="IExampleResponse"/>.</typeparam>
		T SendSingleResponseMessage<T>(IExampleRequest message, TimeSpan timeout = default) where T : IExampleResponse;
	}
}