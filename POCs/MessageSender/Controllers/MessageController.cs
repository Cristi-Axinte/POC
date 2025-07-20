using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace MessageSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        [HttpPost("sendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] string message)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqps://ccmrifpm:RDHZMrGq7wN7GLsU00G-C58HWqONv6jp@cow.rmq2.cloudamqp.com/ccmrifpm"), //CLOUD RABBITMQ SEVER
                Ssl = new SslOption
                {
                    Enabled = true,
                    AcceptablePolicyErrors = System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors |
                             System.Net.Security.SslPolicyErrors.RemoteCertificateNameMismatch
                }
            };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "rabbitPOC",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);
            BasicProperties props = new BasicProperties(); 

            await channel.BasicPublishAsync(
                                 exchange: "",
                                 routingKey: "rabbitPOC",
                                 mandatory: true,
                                 basicProperties: props,
                                 body: body);

            return Ok($"Message sent: {message}");
        }
    }
}
