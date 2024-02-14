namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls.Tables.Example
{
    using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls.Messages.Example;

    public interface IExampleRow
    {
        bool SimpleAddRow(SimpleCreateExampleRow row);

        bool AdvancedAddRow(AdvancedCreateExampleRow row);
    }
}
