using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETDeveloperCaseStudy.Dtos.RabbitMQMessage;
using RabbitMQ.Client.Events;
using System.Text.Json;

namespace NETDeveloperCaseStudy.Business.RabbitMQ;
/// <summary>
/// uygulama ayağa kalktığı anda buradaki consumer sürekli tetiklenecek ve kuyruğa gelen mesejlar varsa burada tüketilerek kullanıcıya mail ile bu mesajları dönme işlemini yapacaktır.İstek iptal edilene kadar ya da uygulama sonlandırılana kadar bu döngü arkaplanda tetiklenecektir.
/// </summary>
public class RabbitMQEmailWorker : BackgroundService
{
    private readonly RabbitMQService _rabbitMQService;
    private readonly IServiceProvider _serviceProvider;

    public RabbitMQEmailWorker(RabbitMQService rabbitMQService, IServiceProvider serviceProvider)
    {
        _rabbitMQService = rabbitMQService;
        _serviceProvider = serviceProvider;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            using (var connection = _rabbitMQService.CreateConnection())
            using (var channel = _rabbitMQService.CreateChannel())
            {
                channel.QueueDeclare(queue: "orderEmail_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(queue: "orderEmail_queue", autoAck: false, consumerTag: "", noLocal: false, exclusive: false, arguments: null, consumer: consumer);
                consumer.Received += async (model, e) =>
                {
                    var body = e.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var emailData = JsonSerializer.Deserialize<RabbitMessageDto>(message);
                    if (emailData?.ToEmail is not null && emailData.ShoppingCartDetailList.Any())
                    {
                        using (var scope = _serviceProvider.CreateScope())
                        {
                            try
                            {
                                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                                await emailService.SendOrderEmailAsync(emailData!.ToEmail, emailData.ShoppingCartDetailList!);
                                channel.BasicAck(e.DeliveryTag, false);
                            }
                            catch (Exception)
                            {
                                channel.BasicNack(e.DeliveryTag, false, true);
                            }                           
                        }                      
                    }
                };
                try
                {
                    await Task.Delay(Timeout.Infinite, stoppingToken);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
             
            }
        }
    }

}
