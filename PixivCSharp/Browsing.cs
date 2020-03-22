using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        // Gets a list of new illusts
        public async Task<IllustSearchResult> NewIllustsAsync(string ContentType, string filter = null)
        {
            Dictionary<string ,string> parameters = new Dictionary<string, string>()
            {
                { "content_type", ContentType }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            
            // Encodes parameters and sends request
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.NewIllusts, encodedParams)
                .ConfigureAwait(false);
            
            // Converts response into an object and returns
            IllustSearchResult result =
                Json.DeserializeJson<IllustSearchResult>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            return result;
        }
        
        // Gets a list of new illusts from followed account
        public async Task<IllustSearchResult> NewFollowIllustsAsync(string restrict = "all")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "restrict", restrict}
            };
            
            // Encodes parameters and sends request
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.NewFollowIllusts, encodedParams)
                .ConfigureAwait(false);
            
            // Converts response into an object and returns
            IllustSearchResult result =
                Json.DeserializeJson<IllustSearchResult>(await response.Content.ReadAsStringAsync()
                    .ConfigureAwait(false));
            return result;
        }
        
        // Gets a list of new illusts from users added to my pixiv
        public async Task<IllustSearchResult> NewMyPixivIllustsAsync()
        {
            // Sends request
            HttpResponseMessage response =
                await RequestClient.RequestAsync(PixivUrls.NewMyPixivIllusts).ConfigureAwait(false);

            // Converts response into an object and returns
            IllustSearchResult result =
                Json.DeserializeJson<IllustSearchResult>(await response.Content.ReadAsStringAsync()
                    .ConfigureAwait(false));
            return result;
        }
    }
}