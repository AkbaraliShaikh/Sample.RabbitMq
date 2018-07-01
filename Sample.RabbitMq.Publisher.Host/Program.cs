using EasyNetQ;
using EasyNetQ.Topology;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.RabbitMq.Publisher.Host
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool _isFast = true;
            if (args.Length > 0)
            {
                if (args[0] == "slow") _isFast = false;
            }
            try
            {
                Console.WriteLine("Loading data, Please wait...");

                List<Record> recods = XmlHelper.LoadData(AppKeys.Get(Constants.InputFileName),
                    true, Convert.ToInt32(AppKeys.Get(Constants.RandomDataCount))); // if true, will load file records + random data with specified max rows.

                RabbitMqHelper.SetupRabbitMq(out IAdvancedBus advancedBus, out IExchange exchange);

                Console.WriteLine("Publisher is ready...");
                Console.WriteLine(" Press [enter] to start.");
                Console.ReadKey();

                Parallel.ForEach(recods, x =>
                 {
                     if (!_isFast) Thread.Sleep(TimeSpan.FromSeconds(1));

                     Console.WriteLine("Published: {0} - {1}", x.Value, x.Type);
                     var message = new Message<string>(x.Value);
                     advancedBus.Publish<string>(exchange, x.Type, false, message);
                 });

                advancedBus.Dispose();

                Console.WriteLine("Published all the data...");
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadKey();
                Environment.ExitCode = 1;
                return;
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
