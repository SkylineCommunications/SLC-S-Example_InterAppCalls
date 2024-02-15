// Ignore Spelling: App

namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.Messages.MyTable
{
    using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;

    public class SimpleCreateExampleRow : Message
    {
        public MyTableData ExampleData { get; set; }
    }

    public class SimpleCreateExampleRowResult : Message
    {
        public bool Success { get; set; }

        public string Description { get; set; }

        public SimpleCreateExampleRow Request { get; set; }

        public string RowKey { get; set; }
    }

    public class AdvancedCreateExampleRow : Message
    {
        public MyTableData ExampleData { get; set; }
    }

    public class AdvancedCreateExampleRowResult : Message
    {
        public bool Success { get; set; }

        public string Description { get; set; }

        public AdvancedCreateExampleRow Request { get; set; }

        public string RowKey { get; set; }
    }

	public class DelayedCreateExampleRow : Message
	{
		public MyTableData ExampleData { get; set; }
	}

	public class DelayedCreateExampleRowResult : Message
	{
		public bool Success { get; set; }

		public string Description { get; set; }

		public DelayedCreateExampleRow Request { get; set; }

		public string RowKey { get; set; }
	}
}
