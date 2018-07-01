using EasyNetQ;
using EasyNetQ.Topology;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.RabbitMq.Subscriber.Host
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("Usage: {0} [type]", Environment.GetCommandLineArgs()[0]);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
                Environment.ExitCode = 1;
                return;
            }

            try
            {
                try
                {
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[0], true);
                }
                catch { }

                Console.Error.WriteLine("Consumer listening...");
                Console.Error.WriteLine("Type={0}", args[0]);

                var rountingKey = args[0];
                var advancedBus = RabbitHutch.CreateBus(AppKeys.Get(Constants.RabbitMqConnectionString)).Advanced;
                var exchange = advancedBus.ExchangeDeclare(AppKeys.Get(Constants.RabbitMqExchangeName), ExchangeType.Direct);
                var queue = advancedBus.QueueDeclare(string.Format("FirstScreen.Queue.{0}", rountingKey));
                advancedBus.Bind(exchange, queue, rountingKey);

                advancedBus.Consume(queue, (body, properties, info) => Task.Factory.StartNew(() =>
                {
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("{0}", message);
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error...");
                Console.WriteLine(ex.Message);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadKey();
                Environment.ExitCode = 1;
                return;
            }
        }
    }
}
