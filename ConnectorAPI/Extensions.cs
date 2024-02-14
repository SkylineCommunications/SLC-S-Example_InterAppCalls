namespace Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Skyline.DataMiner.Core.DataMinerSystem.Common;
	using Skyline.DataMiner.Net;

	/// <summary>
	/// Extension Methods
	/// </summary>
	public static class Extensions
	{
		/// <summary>
		/// Get the 'Skyline Communication Example Connector InterApp Calls' element from a DataMiner system. 
		/// </summary>
		/// <param name="connection">The connection interface.</param>
		/// <param name="elementName">The element name defined in DataMiner.</param>
		/// <returns>The Skyline Communication Example Connector InterApp Calls.</returns>
		public static IExampleConnectorInterAppCalls GetSkylineCommunicationExampleConnectorInterAppCalls(this IConnection connection, string elementName)
		{
			var dms = connection.GetDms();
			IDmsElement element = dms.GetElement(elementName);
			return new ExampleConnectorInterAppCalls(connection, element);
		}

		/// <summary>
		/// Get the 'Skyline Communication Example Connector InterApp Calls' element from a DataMiner system. 
		/// </summary>
		/// <param name="connection">The connection interface.</param>
		/// <param name="elementId">The element ID defined in DataMiner.</param>
		/// <returns>The Skyline Communication Example Connector InterApp Calls.</returns>
		public static IExampleConnectorInterAppCalls GetSkylineCommunicationExampleConnectorInterAppCalls(this IConnection connection, DmsElementId elementId)
		{
			var dms = connection.GetDms();
			IDmsElement element = dms.GetElement(elementId);
			return new ExampleConnectorInterAppCalls(connection, element);
		}

		/// <summary>
		/// Get all the 'Skyline Communication Example Connector InterApp Calls' elements from a DataMiner system. 
		/// </summary>
		/// <param name="connection">The connection interface.</param>
		/// <returns>The Skyline Communication Example Connector InterApp Calls.</returns>
		public static IEnumerable<IExampleConnectorInterAppCalls> GetSkylineCommunicationExampleConnectorInterAppCalls(this IConnection connection)
		{
			var dms = connection.GetDms();
			var elements = dms.GetElements().Where(e => e.Protocol.Name == Constants.ProtocolName);

			return elements.Select(element => new ExampleConnectorInterAppCalls(connection, element));
		}

		/// <summary>
		/// Get the 'Skyline Communication Example Connector InterApp Calls' element from a DataMiner system.
		/// </summary>
		/// <param name="element">The element in DataMiner.</param>
		/// <param name="connection">The connection interface.</param>
		/// <returns>The Skyline Communication Example Connector InterApp Calls.</returns>
		public static IExampleConnectorInterAppCalls ToSkylineCommunicationExampleConnectorInterAppCalls(this IDmsElement element, IConnection connection)
		{
			return new ExampleConnectorInterAppCalls(connection, element);
		}
	}
}
