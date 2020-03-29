using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        public async Task<UserDetail> ViewProfile(string UserID, string filter = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            
            FormUrlEncodedContent encodedParameters = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.ViewProfile, encodedParameters)
                .ConfigureAwait(false);

            UserDetail result =
                Json.DeserializeJson<UserDetail>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return result;
        }
    }
}