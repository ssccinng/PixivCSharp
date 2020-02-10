using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        public AuthClass Auth;
        public PixivClient()
        {
            WebRequests.ClientInit();
            Auth = new AuthClass();
        }
        
        public async Task<IllustSearchResult> WalkthoughIllusts()
        {
            //Retrieves walkthrough illusts and converts to json, and then returns it as IllustSearchResult
            HttpResponseMessage response = await WebRequests.Request(PixivUrls.WalkthroughIllusts);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());
            IllustSearchResult result = json.ToObject<IllustSearchResult>();
            return result;
        }

        public async Task<EmojiList> EmojiList()
        {
            //Retrieves emoji list, converts to json, and returns as search result object
            HttpResponseMessage response = await WebRequests.Request(PixivUrls.GetEmoji);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());
            EmojiList result = json.ToObject<EmojiList>();
            return result;
        }

        public class AuthClass
        {
            //Login parameters
            public const string client_id = "MOBrBDS8blbauoSck0ZfDbtuzpyT";
            private const string client_secret = "lsACyCD94FhDUtGTXi3QzcFE2uU1hqtDaKeqrdwj";
            private const string secure_url = "true";
            private const string include_policy = "true";
            private static string refresh_token = String.Empty;
            private static string device_token = String.Empty;

            public async Task<LoginResponse> RefreshLogin(string username, string password)
            {
                if (refresh_token == String.Empty)
                {
                    //Dictionary containing parameters
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "client_id", client_id },
                        { "client_secret", client_secret},
                        { "grant_type", "password"},
                        { "username", username},
                        { "password", password},
                        { "device_token", "pixiv"},
                        { "secure_url", secure_url},
                        { "include_policy", include_policy}
                    };
                    
                    //Login request is sent, converted to json and returned
                    FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
                    HttpResponseMessage response = await WebRequests.Request(PixivUrls.Login, encodedParams);
                    JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());
                    LoginResponse result = json["response"].ToObject<LoginResponse>();
                    return result;
                }

                return null;
            }
        }
    }
}