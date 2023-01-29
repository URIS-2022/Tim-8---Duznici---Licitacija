using RabbitMQ.Client;

namespace Payment.API;

internal class MQConnection
{
    private readonly ConnectionFactory factory;
    public Exception? GetException { get; private set; }

    public MQConnection(IConfiguration configuration)
    {
        factory = new ConnectionFactory
        {
            UserName = configuration["RABBITMQ_USER"],
            Password = configuration["RABBITMQ_PASSWORD"],
            HostName = configuration["RABBITMQ_HOST"]
        };
    }

    public void Open(string clientProvidedName)
    {
        IConnection connection = factory.CreateConnection(clientProvidedName);
        _ = connection.CreateModel();
    }
}
