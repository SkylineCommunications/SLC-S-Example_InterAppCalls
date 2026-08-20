namespace Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages.GenericDataMiner
{
	/// <summary>
	/// Represents a request to apply a string configuration value on a DataMiner element.
	/// </summary>
	public class DataMinerStringConfigRequest : IExampleRequest
	{
		/// <summary>
		/// Gets or sets the string configuration value to apply.
		/// </summary>
		public string Config { get; set; }
	}

	/// <summary>
	/// Represents the result of applying a string configuration value on a DataMiner element.
	/// </summary>
	public class DataMinerStringConfigResponse : IExampleResponse
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
