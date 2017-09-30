using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Aytass.LiteDbOutputCache
{
    internal class BinarySerializer
    {
        public static object Deserialize(byte[] serializedEntry)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream(serializedEntry);

            return formatter.Deserialize(stream);
        }

        public static byte[] Serialize(object entry)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, entry);

            return stream.ToArray();
        }
    }
}