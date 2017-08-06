using System.IO;
using Newtonsoft.Json;

namespace NeXt.Extensions.Json
{
    public static class JsonExtensions
    {
        public static string SerializeToString(this JsonSerializer self, object obj)
        {
            using (var strwr = new StringWriter())
            using (var writer = new JsonTextWriter(strwr))
            {
                self.Serialize(writer, obj);
                return strwr.ToString();
            }
        }

        public static T Deserialize<T>(this JsonSerializer self, string value)
        {
            using (var reader = new JsonTextReader(new StringReader(value)))
            {
                return self.Deserialize<T>(reader);
            }
        }
    }
}