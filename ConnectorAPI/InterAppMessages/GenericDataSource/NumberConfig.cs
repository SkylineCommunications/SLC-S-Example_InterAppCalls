namespace Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages.GenericDataSource
{
	/// <summary>
	/// Represents a request to apply a numeric configuration value on a data source.
	/// </summary>
	public class DataSourceNumberConfigRequest : IExampleRequest
	{
		/// <summary>
		/// Gets or sets the numeric configuration value to apply.
		/// </summary>
		public double Config { get; set; }
	}

	/// <summary>
	/// Represents the result of applying a numeric configuration value on a data source.
	/// </summary>
	public class DataSourceNumberConfigResponse : IExampleResponse
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
