using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PixivCSharp
{
    static class Json
    {
        public static T DeserializeJson<T>(string json)
        {
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}