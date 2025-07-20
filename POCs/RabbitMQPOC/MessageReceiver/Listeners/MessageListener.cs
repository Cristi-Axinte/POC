using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessageReceiver.Listeners
{
    public class MessageListener : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqps://ccmrifpm:RDHZMrGq7wN7GLsU00G-C58HWqONv6jp@cow.rmq2.cloudamqp.com/ccmrifpm"), //CLOUD RABBITMQ SEVER
                Ssl = new SslOption
                {
                    Enabled = true,
                    ServerName = "cow.rmq2.cloudamqp.com",
                    AcceptablePolicyErrors = System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors |
                                 System.Net.Security.SslPolicyErrors.RemoteCertificateNameMismatch
                }
            }; 
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "rabbitPOC",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[Receiver] Received: {message}");

                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(queue: "rabbitPOC",
                                 autoAck: true,
                                 consumer: consumer);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}