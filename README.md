# AzureBus

This repository is a simple Azure Service Bus sample built with .NET 5. It shows how to publish messages from a Blazor Server UI and consume them from a console application.

> `Windows.Azure.Bus` is deprecated. Prefer the `Azure.Bus` package for newer implementations. This sample still demonstrates the same messaging concept and overall workflow.

## Solution overview

The solution contains three projects:

- **BlazorRegisterNames**: Blazor Server UI used to submit names.
- **BusShared**: shared models and queue publishing service.
- **ConsumeNames**: console consumer that reads messages from the queue.

## Message flow

1. A user fills in the form in the Blazor app.
2. The app serializes the `PersonModel` payload.
3. The payload is sent to the `personstoregister` Azure Service Bus queue.
4. The console app listens to the same queue and prints the received name.

## Prerequisites

- .NET 5 SDK
- An Azure subscription
- An Azure Service Bus namespace with a queue

## Azure Service Bus setup

Follow the steps below to create the required Azure resources.

### 1. Create a new Azure Service Bus resource

<img src="https://user-images.githubusercontent.com/54090940/172480757-b24f5049-35f9-4b82-ab96-1f97303dc062.png">

### 2. Choose subscription, resource group, name, and pricing tier

Pick a valid namespace name and the pricing tier that matches your needs.

More details about tiers: https://azure.microsoft.com/pt-br/pricing/details/service-bus/

<img src="https://user-images.githubusercontent.com/54090940/172480968-fa509a6e-17f3-4b11-9c68-72dcc6038cc6.png">

### 3. Create a queue for the messages

Create the queue that will receive the messages sent by the Blazor app.

<img src="https://user-images.githubusercontent.com/54090940/172481297-1e397ebc-2834-4e60-9de2-e1fa8c257fbf.png">

### 4. Configure the queue

Review the main queue settings:

- **Queue size**: how many messages the queue can hold.
- **Message time to live**: how long a message remains valid before expiring.
- **Lock duration**: how long a message stays locked while a consumer is processing it.

<img src="https://user-images.githubusercontent.com/54090940/172481457-032c5587-41fb-42dc-b2bc-14c13c4eef83.png">

### 5. Create an access policy and copy the connection details

You can create:

- one shared key with **Send** and **Listen** permissions, or
- separate keys for sender and consumer applications.

Copy the Service Bus connection string from the policy you want to use.

<img src="https://user-images.githubusercontent.com/54090940/172481916-d2920d3f-37e1-496a-8fd9-dd6509afca8d.png">

## Local configuration

Both applications must point to the same Service Bus namespace and queue.

### Blazor application

From the repository root, update `BlazorRegisterNames/appsettings.json`:

```json
"ConnectionStrings": {
  "AzureServiceBus": "<your-service-bus-connection-string>"
}
```

The UI publishes messages to the queue named `personstoregister`.

### Console consumer

From the repository root, update `ConsumeNames/Program.cs`:

- `connectionString`: your Azure Service Bus connection string
- `queueName`: the same queue used by the Blazor app, such as `personstoregister`

<img src="https://user-images.githubusercontent.com/54090940/172482148-99bcbbf3-2126-4f8e-be34-b7b256e8a7cf.png">
<img src="https://user-images.githubusercontent.com/54090940/172482161-e707f94d-da93-434a-9964-6a08680eed7a.png">

## Running the sample

### Start the Blazor app

Run the web project:

```bash
dotnet run --project BlazorRegisterNames/BlazorRegisterNames.csproj
```

### Start the consumer

Run the console project in another terminal:

```bash
dotnet run --project ConsumeNames/ConsumeNames.csproj
```

### Test the flow

1. Open the Blazor UI.
2. Submit a first name and last name.
3. Confirm that the consumer prints the received message in the console.

## Relevant implementation files

- `BlazorRegisterNames/Pages/Index.razor`
- `QueueService` implementation in `BusShared/Service/QuerService.cs`
- `ConsumeNames/Program.cs`
