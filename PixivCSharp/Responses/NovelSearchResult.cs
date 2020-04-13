using System.Collections.Generic;
using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// A list of novels resulting from a search.
    /// </summary>
    public class NovelSearchResult
    {
        /// <summary>
        /// The list of novels.
        /// </summary>
        [JsonProperty("novels")]
        public List<Novel> Novels { get; set; }
        
        /// <summary>
        /// The URL to obtain further novels for the search, if applicable.
        /// </summary>
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}