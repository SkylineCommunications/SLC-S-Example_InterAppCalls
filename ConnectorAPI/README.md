# Skyline.DataMiner.ConnectorAPI.SkylineCommunications.ExampleConnectorInterAppCalls

The ConnectorAPI Example NuGet package demonstrates best practices for creating a connector API. This package provides a robust framework of classes designed to facilitate interaction with various connectors, serving as a template for developers looking to implement their own connector APIs efficiently and effectively.

## Considerations
- **Best Practices**: When building a NuGet package, it's best practice to avoid exposing any classes from external libraries, such as the InterApp Library. This prevents potential versioning issues. In this example package, no public methods or properties use arguments or return types from the InterApp Library to ensure compatibility and stability.
- **Error Handling**: When building a ConnectorAPI, it's important to carefully consider error handling. In this example, responses should inherit from the IExampleResponse interface, which includes two properties: a boolean Success and a string Description. These properties can be used to provide meaningful error messages when something goes wrong.
- **Documentation**: Thoroughly documented classes and methods to aid developers in understanding and utilizing the package effectively.

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
