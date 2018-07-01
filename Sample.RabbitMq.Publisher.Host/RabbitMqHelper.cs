using EasyNetQ;
using EasyNetQ.Topology;

namespace Sample.RabbitMq.Publisher.Host
{
    public class RabbitMqHelper
    {
        public static void SetupRabbitMq(out IAdvancedBus advancedBus, out IExchange exchange)
        {
            advancedBus = RabbitHutch.CreateBus(AppKeys.Get(Constants.RabbitMqConnectionString)).Advanced;
            exchange = advancedBus.ExchangeDeclare(AppKeys.Get(Constants.RabbitMqExchangeName), ExchangeType.Direct);
        }
    }
}
