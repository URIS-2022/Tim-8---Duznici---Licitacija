using Lease.API.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Threading.Channels;
using Microsoft.AspNetCore.Connections;
using System.Text.Json;

namespace Lease.API.Controllers
{
    public class MQManager
    {
        private IConnection _connection;
        private IModel _channel;

        public MQManager()
        {
            // Create a connection factory
            var factory = new ConnectionFactory() { HostName = "localhost" };

            // Create a new connection to the message broker
            _connection = factory.CreateConnection();

            // Create a channel for sending and receiving messages
            _channel = _connection.CreateModel();

            // Declare a queue to send and receive messages
            _channel.QueueDeclare(queue: "my_queue",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);


            //declare Exchange
            _channel.ExchangeDeclare(exchange: "my_exchange",
                        type: ExchangeType.Direct,
                        durable: false,
                        autoDelete: false,
                        arguments: null);

            // Bind the queue to the exchange
            _channel.QueueBind(queue: "my_queue",
                              exchange: "my_exchange",
                              routingKey: "my_routing_key");






        }

        public byte[] SerializeObjectToBytes(object obj)
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return ms.ToArray();
            }
        }

        public Object DeserializeBytesToPublicBidding(byte[] bytes)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Object));
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return (Object)serializer.ReadObject(ms);
            }
        }
        public void SendMessage(LeaseAgreement message)
        {
            // Create a message to send
            var body = this.SerializeObjectToBytes(message);

            // Publish the message to the queue
            _channel.BasicPublish(exchange: "",
                                  routingKey: "my_queue",
                                  basicProperties: null,
                                  body: body);

            Console.WriteLine("Updated Lease Agreement with guid {guid} entity sent to MQ", message.Guid);
        }

        public void ConsumeMessage()
        {



            var consumer = new EventingBasicConsumer(_channel);

            // Deserialize message and put to the queue
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var jsonString = Encoding.UTF8.GetString(body);
                var dynamicObject = JsonSerializer.Deserialize<dynamic>(jsonString);
                Console.WriteLine("Received PublicBidding with guid: {Guid}", dynamicObject["Guid"]);
            };


            // Start consuming messages from the queue
            _channel.BasicConsume(queue: "my_queue",
                                  autoAck: true,
                                  consumer: consumer);




        }

    }
}
