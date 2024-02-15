// Ignore Spelling: App

namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.Messages
{
    using System;
    using System.Collections.Generic;
    using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleInterAppCalls.Messages.MyTable;

	/// <summary>
	/// Static class holding the types of the InterApp Messages.
	/// </summary>
    public static class Types
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
