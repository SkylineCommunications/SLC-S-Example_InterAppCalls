namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls.Messages
{
    using System;
    using System.Collections.Generic;
    using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls.Messages.Example;

    public class Types
    {
		/// <summary>
		/// Gets a list of all the supported InterApp Message Types.
		/// </summary>
		public static List<Type> KnownTypes { get; } = new List<Type>
		{
			// Example Messages
			typeof(SimpleCreateExampleRow),
			typeof(SimpleCreateExampleRowResult),
			typeof(AdvancedCreateExampleRow),
			typeof(AdvancedCreateExampleRowResult),
			typeof(DelayedCreateExampleRow),
			typeof(DelayedCreateExampleRowResult),
		};
	}
}
