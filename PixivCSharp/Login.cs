using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace PixivCSharp
{
    public partial class PixivClient
    {
        public async Task<IllustSearchResult> WalkthoughIllustsAsync()
        {
            // Retrieves walkthrough illusts and converts to json, and then returns it as IllustSearchResult
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.WalkthroughIllusts).ConfigureAwait(false);
            string responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            IllustSearchResult result = Json.DeserializeJson<IllustSearchResult>(responseText);
            return result;
        }

        public async Task<EmojiList> EmojiListAsync()
        {
            // Retrieves emoji list, converts to json, and returns as search result object
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.GetEmoji).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            EmojiList result = json.ToObject<EmojiList>();
            return result;
        }

        // Login/refresh method
        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            // Parameter dictionary
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

            // Login request is sent, converted to json and returned
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.Login, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            LoginResponse result = json["response"].ToObject<LoginResponse>();
            SetTokens(result.AccessToken, result.RefreshToken, result.DeviceToken);
            return result;
            
          
        }

        public async Task<LoginResponse> RefreshLoginAsync()
        {
            // Parameter dictionary
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "client_id", "MOBrBDS8blbauoSck0ZfDbtuzpyT" },
                { "client_secret", "lsACyCD94FhDUtGTXi3QzcFE2uU1hqtDaKeqrdwj" },
                { "grant_type", "refresh_token" },
                { "refresh_token", RequestClient.refresh_token },
                { "device_token", RequestClient.device_token },
                { "secure_url", "true" },
                { "include_policy", "true" }
            };
            
            // Refresh request is sent, and new token is retrieved
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.Login, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            LoginResponse result = json["response"].ToObject<LoginResponse>();
            SetTokens(result.AccessToken, result.RefreshToken, result.DeviceToken);
            return result;
        }
    }
}