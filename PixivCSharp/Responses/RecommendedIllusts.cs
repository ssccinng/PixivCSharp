using System.Collections.Generic;
using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Contains a list of recommended illusts, and ranking illusts and a privacy policy if necessary.
    /// </summary>
    public class RecommendedIllusts : IllustSearchResult
    {
        /// <summary>
        /// The daily ranking illusts.
        /// </summary>
        [JsonProperty("ranking_illusts")]
        public List<Illust> RankingIllusts { get; set; }
        
        /// <summary>
        /// Currently unknown.
        /// </summary>
        [JsonProperty("content_exists")]
        public bool ContentExists { get; set; }
        
        /// <summary>
        /// The current privacy policy.
        /// </summary>
        [JsonProperty("privacy_policy")]
        public PrivacyPolicy PrivacyPolicy { get; set; }
    }
}