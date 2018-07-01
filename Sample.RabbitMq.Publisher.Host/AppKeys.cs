using System.Configuration;

namespace Sample.RabbitMq.Publisher.Host
{
    public class AppKeys
    {
        public static string Get(string key) => ConfigurationManager.AppSettings[key].ToString();
    }
}
