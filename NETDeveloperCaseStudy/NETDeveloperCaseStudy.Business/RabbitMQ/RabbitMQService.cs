using RabbitMQ.Client;
using System.Text.Json;

namespace NETDeveloperCaseStudy.Business.RabbitMQ;
public class RabbitMQService
{
    private readonly ConnectionFactory _factory;
    private IConnection _connection;

    public RabbitMQService()
    {
        _factory = new() { Uri = new("amqps://bptqqzds:qnNQsG7XhpHVnPTs1-H5wc6EhdVRjofw@fish.rmq.cloudamqp.com/bptqqzds") };
        _connection = CreateConnection();
    }
    public IModel CreateChannel()
    {
        if (_connection == null || !_connection.IsOpen)
        {
            _connection = CreateConnection();
        }
        return _connection.CreateModel();
    }
    public IConnection CreateConnection(int retryCount = 3, TimeSpan retryDelay = default)
    {
        if (retryDelay == default)
            retryDelay = TimeSpan.FromSeconds(10);
        for (int i = 0; i < retryCount; i++)
        {
            try
            {
                return _factory.CreateConnection();
            }
            catch (Exception)
            {
                if (i < retryCount - 1)
                    Task.Delay(retryDelay).Wait();
            }
        }
        throw new Exception("RabbitMQ bağlantısı kurulamadı.");

    }
    public async Task SendMessage(string queueName, object message)
    {
        await Task.Run(() =>
        {
            using (var connection = CreateConnection())
            using (var channel = CreateChannel())
            {
                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                IBasicProperties basicProperties = channel.CreateBasicProperties();
                basicProperties.Persistent = true;
                var messageBody = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(messageBody);

                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties, body: body);
            }
        });
    }
}
