using System.Configuration;

namespace Sample.RabbitMq.Subscriber.Host
{
    public class AppKeys
    {
        public static string Get(string key) => ConfigurationManager.AppSettings[key].ToString();
    }
}
