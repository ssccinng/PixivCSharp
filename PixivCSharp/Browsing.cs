using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
        
        // Gets a list of new novels
        public async Task<NovelSearchResult> NewNovelsAsync()
        {
            // Sends request
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.NewNovels).ConfigureAwait(false);

            // Converts response into an object and returns
            NovelSearchResult result =
                Json.DeserializeJson<NovelSearchResult>(
                    await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            return result;
        }
        
        // Gets a list of new novels from followed
        public async Task<NovelSearchResult> NewFollowNovelsAsync(string restrict)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "restrict", restrict }
            };
            
            // Encodeds parameters and sends request
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage repsonse = await RequestClient.RequestAsync(PixivUrls.NewFollowNovels, encodedParams)
                .ConfigureAwait(false);
            
            // Converts response into object and returns it
            NovelSearchResult result =
                Json.DeserializeJson<NovelSearchResult>(
                    await repsonse.Content.ReadAsStringAsync().ConfigureAwait(false));
            return result;
        }
        
        // Gets a list of new novels from my pixiv
        public async Task<NovelSearchResult> NewMyPixivNovelsAsync()
        {
            // Sends request
            HttpResponseMessage response =
                await RequestClient.RequestAsync(PixivUrls.NewMyPixivNovels).ConfigureAwait(false);
            
            // Converts response into object and returns it
            NovelSearchResult result =
                Json.DeserializeJson<NovelSearchResult>(
                    await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            return result;
        }
        
        // Gets a list of trending illust tags
        public async Task<TrendTag[]> TrendingIllustTagsAsync(string filter = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            
            FormUrlEncodedContent encodedParameters = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient
                .RequestAsync(PixivUrls.TrendingIllustTags, encodedParameters).ConfigureAwait(false);
            
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            
            // Converts response into object and returns it
            TrendTag[] result = Json.DeserializeJson<TrendTag[]>((JArray)json["trend_tags"]);

            return result;
        }
        
        // Gets a list of trending tags
        public async Task<TrendTag[]> TrendingNovelTagsAsync()
        {
            HttpResponseMessage response =
                await RequestClient.RequestAsync(PixivUrls.TrendingNovelTags).ConfigureAwait(false);
            
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            
            // Converts response into object and returns it
            TrendTag[] result = Json.DeserializeJson<TrendTag[]>((JArray)json["trend_tags"]);

            return result;
        }
    }
}