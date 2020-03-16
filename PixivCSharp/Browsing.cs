using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        // Gets a list of recommended illusts
        public async Task<RecommendedIllusts> RecommendedIllustsAsync(bool RankingIllusts, bool PrivacyPolicy, string filter = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "filter", filter ?? Filter },
                { "include_ranking_illusts", RankingIllusts.ToString().ToLower() },
                { "include_privacy_policy" , PrivacyPolicy.ToString().ToLower() }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.RecommendedIllusts, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            RecommendedIllusts result = json.ToObject<RecommendedIllusts>();
            return result;
        }
        
        // Gets a list of recommended manga
        public async Task<RecommendedIllusts> RecommendedMangaAsync(bool RankingIllusts, bool PrivacyPolicy, string filter = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "filter", filter ?? Filter },
                { "include_ranking_illusts", RankingIllusts.ToString().ToLower() },
                { "include_privacy_policy", PrivacyPolicy.ToString().ToLower() }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.RecommendedManga, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            RecommendedIllusts result = json.ToObject<RecommendedIllusts>();
            return result;
        }
        
        // Gets a list of recommended novels
        public async Task<RecommendedNovels> RecommendedNovelAsync(bool RankingIllusts, bool PrivacyPolicy)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "include_ranking_illusts", RankingIllusts.ToString().ToLower() },
                { "include_privacy_policy", PrivacyPolicy.ToString().ToLower() }
            };
            FormUrlEncodedContent encodedParmas = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.RecommendedNovels, encodedParmas).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            RecommendedNovels result = json.ToObject<RecommendedNovels>();
            return result;
        }
        
        // Gets a list of recommended users
        public async Task<RecommendedUsers> RecommendedUsersAsync(string filter = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "filter", filter ?? Filter }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.RecommendedUsers, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            RecommendedUsers result = json.ToObject<RecommendedUsers>();
            return result;
        }
    }
}