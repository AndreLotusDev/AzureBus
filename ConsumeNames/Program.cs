using BusShared.Models;
using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumeNames
{
    public class Program
    {
        const string connectionString = "";
        const string queueName = "";
        private static IQueueClient queueClient;

        public static async Task Main(string[] args)
        {
            queueClient = new QueueClient(connectionString, queueName);

            var messageHandlerOptions = new MessageHandlerOptions(exceptionReceivedHandler: ExceptionReceivedHandler)
            { 
                AutoComplete = false,
            };

            queueClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);

            Console.ReadLine();

            await queueClient.CloseAsync();
        }

        private static async Task ProcessMessageAsync(Message message, CancellationToken arg2)
        {
            var jsonString = Encoding.UTF8.GetString(message.Body);
            PersonModel personModel = JsonSerializer.Deserialize<PersonModel>(jsonString);
            Console.WriteLine($"New person registered: {personModel.FirstName} {personModel.LastName}");

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"Error consuming the message: {arg.Exception}");
            return Task.CompletedTask;
        }
    }
}
