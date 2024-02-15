// Ignore Spelling: App

namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.Messages.MyTable
{
    using System;

    /// <summary>
    /// Class that represents a row in the table called 'My Table'.
    /// </summary>
    [Serializable]
    public class MyTableData
    {
        public string Instance { get; set; }

        public double? MyNumericColumn { get; set; }

        public string MyStringColumn { get; set; }

        public Value3Discreet? MyDiscreetColumn { get; set; }
    }
}
