namespace Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages.GenericDataSource
{
	/// <summary>
	/// Represents a request to apply a Boolean configuration value on a data source.
	/// </summary>
	public class DataSourceBooleanConfigRequest : IExampleRequest
	{
		/// <summary>
		/// Gets or sets the Boolean configuration value to apply.
		/// </summary>
		public bool Config { get; set; }
	}

	/// <summary>
	/// Represents the result of applying a Boolean configuration value on a data source.
	/// </summary>
	public class DataSourceBooleanConfigResponse : IExampleResponse
	{
		/// <summary>
		/// Gets or sets a value indicating whether the configuration was applied successfully.
		/// </summary>
		public bool Success { get; set; }
		
		/// <summary>
		/// Gets or sets a human-readable description of the configuration result.
		/// </summary>
		public string Description { get; set; }
	}
}
