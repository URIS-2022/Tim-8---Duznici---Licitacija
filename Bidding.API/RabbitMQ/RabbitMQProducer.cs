using Bidding.API.Entities;
using Bidding.API.RabbitMQ;
using Newtonsoft.Json;
using RabbitMQ.Client;
using ServiceStack.Messaging;
using System;
using System.Text;

namespace Bidding.API.RabbitMQ;
public class RabbitMQMessageProducer : IMessageProducer
{
    private IConnection _connection;
    private IModel _channel;
    

    public RabbitMQMessageProducer(string hostname, string queueName)
    {

        var _queueName = queueName;
        
        // Create a connection factory
        var factory = new ConnectionFactory() { HostName = hostname };

        // Create a new connection to the message broker
        _connection = factory.CreateConnection();

        // Create a channel for sending and receiving messages
        _channel = _connection.CreateModel();

        // Declare a queue to send and receive messages
        _channel.QueueDeclare(queue: _queueName,
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null); 
    }

    public void Publish<T>(T messageBody)
    {

        string json = JsonConvert.SerializeObject(messageBody);
        var body = Encoding.UTF8.GetBytes(json);

        // Publish the message to the queue
        _channel.BasicPublish(exchange: "my_exchange",
                              routingKey: "lease",
                              basicProperties: null,
                              body: body);

        Console.WriteLine("Message sent to MQ");
    }
    public void Publish(ProducerMessageFormatPayment message)
    {

        string json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        // Publish the message to the queue
        _channel.BasicPublish(exchange: "my_exchange",
                              routingKey: "payment",
                              basicProperties: null,
                              body: body);

        Console.WriteLine("Message sent to MQ");
    }
    public void Publish<T>(IMessage<T> messageBody)
    {
        throw new NotImplementedException();
    }
    public void Dispose()
    {
        _channel.Dispose();
        _connection.Dispose();
    }

    
}
