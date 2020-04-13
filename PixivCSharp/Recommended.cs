using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        // Gets a list of recommended illusts
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
        
        // Gets a list of recommended manga
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
        
        // Gets a list of recommended novels
        public async Task<RecommendedNovels> RecommendedNovelsAsync(bool RankingIllusts = true, bool PrivacyPolicy = true)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "include_ranking_illusts", RankingIllusts.ToString().ToLower() },
                { "include_privacy_policy", PrivacyPolicy.ToString().ToLower() }
            };
            FormUrlEncodedContent encodedParmas = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.RecommendedNovels, encodedParmas).ConfigureAwait(false);
            return Json.DeserializeJson<RecommendedNovels>(response);
        }
        
        // Gets a list of recommended users
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