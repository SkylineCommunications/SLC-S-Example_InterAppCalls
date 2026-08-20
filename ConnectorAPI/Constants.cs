// Ignore Spelling: App

namespace Skyline.DataMiner.ConnectorAPI.ExampleInterAppCalls
{
	/// <summary>
	/// Contains constant values used in the ConnectorAPI.
	/// </summary>
	public static class Constants
	{
		/// <summary>
		/// Gets the protocol name of the example connector that accepts the inter-application calls.
		/// </summary>
		public const string ProtocolName = "Skyline Example InterAppCalls";

		/// <summary>
		/// Gets the identifier of the parameter that receives inter-application messages.
		/// </summary>
		public const int InterAppReceiverPID = 9000000;

		/// <summary>
		/// Gets the identifier of the parameter that carries inter-application responses.
		/// </summary>
		public const int InterAppResponsePID = 9000001;
	}
}
