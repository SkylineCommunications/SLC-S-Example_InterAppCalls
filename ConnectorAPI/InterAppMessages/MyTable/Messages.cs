// Ignore Spelling: App

namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.Messages.MyTable
{
    using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;

    /// <summary>
    /// InterApp Message that will execute the simple example flow.
    /// </summary>
    public class SimpleCreateExampleRow : Message
    {
		/// <summary>
		/// The data needed to execute the simple example flow.
		/// </summary>
		public MyTableData ExampleData { get; set; }
    }

	/// <summary>
	/// InterApp Message that represent the response from the simple example flow.
	/// </summary>
	public class SimpleCreateExampleRowResult : Message
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
        public SimpleCreateExampleRow Request { get; set; }

		/// <summary>
		/// The primary key of the row that will be created.
		/// </summary>
        public string RowKey { get; set; }
    }

	/// <summary>
	/// InterApp Message that will execute the advanced example flow.
	/// </summary>
	public class AdvancedCreateExampleRow : Message
    {
		/// <summary>
		/// The data needed to execute the advanced example flow.
		/// </summary>
		public MyTableData ExampleData { get; set; }
    }

	/// <summary>
	/// InterApp Message that represent the response from the advanced example flow.
	/// </summary>
	public class AdvancedCreateExampleRowResult : Message
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
		public AdvancedCreateExampleRow Request { get; set; }

		/// <summary>
		/// The primary key of the row that will be created.
		/// </summary>
		public string RowKey { get; set; }
    }

	/// <summary>
	/// InterApp Message that will execute the delayed example flow.
	/// </summary>
	public class DelayedCreateExampleRow : Message
	{
		/// <summary>
		/// The data needed to execute the delayed example flow.
		/// </summary>
		public MyTableData ExampleData { get; set; }
	}

	/// <summary>
	/// InterApp Message that represent the response from the delayed example flow.
	/// </summary>
	public class DelayedCreateExampleRowResult : Message
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
		public DelayedCreateExampleRow Request { get; set; }

		/// <summary>
		/// The primary key of the created row.
		/// </summary>
		public string RowKey { get; set; }
	}
}
