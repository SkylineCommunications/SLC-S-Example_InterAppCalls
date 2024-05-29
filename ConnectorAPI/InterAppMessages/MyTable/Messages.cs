// Ignore Spelling: App

namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.Messages.MyTable
{
	using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.InterAppMessages;

    /// <summary>
    /// InterApp Message that will execute the simple example flow.
    /// </summary>
    public class SimpleCreateExampleRow : IExampleRequest
    {
		/// <summary>
		/// The data needed to execute the simple example flow.
		/// </summary>
		public MyTableData ExampleData { get; set; }
    }

	/// <summary>
	/// InterApp Message that represent the response from the simple example flow.
	/// </summary>
	public class SimpleCreateExampleRowResult : IExampleResponse
    {
		/// <summary>
		/// Indicates if the InterApp Call was successful or not
		/// </summary>
        public bool Success { get; set; }

		/// <summary>
		/// A human readable text representing the response of the InterApp Call.
		/// </summary>
        public string Description { get; set; }

		/// <summary>
		/// The InterApp Message that triggered this response.
		/// </summary>
        public IExampleRequest Request { get; set; }

		/// <summary>
		/// The primary key of the row that will be created.
		/// </summary>
        public string RowKey { get; set; }
    }

	/// <summary>
	/// InterApp Message that will execute the advanced example flow.
	/// </summary>
	public class AdvancedCreateExampleRow : IExampleRequest
	{
		/// <summary>
		/// The data needed to execute the advanced example flow.
		/// </summary>
		public MyTableData ExampleData { get; set; }
    }

	/// <summary>
	/// InterApp Message that represent the response from the advanced example flow.
	/// </summary>
	public class AdvancedCreateExampleRowResult : IExampleResponse
	{
		/// <summary>
		/// Indicates if the InterApp Call was successful or not
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// A human readable text representing the response of the InterApp Call.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The InterApp Message that triggered this response.
		/// </summary>
		public IExampleRequest Request { get; set; }

		/// <summary>
		/// The primary key of the row that will be created.
		/// </summary>
		public string RowKey { get; set; }
    }

	/// <summary>
	/// InterApp Message that will execute the delayed example flow.
	/// </summary>
	public class DelayedCreateExampleRow : IExampleRequest
	{
		/// <summary>
		/// The data needed to execute the delayed example flow.
		/// </summary>
		public MyTableData ExampleData { get; set; }
	}

	/// <summary>
	/// InterApp Message that represent the response from the delayed example flow.
	/// </summary>
	public class DelayedCreateExampleRowResult : IExampleResponse
	{
		/// <summary>
		/// Indicates if the InterApp Call was successful or not
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// A human readable text representing the response of the InterApp Call.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The InterApp Message that triggered this response.
		/// </summary>
		public IExampleRequest Request { get; set; }

		/// <summary>
		/// The primary key of the created row.
		/// </summary>
		public string RowKey { get; set; }
	}
}
