using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    internal class SerialiseBinary : ISerialise
    {
        public void SerialiseToFile<T>(string filePath, T item)
        {
            FileStream fileStream = File.Create(filePath);
            BinaryFormatter writer = new();
            writer.Serialize(fileStream, item);
            fileStream.Close();
        }

        public T DeserialiseFromFile<T>(string filePath)
        {
            Stream fileStream = File.OpenRead(filePath);
            BinaryFormatter reader = new();
            var deserialisedItem = (T)reader.Deserialize(fileStream);
            fileStream.Close();
            return deserialisedItem;
        }

    }
}
