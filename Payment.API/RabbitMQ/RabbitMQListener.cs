
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using Payment.API.Models.PaymentWarrantModel;
using System.Threading.Channels;

namespace Payment.API.RabbitMQ;

public class RabbitMQListener : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly EventingBasicConsumer _consumer;
    private readonly string queueName;

    public RabbitMQListener(string hostName, string queueName, string userName, string password)
    {
        this.queueName = queueName;

        var factory = new ConnectionFactory
        {
            HostName = hostName,
            UserName = userName,
            Password = password
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        _channel.ExchangeDeclare("my_exchange", ExchangeType.Direct);
        _channel.QueueBind(queueName, "my_exchange", "payment");
        _consumer = new EventingBasicConsumer(_channel);
    }

    public async Task StartListening(Action<string> handleMessage)
    {

       _consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);
            Console.WriteLine("Received message: {0}", json);
            var message = JsonSerializer.Deserialize<ConsumerMessageFormatPayment>(json);
            


            Random random = new Random();
            string referenceNumber = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 9)
          .Select(s => s[random.Next(s.Length)]).ToArray());



            PaymentWarrantRequestModel paymentWarrentPostRequestModel = new PaymentWarrantRequestModel()
            {
                ReferenceNumber = referenceNumber,
                PayerGuid = Guid.NewGuid(),
                TotalAmount = message.auctionedPrice,
                PublicBiddingGuid = message.Guid
            

            };

           

        

            var requester = new Requester();
            await requester.PostNewPaymentWarrant(paymentWarrentPostRequestModel);

            _channel.BasicAck(ea.DeliveryTag, false);
        };
        _channel.BasicConsume(queue: queueName, autoAck: false, consumer: _consumer);
    }

    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}

