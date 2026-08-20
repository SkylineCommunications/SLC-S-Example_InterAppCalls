namespace Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls.InterAppMessages.GenericDataSource
{
	/// <summary>
	/// Represents the color values supported by the data source configuration example.
	/// </summary>
	public enum DataSourceDiscreet
	{
		/// <summary>
		/// Represents the blue configuration value.
		/// </summary>
		Blue,

		/// <summary>
		/// Represents the green configuration value.
		/// </summary>
		Green,

		/// <summary>
		/// Represents the red configuration value.
		/// </summary>
		Red,
	}

	/// <summary>
	/// Represents a request to apply a discreet configuration value on a data source.
	/// </summary>
	public class DataSourceDiscreetConfigRequest : IExampleRequest
	{
		/// <summary>
		/// Gets or sets the discreet configuration value to apply.
		/// </summary>
		public DataSourceDiscreet Config { get; set; }
	}

	/// <summary>
	/// Represents the result of applying a discreet configuration value on a data source.
	/// </summary>
	public class DataSourceDiscreetConfigResponse : IExampleResponse
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
