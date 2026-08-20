namespace Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages.GenericDataMiner
{
	/// <summary>
	/// Represents a request to apply a Boolean configuration value on a DataMiner element.
	/// </summary>
	public class DataMinerBooleanConfigRequest : IExampleRequest
	{
		/// <summary>
		/// Gets or sets the Boolean configuration value to apply.
		/// </summary>
		public bool Config { get; set; }
	}

	/// <summary>
	/// Represents the result of applying a Boolean configuration value on a DataMiner element.
	/// </summary>
	public class DataMinerBooleanConfigResponse : IExampleResponse
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
