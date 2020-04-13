using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace PixivCSharp
{
    public partial class PixivClient
    {
        public async Task<IllustSearchResult> WalkthoughIllustsAsync()
        {
            // Retrieves walkthrough illusts and converts to json, and then returns it as IllustSearchResult
            Stream response;
            response = await RequestClient.RequestAsync(PixivUrls.WalkthroughIllusts).ConfigureAwait(false);
            return Json.DeserializeJson<IllustSearchResult>(response);
        }

        public async Task<EmojiList> EmojiListAsync()
        {
            // Retrieves emoji list, converts to json, and returns as search result object
            Stream response;
            response = await RequestClient.RequestAsync(PixivUrls.GetEmoji).ConfigureAwait(false);
            return Json.DeserializeJson<EmojiList>(response);
        }

        // Login/refresh method
        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            // Parameter dictionary
            Stream response;
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
            response = await RequestClient.RequestAsync(PixivUrls.Login, encodedParams).ConfigureAwait(false);
            LoginResponse result = Json.DeserializeJson<LoginResponse>(response, "response");
            SetTokens(result.AccessToken, result.RefreshToken, result.DeviceToken);
            return result;
        }

        public async Task<LoginResponse> RefreshLoginAsync()
        {
            // Parameter dictionary
            Stream response;
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
            response = await RequestClient.RequestAsync(PixivUrls.Login, encodedParams).ConfigureAwait(false);
            LoginResponse result = Json.DeserializeJson<LoginResponse>(response, "response");
            SetTokens(result.AccessToken, result.RefreshToken, result.DeviceToken);
            return result;
        }
    }
}