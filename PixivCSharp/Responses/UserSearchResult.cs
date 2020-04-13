using System.Collections.Generic;
using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// A list of users resulting from a search.
    /// </summary>
    public class UserSearchResult
    {
        /// <summary>
        /// The list of users, with example illusts.
        /// </summary>
        [JsonProperty("user_previews")]
        public List<UserPreview> UserPreviews { get; set; }
        
        /// <summary>
        /// The URL to obtain further users for the search, if applicable.
        /// </summary>
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}