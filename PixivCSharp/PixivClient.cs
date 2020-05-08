using System.IO;
using System.Threading.Tasks;

namespace PixivCSharp
{
    /// <summary>
    /// A client client for the Pixiv android API. More information can be found at https://github.com/An-Owlbear/Pixiv-API-Docs
    /// </summary>
    public partial class PixivClient
    {
        private WebRequests RequestClient;

        /// <summary>
        /// Creates an instance of the Pixiv Client
        /// </summary>
        /// <param name="filterSetting">the default settings for the filter. 'none', 'for_android' or 'for_ios'.</param>
        public PixivClient(FilterType filter = FilterType.Android)
        {
            RequestClient = new WebRequests();
            Filter = filter;
        }
        
        /// <summary>
        /// Sets the access tokens.
        /// </summary>
        /// <param name="access">The access token.</param>
        /// <param name="refresh">The refresh token.</param>
        /// <param name="device">The device token.</param>
        public void SetTokens(string access, string refresh, string device)
        {
            RequestClient.access_token = access;
            RequestClient.refresh_token = refresh;
            RequestClient.device_token = device;
        }

        private FilterType Filter { get; set; }

        /// <summary>
        /// Checks whether the tokens are set.
        /// </summary>
        public bool CheckTokens()
        {
            if (RequestClient.access_token == null || RequestClient.refresh_token == null ||
                RequestClient.device_token == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sends a generic request. Used for retrieving the result of NextURL fields.
        /// </summary>
        /// <param name="urlString">The URL to retrieve.</param>
        /// <param name="type">The type of request to send, can be 'POST' or 'GET'.</param>
        /// <param name="authReqired">Whether authorisation tokens are required.</param>
        /// <param name="multipart">Whether the parameters are sent as multipart data.</param>
        /// <typeparam name="T">The type to return.</typeparam>
        public async Task<T> RequestAsync<T>(string urlString,  string type = "GET", bool authReqired = true,
            bool multipart = false)
        {
            Stream response;
            URL url = new URL()
            {
                Address = urlString,
                Type = type,
                AuthRequired = authReqired,
                Multipart = multipart
            };

            response = await RequestClient.RequestAsync(url).ConfigureAwait(false);
            return Json.DeserializeJson<T>(response);
        }
    }
}