// Ignore Spelling: App

namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.Messages
{
    using System;
    using System.Collections.Generic;

	using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.InterAppMessages;
	using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.Messages.MyTable;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;

	/// <summary>
	/// Static class holding the types of the InterApp Messages.
	/// </summary>
	public static class Types
    {
		/// <summary>
		/// Gets a list of all the supported InterApp Message Types.
		/// </summary>
		public static List<Type> KnownTypes { get; } = new List<Type>
		{
			// Example Messages
			typeof(GenericInterAppMessage<SimpleCreateExampleRow>),
			typeof(GenericInterAppMessage<SimpleCreateExampleRowResult>),
			typeof(GenericInterAppMessage<AdvancedCreateExampleRow>),
			typeof(GenericInterAppMessage<AdvancedCreateExampleRowResult>),
			typeof(GenericInterAppMessage<DelayedCreateExampleRow>),
			typeof(GenericInterAppMessage<DelayedCreateExampleRowResult>),
		};

		/// <summary>
		/// Converts an <see cref="IExampleRequest"/> message to a <see cref="Message"/> object.
		/// </summary>
		/// <param name="message">The <see cref="IExampleRequest"/> message to be converted.</param>
		/// <returns>
		/// A <see cref="Message"/> object that represents the specified <see cref="IExampleRequest"/> message.
		/// </returns>
		/// <exception cref="InvalidOperationException">Thrown when the message type is unknown.</exception>
		internal static Message ToMessage(IExampleRequest message)
		{
			switch (message)
			{
				case SimpleCreateExampleRow simpleCreateExampleRow:
					return new GenericInterAppMessage<SimpleCreateExampleRow>(simpleCreateExampleRow);

				case AdvancedCreateExampleRow advancedCreateExampleRow:
					return new GenericInterAppMessage<AdvancedCreateExampleRow>(advancedCreateExampleRow);

				case DelayedCreateExampleRow delayedCreateExampleRow:
					return new GenericInterAppMessage<DelayedCreateExampleRow>(delayedCreateExampleRow);

				default:
					throw new InvalidOperationException("Unknown message type");
			}
		}

		/// <summary>
		/// Converts a <see cref="Message"/> object to an <see cref="IExampleResponse"/>.
		/// </summary>
		/// <param name="message">The <see cref="Message"/> to be converted.</param>
		/// <returns>
		/// An <see cref="IExampleResponse"/> object that represents the data from the specified <see cref="Message"/>.
		/// </returns>
		/// <exception cref="InvalidOperationException">Thrown when the message type is unknown.</exception>
		internal static IExampleResponse FromMessage(Message message)
		{
			switch (message)
			{
				case GenericInterAppMessage<SimpleCreateExampleRowResult> simpleCreateExampleRowResult:
					return simpleCreateExampleRowResult.Data;

				case GenericInterAppMessage<AdvancedCreateExampleRowResult> advancedCreateExampleRowResult:
					return advancedCreateExampleRowResult.Data;

				case GenericInterAppMessage<DelayedCreateExampleRowResult> delayedCreateExampleRowResult:
					return delayedCreateExampleRowResult.Data;

				default:
					throw new InvalidOperationException("Unknown message type");
			}
		}
	}
}
