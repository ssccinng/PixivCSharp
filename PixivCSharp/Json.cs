using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    internal static class Json
    {
        public static T DeserializeJson<T>(Stream json)
        {
            using (StreamReader sr = new StreamReader(json))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(reader);
            }
        }

        public static T DeserializeJson<T>(Stream json, string target)
        {
            using (StreamReader reader = new StreamReader(json))
            {
                JObject jObject = JObject.Parse(reader.ReadToEnd());
                return jObject[target].ToObject<T>();
            }
        }
    }
}