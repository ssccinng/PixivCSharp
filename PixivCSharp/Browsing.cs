using System.Collections.Generic;
using System.IO;
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
            Stream response;
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
            response = await RequestClient.RequestAsync(PixivUrls.NewIllusts, encodedParams).ConfigureAwait(false);

            return Json.DeserializeJson<IllustSearchResult>(response);
        }
        
        // Gets a list of new illusts from followed account
        public async Task<IllustSearchResult> NewFollowIllustsAsync(string restrict = "all")
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "restrict", restrict}
            };
            
            // Encodes parameters and sends request
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.NewFollowIllusts, encodedParams).ConfigureAwait(false);

            return Json.DeserializeJson<IllustSearchResult>(response);
        }
        
        // Gets a list of new illusts from users added to my pixiv
        public async Task<IllustSearchResult> NewMyPixivIllustsAsync()
        {
            Stream response;
            response = await RequestClient.RequestAsync(PixivUrls.NewMyPixivIllusts).ConfigureAwait(false);

            // Converts response into an object and returns
            return Json.DeserializeJson<IllustSearchResult>(response);
        }
        
        // Gets a list of new novels
        public async Task<NovelSearchResult> NewNovelsAsync()
        {
            Stream response;
            response = await RequestClient.RequestAsync(PixivUrls.NewNovels).ConfigureAwait(false);

            // Converts response into an object and returns
            return Json.DeserializeJson<NovelSearchResult>(response);
        }
        
        // Gets a list of new novels from followed
        public async Task<NovelSearchResult> NewFollowNovelsAsync(string restrict)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "restrict", restrict }
            };
            
            // Encodeds parameters and sends request
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.NewFollowNovels, encodedParams).ConfigureAwait(false);
            
            // Converts response into object and returns it
            return Json.DeserializeJson<NovelSearchResult>(response);
        }
        
        // Gets a list of new novels from my pixiv
        public async Task<NovelSearchResult> NewMyPixivNovelsAsync()
        {
            Stream response;
            response = await RequestClient.RequestAsync(PixivUrls.NewMyPixivNovels).ConfigureAwait(false);
            
            // Converts response into object and returns it
            return Json.DeserializeJson<NovelSearchResult>(response);
        }
        
        // Gets a list of trending illust tags
        public async Task<TrendTag[]> TrendingIllustTagsAsync(string filter = null)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            
            FormUrlEncodedContent encodedParameters = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.TrendingIllustTags, encodedParameters).ConfigureAwait(false);

            return Json.DeserializeJson<TrendTag[]>(response, "trend_tags");
        }
        
        // Gets a list of trending tags
        public async Task<TrendTag[]> TrendingNovelTagsAsync()
        {
            Stream response;
            response = await RequestClient.RequestAsync(PixivUrls.TrendingNovelTags).ConfigureAwait(false);
            return Json.DeserializeJson<TrendTag[]>(response, "trend_tags");
        }
    }
}