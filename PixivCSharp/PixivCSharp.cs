using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public class Pixiv
    {
        public Pixiv()
        {
            WebRequests.ClientInit();
        }
        public IllustSearchResult WalkthoughIllusts()
        {
            //Retrieves walkthrough illusts and converts to json
            IllustSearchResult result = new IllustSearchResult();
            string response = WebRequests.Request(PixivUrls.WalkthroughIllusts).Result;
            JObject json = JObject.Parse(response);
            JArray illusts = (JArray)json["illusts"];

            //converts json to IllustSearchResults object and returns object
            foreach (JToken illust in illusts)
            {
                Illust newIllust = (illust.ToObject<Illust>());
                result.illusts.Add(newIllust);
            }
            result.next_url = (string)json["next_url"];
            return result;
        }
    }
    
    class Auth
    {
        
    }
}