using System;
using System.Threading;

namespace Sample.RabbitMq.Publisher.Host
{
    public class RandomHelper
    {
        public static int Get(int min, int max, int delayInMilliSeconds = 0)
        {
            Thread.Sleep(delayInMilliSeconds);
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
