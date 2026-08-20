// Ignore Spelling: App

namespace Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages
{
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;

	/// <summary>
	/// Identifies a message exchanged with an element running the example connector.
	/// </summary>
	public interface IExampleInterAppMessage
	{
	}

	/// <summary>
	/// Represents a generic inter-application message that contains data of type <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The type of the data contained in the message, which must implement <see cref="IExampleInterAppMessage"/>.</typeparam>
	public class GenericInterAppMessage<T> : Message
		where T : IExampleInterAppMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GenericInterAppMessage{T}"/> class with the specified data.
		/// </summary>
		/// <param name="data">The data contained in the message.</param>
		public GenericInterAppMessage(T data)
		{
			Data = data;
		}

		/// <summary>
		/// Gets the data contained in the message.
		/// </summary>
		public T Data { get; }
	}

	/// <summary>
	/// Identifies a message that can be sent to the example connector.
	/// </summary>
	public interface IExampleRequest : IExampleInterAppMessage
	{
	}

	/// <summary>
	/// Identifies a message returned by the example connector.
	/// </summary>
	public interface IExampleResponse : IExampleInterAppMessage
	{
		/// <summary>
		/// Gets or sets a value indicating whether the inter-application call completed successfully.
		/// </summary>
		bool Success { get; set; }

		/// <summary>
		/// Gets or sets a human-readable description of the call result.
		/// </summary>
		string Description { get; set; }
	}
}
