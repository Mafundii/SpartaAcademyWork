using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialisationApp
{
    internal class SerialiseXML : ISerialise
    {
        public T DeserialiseFromFile<T>(string filePath)
        {
            FileStream fileStream = File.OpenRead(filePath);
            XmlSerializer reader = new XmlSerializer(typeof(T));
            var DeserializedItem = reader.Deserialize(fileStream);
            fileStream.Close();
            return (T)DeserializedItem;
        }

        public void SerialiseToFile<T>(string filePath, T item)
        {
            FileStream fileStream = File.Create(filePath);
            //Create XML Serializer
            XmlSerializer writer = new XmlSerializer(typeof(T));
            writer.Serialize(fileStream, item);
            fileStream.Close();
        }
    }
}
