using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    static class Json
    {
        public static T DeserializeJson<T>(string json)
        {
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        public static T DeserializeJson<T>(JObject json)
        {
            T result = json.ToObject<T>();
            return result;
        }

        public static T DeserializeJson<T>(JArray json)
        {
            T result = json.ToObject<T>();
            return result;
        }
    }
}