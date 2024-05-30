# Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls

The ConnectorAPI Example NuGet package demonstrates best practices for creating a connector API. This package provides a robust framework of classes designed to facilitate interaction with various connectors, serving as a template for developers looking to implement their own connector APIs efficiently and effectively.

## Considerations
- **Best Practices**: When building a NuGet package, it's best practice to avoid exposing any classes from external libraries, such as the InterApp Library. This prevents potential versioning issues. In this example package, no public methods or properties use arguments or return types from the InterApp Library to ensure compatibility and stability.
- **Error Handling**: When building a ConnectorAPI, it's important to carefully consider error handling. In this example, responses should inherit from the IExampleResponse interface, which includes two properties: a boolean Success and a string Description. These properties can be used to provide meaningful error messages when something goes wrong.
- **Documentation**: Thoroughly documented classes and methods to aid developers in understanding and utilizing the package effectively.

## Creating your own ConnectorAPI

1. To avoid dependency hell issues, instead of all our messages inheriting from the **Message** type. We create some custom interfaces to help the user experience and avoid the dependency issues. In this SDF we created 3 interfaces:
You can rename these interfaces occording the your own ConnectorAPI.

	For Example **IMyConnectorMessage**, **IMyConnectorRequest**, **IMyConnectorResponse**.
	- IExampleInterAppMessage

	```csharp
	/// <summary>
	/// Represents an InterApp Message that a Skyline Communications Example InterApp Calls element can receive.
	/// </summary>
	public interface IExampleInterAppMessage
	{
	}
	```

	- IExampleRequest

	```csharp
	/// <summary>
	/// Base class that hold default properties that every request has.
	/// </summary>
	public interface IExampleRequest : IExampleInterAppMessage
	{
	}
	```

	- IExampleResponse

	```csharp
	/// <summary>
	/// Base class that hold default properties that every response has.
	/// </summary>
	public interface IExampleResponse : IExampleInterAppMessage
	{
		/// <summary>
		/// Indicates if the InterApp Call was successful or not
		/// </summary>
		bool Success { get; set; }

		/// <summary>
		/// A human readable text representing the response of the InterApp Call.
		/// </summary>
		string Description { get; set; }

		/// <summary>
		/// The InterApp Message that triggered this response.
		/// </summary>
		IExampleRequest Request { get; set; }
	}
	```

	These interface will be the ones we expose in the NuGet. This means no dependency hell issues.

1. The second step to sending InterApp messages is to create an object of Type **Message**, which is a Type from the InterApp library. In the example we created a Generic class that to avoid having all that all our message classes need to inherit from **Message**. This way we only have to do it once.
You can copy and paste this exact code, and don't forget to rename the **IExampleInterAppMessage** to the one you created in step 1.

	```csharp
	/// <summary>
	/// Represents a generic inter-application message that contains data of type <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The type of the data contained in the message, which must implement <see cref="IExampleInterAppMessage"/>.</typeparam>
	public class GenericInterAppMessage<T> : Message
		where T : IExampleInterAppMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GenericInterAppMessage{T}"/> class with the specified data.
		/// </summary>
		/// <param name="data">The data contained in the message.</param>
		public GenericInterAppMessage(T data)
		{
			Data = data;
		}

		/// <summary>
		/// Gets the data contained in the message.
		/// </summary>
		public T Data { get; }
	}
	```

1. Now it's time to define all the messages, you need the connector to support. Create a class for each InterApp request and implement the request interface you created in step 1. Do the same thing for all the responses and implement the response interface from step 1.
	
	Take for example the **SimpleCreateExampleRow** request and it's corresponding response **SimpleCreateExampleRowResult**.
	```csharp
	/// <summary>
	/// InterApp Message that will execute the simple example flow.
	/// </summary>
	public class SimpleCreateExampleRow : IExampleRequest
	{
		/// <summary>
		/// The data needed to execute the simple example flow.
		/// </summary>
		public MyTableData ExampleData { get; set; }
	}

	/// <summary>
	/// InterApp Message that represent the response from the simple example flow.
	/// </summary>
	public class SimpleCreateExampleRowResult : IExampleResponse
	{
		/// <summary>
		/// Indicates if the InterApp Call was successful or not
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// A human readable text representing the response of the InterApp Call.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The InterApp Message that triggered this response.
		/// </summary>
		public IExampleRequest Request { get; set; }

		/// <summary>
		/// The primary key of the row that will be created.
		/// </summary>
		public string RowKey { get; set; }
	}
	```

1. In order to safely be able to serialize/deserialize these object, we'll need to create a white-list of all the types the InterApp serializer can allow. This list needs to be a list of all the **Message** types. You could be wondering, but our messages don't inherit from the **Message** class and you are correct. Therefore we wrap the types in the generic type we created in step 2. The result should be a list of Message types. In this SDF the list looks like this:
	```csharp
	/// <summary>
	/// Gets a list of all the supported InterApp Message Types.
	/// </summary>
	public static List<Type> KnownTypes { get; } = new List<Type>
	{
		// Example Messages
		typeof(GenericInterAppMessage<SimpleCreateExampleRow>),
		typeof(GenericInterAppMessage<SimpleCreateExampleRowResult>),
		typeof(GenericInterAppMessage<AdvancedCreateExampleRow>),
		typeof(GenericInterAppMessage<AdvancedCreateExampleRowResult>),
		typeof(GenericInterAppMessage<DelayedCreateExampleRow>),
		typeof(GenericInterAppMessage<DelayedCreateExampleRowResult>),
	};
	```

1. Now we need a way to translate our exposed messages to an actual **Message** object that the InterApp library understands and the other way around. Therefore we need to add 2 internal methods called **ToMessage** **FromMessage**. Which will translate to and from a **Message** object. In the SDF these look like this and can also be found in the static class Types :

	```csharp
	/// <summary>
	/// Converts an <see cref="IExampleRequest"/> message to a <see cref="Message"/> object.
	/// </summary>
	/// <param name="message">The <see cref="IExampleRequest"/> message to be converted.</param>
	/// <returns>
	/// A <see cref="Message"/> object that represents the specified <see cref="IExampleRequest"/> message.
	/// </returns>
	/// <exception cref="InvalidOperationException">Thrown when the message type is unknown.</exception>
	internal static Message ToMessage(IExampleRequest message)
	{
		switch (message)
		{
			case SimpleCreateExampleRow simpleCreateExampleRow:
				return new GenericInterAppMessage<SimpleCreateExampleRow>(simpleCreateExampleRow);

			case AdvancedCreateExampleRow advancedCreateExampleRow:
				return new GenericInterAppMessage<AdvancedCreateExampleRow>(advancedCreateExampleRow);

			case DelayedCreateExampleRow delayedCreateExampleRow:
				return new GenericInterAppMessage<DelayedCreateExampleRow>(delayedCreateExampleRow);

			default:
				throw new InvalidOperationException("Unknown message type");
		}
	}
	```

	```csharp
	/// <summary>
	/// Converts a <see cref="Message"/> object to an <see cref="IExampleResponse"/>.
	/// </summary>
	/// <param name="message">The <see cref="Message"/> to be converted.</param>
	/// <returns>
	/// An <see cref="IExampleResponse"/> object that represents the data from the specified <see cref="Message"/>.
	/// </returns>
	/// <exception cref="InvalidOperationException">Thrown when the message type is unknown.</exception>
	internal static IExampleResponse FromMessage(Message message)
	{
		switch (message)
		{
			case GenericInterAppMessage<SimpleCreateExampleRowResult> simpleCreateExampleRowResult:
				return simpleCreateExampleRowResult.Data;

			case GenericInterAppMessage<AdvancedCreateExampleRowResult> advancedCreateExampleRowResult:
				return advancedCreateExampleRowResult.Data;

			case GenericInterAppMessage<DelayedCreateExampleRowResult> delayedCreateExampleRowResult:
				return delayedCreateExampleRowResult.Data;

			default:
				throw new InvalidOperationException("Unknown message type");
		}
	}
	```

1. To avoid scripts and connectors having a magic number with the parameter ids of the receiver/responder parameters. We will create a constant class that hold them. That way it's easier to manage if it would ever change. In the SDF we also included a constant with the protocol name, to avoid people sending messages to a wrong element. The class then looks like this.
	```csharp
	/// <summary>
	/// Contains constant values used in the ConnectorAPI.
	/// </summary>
	public static class Constants
	{
		/// <summary>
		/// The protocol name of the Skyline Communications Example Connector InterApp Calls.
		/// </summary>
		public const string ProtocolName = "Skyline Communications Example InterApp Calls";

		/// <summary>
		/// The ID of the parameter that will receive the InterApp Messages
		/// </summary>
		public const int InterAppReceiverPID = 9000000;

		/// <summary>
		/// The ID of the parameter that will hold the responses for the InterApp Messages
		/// </summary>
		public const int InterAppResponsePID = 9000001;
	}
	```

1. We can then write a wrapper around the InterApp to have a better user experience. The wrapper will have method to send and receive messages, do checks to avoid wrong messages, have default timeout values and hide away the InterApp communication. This class is already very generic you could copy and paste this and change out the interfaces with your own and should be all set.
You can find the class in the root of the project, called **ExampleInterAppCalls**. Ofcourse you should also rename the class to something like **MyConnector**, or something else that indicates what the class is about.

1. Now you are set and can start to implement your NuGet in the connector. See the Connector Example on how to implement this. [SLC-C-Example_InterAppCalls](https://github.com/SkylineCommunications/SLC-C-Example_InterAppCalls)



For more documentation on InterApp see the [InterApp DataMiner Docs](https://docs.dataminer.services/develop/devguide/ClassLibrary/ClassLibraryInterAppClasses.html?q=InterApp#creating-an-api).

## Getting Started
Here's a quick guide to help you get started with the ConnectorAPI Example NuGet package:


Create an ExampleInterAppCalls object to get started.
```csharp
// For Automation Scripts
var exampleElement = new ExampleInterAppCalls(engine.GetUserConnection(), agentId, elementId);

// For Connectors
var exampleElement = new ExampleInterAppCalls(protocol.SLNet.RawConnection, agentId, elementId);
```


Create the message you need to send, for example the '*SimpleCreateExampleRow*'.
```csharp
var simpleRequest = new SimpleCreateExampleRow
{
	ExampleData = new MyTableData
	{
		MyDiscreetColumn = DiscreetColumnOption.Discreet2,
		MyStringColumn = "Hello World!",
		MyNumericColumn = 1_000_000,
	},
};
```

Send you message to the element.
```csharp
var response = exampleElement.SendSingleResponseMessage(simpleRequest);
```


## About

An Example Connector API (Inter-App Calls/Messages) for DataMiner elements running the 'Skyline Example Connector InterApp Calls' connector.

### About DataMiner

DataMiner is a transformational platform that provides vendor-independent control and monitoring of devices and services. Out of the box and by design, it addresses key challenges such as security, complexity, multi-cloud, and much more. It has a pronounced open architecture and powerful capabilities enabling users to evolve easily and continuously.

The foundation of DataMiner is its powerful and versatile data acquisition and control layer. With DataMiner, there are no restrictions to what data users can access. Data sources may reside on premises, in the cloud, or in a hybrid setup.

A unique catalog of 7000+ connectors already exist. In addition, you can leverage DataMiner Development Packages to build you own connectors (also known as "protocols" or "drivers").

> **Note**
> See also: [About DataMiner](https://aka.dataminer.services/about-dataminer).

### About Skyline Communications

At Skyline Communications, we deal in world-class solutions that are deployed by leading companies around the globe. Check out [our proven track record](https://aka.dataminer.services/about-skyline) and see how we make our customers' lives easier by empowering them to take their operations to the next level.

<!-- Uncomment below and add more info to provide more information about how to use this package. -->
<!-- ## Getting Started -->
