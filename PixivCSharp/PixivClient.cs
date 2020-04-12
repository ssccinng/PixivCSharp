using System;
using System.Net.Http;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        private WebRequests RequestClient;
        private TimeZoneInfo JapanTimeZone;

        // Creates instance of WebRequests
        public PixivClient(string filterSetting = "for_android")
        {
            RequestClient = new WebRequests();
            Filter = filterSetting;
            JapanTimeZone = TZConvert.GetTimeZoneInfo("Tokyo Standard Time");
        }
        
        // Sets access tokens
        public void SetTokens(string access, string refresh, string device)
        {
            RequestClient.access_token = access;
            RequestClient.refresh_token = refresh;
            RequestClient.device_token = device;
        }

        private string _Filter = "for_android";

        public string Filter
        {
            get => _Filter;
            set
            {
                if (value == "for_android" || value == "for_ios" || value == "none") { _Filter = value; }
            }
        }

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

        public async Task<T> RequestAsync<T>(string urlString,  string type = "GET", bool authReqired = true,
            bool multipart = false)
        {
            URL url = new URL()
            {
                Address = urlString,
                Type = type,
                AuthRequired = authReqired,
                Multipart = multipart
            };

            HttpResponseMessage response = await RequestClient.RequestAsync(url).ConfigureAwait(false);
            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            T result = Json.DeserializeJson<T>(responseContent);
            return result;
        }
    }
}