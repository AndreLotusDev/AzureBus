# BlazorRegisterNames

We have 3 projects:
- BlazorRegisterNames (In Blazor Server Side)
- BusShared (the common part between the publisher and consumer)
- ConsumeNames (The consumer in console .NET)

<hr/>

Steps:

<h3>Create a new azure bus resource</h3>
<img src="https://user-images.githubusercontent.com/54090940/172480757-b24f5049-35f9-4b82-ab96-1f97303dc062.png">

<h3>Select a subscription, resource group, configure a valid name, and a tier of pricing</h3>
<h3> To understand more about each tier and what he can give for us: https://azure.microsoft.com/pt-br/pricing/details/service-bus/</h3>
<img src="(https://user-images.githubusercontent.com/54090940/172480968-fa509a6e-17f3-4b11-9c68-72dcc6038cc6.png)">

<h3>Create a new queue to receive messages</h3>
<img src="(https://user-images.githubusercontent.com/54090940/172481297-1e397ebc-2834-4e60-9de2-e1fa8c257fbf.png)">

<h3>Configure infra inside of this queue</h3>
<h4>Select the size (how much messages this queue can gold)</h4>
<h4>Time to keep a message alive before dying</h4>
<h4>Lock duration to a message be consumed by only a consumer</h4>
<img src="(https://user-images.githubusercontent.com/54090940/172481457-032c5587-41fb-42dc-b2bc-14c13c4eef83.png)">

<h3>Configure a key with acess policies (for example one with send and listen) or can be two different keys (one for listen and one for send)</h3>
<h4>Copy the addess of endpoint and key</h4>
<img src="(https://user-images.githubusercontent.com/54090940/172481916-d2920d3f-37e1-496a-8fd9-dd6509afca8d.png)">

<h3>Use the endpoint address in appsettings.json in the BLAZOR UI, and paste too in the program.cs the endpoint</h3>
<img src="(https://user-images.githubusercontent.com/54090940/172482148-99bcbbf3-2126-4f8e-be34-b7b256e8a7cf.png)">
<img src="(https://user-images.githubusercontent.com/54090940/172482161-e707f94d-da93-434a-9964-6a08680eed7a.png)">


