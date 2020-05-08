using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        /// <summary>
        /// Gets a list of recommended illusts.
        /// </summary>
        /// <param name="RankingIllusts">Whether to include ranking illusts.</param>
        /// <param name="PrivacyPolicy">Whether to include a link to the privacy policy.</param>
        /// <param name="filter">The filter to use.</param>
        /// <returns><seealso cref="RecommendedIllusts"/></returns>
        public async Task<RecommendedIllusts> RecommendedIllustsAsync(bool RankingIllusts = true, bool PrivacyPolicy = true, string filter = null)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "include_ranking_illusts", RankingIllusts.ToString().ToLower() },
                { "include_privacy_policy" , PrivacyPolicy.ToString().ToLower() }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.RecommendedIllusts, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<RecommendedIllusts>(response);
        }
        
        /// <summary>
        /// Gets a list of recommneded manga.
        /// </summary>
        /// <param name="RankingIllusts">Whether to include ranking illusts.</param>
        /// <param name="PrivacyPolicy"></param>
        /// <param name="filter"></param>
        /// <returns><seealso cref="RecommendedIllusts"/></returns>
        public async Task<RecommendedIllusts> RecommendedMangaAsync(bool RankingIllusts = true, bool PrivacyPolicy = true, string filter = null)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "include_ranking_illusts", RankingIllusts.ToString().ToLower() },
                { "include_privacy_policy", PrivacyPolicy.ToString().ToLower() }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.RecommendedManga, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<RecommendedIllusts>(response);
        }
        
        /// <summary>
        /// Gets a list of recommended novels.
        /// </summary>
        /// <param name="RankingNovels">Whether to include ranking novels.</param>
        /// <param name="PrivacyPolicy"></param>
        /// <returns><seealso cref="RecommendedNovels"/></returns>
        public async Task<RecommendedNovels> RecommendedNovelsAsync(bool RankingNovels = true, bool PrivacyPolicy = true)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "include_ranking_novels", RankingNovels.ToString().ToLower() },
                { "include_privacy_policy", PrivacyPolicy.ToString().ToLower() }
            };
            FormUrlEncodedContent encodedParmas = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.RecommendedNovels, encodedParmas).ConfigureAwait(false);
            return Json.DeserializeJson<RecommendedNovels>(response);
        }
        
        /// <summary>
        /// Gets a list of recommended users.
        /// </summary>
        /// <param name="filter">The filter to use.</param>
        /// <returns><seealso cref="UserSearchResult"/></returns>
        public async Task<UserSearchResult> RecommendedUsersAsync(string filter = null)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.RecommendedUsers, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<UserSearchResult>(response);
        }
    }
}