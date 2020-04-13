using System.Collections.Generic;
using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// A list of illusts resulting from a search.
    /// </summary>
    public class IllustSearchResult
    {
        /// <summary>
        /// The list of illusts.
        /// </summary>
        [JsonProperty("illusts")]
        public List<Illust> Illusts { get; set; }
        
        /// <summary>
        /// The URL to obtain further for the search, if applicable.
        /// </summary>
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}