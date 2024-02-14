namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls.Messages.Example
{
    using System;

    /// <summary>
    /// Class that represents a row in the Example Table.
    /// </summary>
    [Serializable]
    public class ExampleData
    {
        public string Instance { get; set; }

        public double? Value1 { get; set; }

        public string Value2 { get; set; }

        public Value3Discreet? Value3 { get; set; }
    }
}
