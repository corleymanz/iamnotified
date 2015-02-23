using System;
using System.Text;
using System.Threading.Tasks;
using IAmNotified.Common.Log;
using IAmNotified.IAmNotifiedService.Implementation.Handler;
using Implementation.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace IAmNotified.IAmNotifiedService.Implementation
{
    public class Controller
    {
        ILogger _log;
        ILogger Log
        {
            get
            {
                if (_log == null)
                {
                    _log = new LoggerFactory().GetLogger();
                }
                return _log;
            }
        }

        IHandler _handler;
        IHandler Handler
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new HandlerFactory().GiveHandler();
                }
                return _handler;
            }
        }

        public void Receive()
        {
            var queueName = Configuration.Settings.Instance.MailQueue;
            var rabbitmqHost = Configuration.Settings.Instance.RabbitmqServer;

            var factory = new ConnectionFactory() {HostName = rabbitmqHost};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queueName, false, consumer);

                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs) consumer.Queue.Dequeue();
                        try
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            // process async
                            Handler.Process(message);
                            // accept message
                            channel.BasicAck(ea.DeliveryTag, false);
                        }
                        catch (Exception ex)
                        {
                            // reject deliveriry and requeue
                            channel.BasicNack(ea.DeliveryTag, false, true);

                            string error = (ex.InnerException == null)
                                ? ex.Message
                                : ex.Message + Environment.NewLine + ex.InnerException.Message;

                            Log.Error(error);
                            Log.Error("message requeued");
                        }
                    }
                }
            }
        }
    }
}