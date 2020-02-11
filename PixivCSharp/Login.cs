using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        //Access tokens
        private string access_token = string.Empty;
        private string refresh_token = string.Empty;
        private string device_token = string.Empty;

        public PixivClient()
        {
            WebRequests.ClientInit();
        }

        public bool CheckTokens()
        {
            if (access_token == null || refresh_token == null || device_token == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Sets access tokens
        private void setTokens(string access, string refresh, string device)
        {
            access_token = access;
            refresh_token = refresh;
            device_token = device;
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

        //Login/refresh method
        public async Task<LoginResponse> Login(string username, string password)
        {
            //Parameter dictionary
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "client_id", "MOBrBDS8blbauoSck0ZfDbtuzpyT" },
                { "client_secret", "lsACyCD94FhDUtGTXi3QzcFE2uU1hqtDaKeqrdwj" },
                { "grant_type", "password" },
                { "username", username },
                { "password", password },
                { "device_token", "pixiv" },
                { "secure_url", "true" },
                { "include_policy", "true" }
            };

            //Login request is sent, converted to json and returned
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await WebRequests.Request(PixivUrls.Login, encodedParams);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());
            LoginResponse result = json["response"].ToObject<LoginResponse>();
            setTokens(result.access_token, result.refresh_token, result.device_token);
            return result;
            
          
        }

        public async Task<LoginResponse> RefreshLogin()
        {
            //Parameter dictionary
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "client_id", "MOBrBDS8blbauoSck0ZfDbtuzpyT" },
                { "client_secret", "lsACyCD94FhDUtGTXi3QzcFE2uU1hqtDaKeqrdwj" },
                { "grant_type", "refresh_token" },
                { "refresh_token", refresh_token },
                { "device_token", device_token },
                { "secure_url", "true" },
                { "include_policy", "true" }
            };
            
            //Refresh request is sent, and new token is retrieved
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await WebRequests.Request(PixivUrls.Login, encodedParams);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());
            LoginResponse result = json["response"].ToObject<LoginResponse>();
            setTokens(result.access_token, result.refresh_token, result.device_token);
            return result;
        }
    }
}