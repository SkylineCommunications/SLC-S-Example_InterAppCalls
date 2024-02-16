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
        /// <summary>
        /// The primary key of the row.
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// The value optional for the Numeric Column.
        /// </summary>
        public double? MyNumericColumn { get; set; }

        /// <summary>
        /// The optional value for the String Column.
        /// </summary>
        public string MyStringColumn { get; set; }

        /// <summary>
        /// The optional value for the Discreet Column.
        /// </summary>
        public DiscreetColumnOption? MyDiscreetColumn { get; set; }
    }
}
