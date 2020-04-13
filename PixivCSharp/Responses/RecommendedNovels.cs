using System.Collections.Generic;
using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// A list of recommended novels, and ranking novels and the privacy policy if necessary.
    /// </summary>
    public class RecommendedNovels : NovelSearchResult
    {
        /// <summary>
        /// The daily ranking novels.
        /// </summary>
        [JsonProperty("ranking_novels")]
        public List<Novel> RankingNovels { get; set; }
        
        /// <summary>
        /// The current privacy policy.
        /// </summary>
        [JsonProperty("privacy_policy")]
        public PrivacyPolicy PrivacyPolicy { get; set; }
    }
}