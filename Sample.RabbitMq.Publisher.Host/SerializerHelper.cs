using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Sample.RabbitMq.Publisher.Host
{
    public class SerializerHelper
    {
        public static List<Record> Load(string fileName)
        {
            var document = XDocument.Load(fileName);

            var records = document.Descendants().Elements("record")
                .Select(x => new Record { Value = x.Attribute("value").Value, Type = x.Attribute("type").Value })
                .ToList();

            return records;

        }
    }
}
