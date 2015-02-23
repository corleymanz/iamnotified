using System;
using System.Text;
using System.Threading.Tasks;
using IAmNotified.Common.Log;
using IAmNotified.IAmNotifiedService.Implementation.Handler;
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
            var queueName = "MailQueue";
            var rabbitmqHost = "localhost";

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
                        channel.BasicAck(ea.DeliveryTag, false);
                        try
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            // process async
                            Handler.Process(message);
                        }
                        catch (Exception ex)
                        {
                            string error = (ex.InnerException == null)
                                ? ex.Message
                                : ex.Message + Environment.NewLine + ex.InnerException.Message;
                            
                            Log.Error(error);
                        }
                    }
                }
            }
        }
    }
}
