using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        /// <summary>
        /// Gets a list of new illusts
        /// </summary>
        /// <param name="ContentType">Specifies the type of content to search for: illust/manga.</param>
        /// <param name="filter">Specifies whether to use a filter. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="IllustSearchResult"/> for new illusts.</returns>
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
        
        /// <summary>
        /// Gets a list of new illusts from followed accounts.
        /// </summary>
        /// <remarks>
        /// This request does accept the 'filter' parameters, therefore results must be filtered manually if required.
        /// </remarks>
        /// <param name="restrict">Specifies of what restrict to search for: 'all', 'public' or 'private'.</param>
        /// <returns><seealso cref="IllustSearchResult"/> for new illusts from following.</returns>
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
        
        /// <summary>
        /// Gets a list of illusts from my pixiv users.
        /// </summary>
        /// <returns><seealso cref="IllustSearchResult"/> for new illusts from my pixiv users.</returns>
        public async Task<IllustSearchResult> NewMyPixivIllustsAsync()
        {
            Stream response;
            response = await RequestClient.RequestAsync(PixivUrls.NewMyPixivIllusts).ConfigureAwait(false);

            // Converts response into an object and returns
            return Json.DeserializeJson<IllustSearchResult>(response);
        }
        
        /// <summary>
        /// Gets a list of new novels.
        /// </summary>
        /// <returns><seealso cref="NovelSearchResult"/> for new novels.</returns>
        public async Task<NovelSearchResult> NewNovelsAsync()
        {
            Stream response;
            response = await RequestClient.RequestAsync(PixivUrls.NewNovels).ConfigureAwait(false);

            // Converts response into an object and returns
            return Json.DeserializeJson<NovelSearchResult>(response);
        }
        
        /// <summary>
        /// Gets a list of new novels from followed accounts.
        /// </summary>
        /// <param name="restrict">Specifies of what restrict to search for: 'public', 'private' or 'mypixiv'.</param>
        /// <returns><seealso cref="NovelSearchResult"/> for new novels from followed accounts.</returns>
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
        
        /// <summary>
        /// Gets a list of new novels from my pixiv users.
        /// </summary>
        /// <returns><seealso cref="NovelSearchResult"/> for new novels from my pixiv users.</returns>
        public async Task<NovelSearchResult> NewMyPixivNovelsAsync()
        {
            Stream response;
            response = await RequestClient.RequestAsync(PixivUrls.NewMyPixivNovels).ConfigureAwait(false);
            
            // Converts response into object and returns it
            return Json.DeserializeJson<NovelSearchResult>(response);
        }
        
        /// <summary>
        /// Gets a list of currently trending illust tags.
        /// </summary>
        /// <param name="filter">Specifies whether to use a filter. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="TrendTag"/>[] for trending illust tags.</returns>
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
        
        /// <summary>
        /// Gets a list of currently trending novel tags.
        /// </summary>
        /// <returns><seealso cref="TrendTag"/>[] for trending novel tags.</returns>
        public async Task<TrendTag[]> TrendingNovelTagsAsync()
        {
            Stream response;
            response = await RequestClient.RequestAsync(PixivUrls.TrendingNovelTags).ConfigureAwait(false);
            return Json.DeserializeJson<TrendTag[]>(response, "trend_tags");
        }
    }
}