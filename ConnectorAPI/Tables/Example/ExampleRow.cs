namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls.Tables.Example
{
    using System;
    using System.Linq;
    using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls;
    using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls.Messages.Example;

    internal class ExampleRow : IExampleRow
    {
        internal readonly ExampleConnectorInterAppCalls exampleConnectorInterAppCalls;

        internal ExampleRow(ExampleConnectorInterAppCalls element, object[] row)
        {
            exampleConnectorInterAppCalls = element;
            Instance = Convert.ToString(row[0]);
            Value1 = Convert.ToDouble(row[1]);
            Value2 = Convert.ToString(row[0]);
            Value3 = (Value3Discreet)Convert.ToInt32(row[2]);
        }

        public string Instance { get; private set; }

        public double Value1 { get; private set; }

        public string Value2 { get; private set; }

        public Value3Discreet Value3 { get; private set; }

        public bool SimpleAddRow(SimpleCreateExampleRow row)
        {
            try
            {
                var baseResult = exampleConnectorInterAppCalls.SendSingleResponseMessage(row, new TimeSpan(0, 0, 10));
                if (baseResult == null)
                {
                    return false;
                }

                var result = baseResult as SimpleCreateExampleRowResult;
                if (result == null)
                {
                    return false;
                }

                if (result.Success)
                {
                    return true;
                }

                return false;
            }
            catch (TimeoutException timeEx)
            {
                return false;
            }
        }

        public bool AdvancedAddRow(AdvancedCreateExampleRow row)
        {
            try
            {
                var baseResult = exampleConnectorInterAppCalls.SendSingleResponseMessage(row, new TimeSpan(0, 0, 10));
                if (baseResult == null)
                {
                    return false;
                }

                var result = baseResult as AdvancedCreateExampleRowResult;
                if (result == null)
                {
                    return false;
                }

                if (result.Success)
                {
                    return true;
                }

                return false;
            }
            catch (TimeoutException timeEx)
            {
                return false;
            }
        }

        internal static ExampleRow[] GetExampleRows(ExampleConnectorInterAppCalls element)
        {
            var rows = element.Element.GetTable(1000).GetRows().Select(row => new ExampleRow(element, row));
            return rows.ToArray();
        }
    }
}
