// Ignore Spelling: App

namespace Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.Messages
{
	using System;
	using System.Collections.Generic;

	using Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages;
	using Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages.GenericDataMiner;
	using Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages.GenericDataSource;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;

	/// <summary>
	/// Provides the message types supported by the example connector and converts
	/// between public API messages and InterApp library messages.
	/// </summary>
	public static class Types
	{
		/// <summary>
		/// Gets a list of all the supported InterApp Message Types.
		/// </summary>
		public static List<Type> KnownTypes { get; } = new List<Type>
		{
			// Generic DataMiner Messages
			typeof(GenericInterAppMessage<DataMinerStringConfigRequest>),
			typeof(GenericInterAppMessage<DataMinerStringConfigResponse>),
			typeof(GenericInterAppMessage<DataMinerDiscreetConfigRequest>),
			typeof(GenericInterAppMessage<DataMinerDiscreetConfigResponse>),
			typeof(GenericInterAppMessage<DataMinerNumberConfigRequest>),
			typeof(GenericInterAppMessage<DataMinerNumberConfigResponse>),
			typeof(GenericInterAppMessage<DataMinerBooleanConfigRequest>),
			typeof(GenericInterAppMessage<DataMinerBooleanConfigResponse>),

			// Generic DataSource Messages
			typeof(GenericInterAppMessage<DataSourceStringConfigRequest>),
			typeof(GenericInterAppMessage<DataSourceStringConfigResponse>),
			typeof(GenericInterAppMessage<DataSourceDiscreetConfigRequest>),
			typeof(GenericInterAppMessage<DataSourceDiscreetConfigResponse>),
			typeof(GenericInterAppMessage<DataSourceNumberConfigRequest>),
			typeof(GenericInterAppMessage<DataSourceNumberConfigResponse>),
			typeof(GenericInterAppMessage<DataSourceBooleanConfigRequest>),
			typeof(GenericInterAppMessage<DataSourceBooleanConfigResponse>),
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
			return message switch
			{
				DataMinerStringConfigRequest genericDataMinerStringConfig => new GenericInterAppMessage<DataMinerStringConfigRequest>(genericDataMinerStringConfig),
				DataMinerDiscreetConfigRequest genericDataMinerDiscreetConfig => new GenericInterAppMessage<DataMinerDiscreetConfigRequest>(genericDataMinerDiscreetConfig),
				DataMinerNumberConfigRequest genericDataMinerNumberConfig => new GenericInterAppMessage<DataMinerNumberConfigRequest>(genericDataMinerNumberConfig),
				DataMinerBooleanConfigRequest genericDataMinerBooleanConfig => new GenericInterAppMessage<DataMinerBooleanConfigRequest>(genericDataMinerBooleanConfig),
				DataSourceStringConfigRequest genericDataSourceStringConfig => new GenericInterAppMessage<DataSourceStringConfigRequest>(genericDataSourceStringConfig),
				DataSourceDiscreetConfigRequest genericDataSourceDiscreetConfig => new GenericInterAppMessage<DataSourceDiscreetConfigRequest>(genericDataSourceDiscreetConfig),
				DataSourceNumberConfigRequest genericDataSourceNumberConfig => new GenericInterAppMessage<DataSourceNumberConfigRequest>(genericDataSourceNumberConfig),
				DataSourceBooleanConfigRequest genericDataSourceBooleanConfig => new GenericInterAppMessage<DataSourceBooleanConfigRequest>(genericDataSourceBooleanConfig),
				_ => throw new InvalidOperationException("Unknown message type")
			};
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
			return message switch
			{
				GenericInterAppMessage<DataMinerStringConfigResponse> genericDataMinerStringConfigResult => genericDataMinerStringConfigResult.Data,
				GenericInterAppMessage<DataMinerDiscreetConfigResponse> genericDataMinerDiscreetConfigResult => genericDataMinerDiscreetConfigResult.Data,
				GenericInterAppMessage<DataMinerNumberConfigResponse> genericDataMinerNumberConfigResult => genericDataMinerNumberConfigResult.Data,
				GenericInterAppMessage<DataMinerBooleanConfigResponse> genericDataMinerBooleanConfigResult => genericDataMinerBooleanConfigResult.Data,
				GenericInterAppMessage<DataSourceStringConfigResponse> genericDataSourceStringConfigResult => genericDataSourceStringConfigResult.Data,
				GenericInterAppMessage<DataSourceDiscreetConfigResponse> genericDataSourceDiscreetConfigResult => genericDataSourceDiscreetConfigResult.Data,
				GenericInterAppMessage<DataSourceNumberConfigResponse> genericDataSourceNumberConfigResult => genericDataSourceNumberConfigResult.Data,
				GenericInterAppMessage<DataSourceBooleanConfigResponse> genericDataSourceBooleanConfigResult => genericDataSourceBooleanConfigResult.Data,
				_ => throw new InvalidOperationException("Unknown message type"),
			};
		}
	}
}
