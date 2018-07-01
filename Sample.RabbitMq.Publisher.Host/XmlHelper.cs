using System.Collections.Generic;
using System.IO;

namespace Sample.RabbitMq.Publisher.Host
{
    public partial class XmlHelper
    {
        public static List<Record> LoadData(string fileName, bool includeRandomData = false, int recordCount = 1000)
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var data = SerializerHelper.Load(fullPath);
            var types = new string[] { "green", "blue", "red" };

            if (includeRandomData)
            {
                var count = data.Count;
                for (int i = 1; i <= recordCount; i++)
                {
                    data.Add(new Record { Value = (count + i).ToString(), Type = types[RandomHelper.Get(0, 3, 10)] });
                }
            }

            return data;
        }
    }
}
