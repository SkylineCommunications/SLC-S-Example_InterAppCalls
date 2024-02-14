namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls
{
    using System.Collections.Generic;
    using Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls.Tables.Example;
    using Skyline.DataMiner.Core.DataMinerSystem.Common;
    using Skyline.DataMiner.Net;

	/// <summary>
	/// Defines an Example Connector InterApp Calls element.
	/// </summary>
    public interface IExampleConnectorInterAppCalls
	{
		/// <summary>
		/// DataMiner Element Interface.
		/// </summary>
		IDmsElement Element { get; }

		/// <summary>
		/// The SLNet Connection to use.
		/// </summary>
		IConnection SLNetConnection { get; set; }

		/// <summary>
		/// The rows of the Example Table.
		/// </summary>
		IEnumerable<IExampleRow> Examples { get; }

		/// <summary>
		/// Enable caching for the tables, this way it fetch the table once the first time you access it..
		/// </summary>
		void DisableCaching();

		/// <summary>
		/// Disables caching for the tables, this way it fetches the table every time you access it.
		/// </summary>
		void EnableCaching();
	}
}