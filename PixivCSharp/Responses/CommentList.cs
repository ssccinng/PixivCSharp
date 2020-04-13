using System.Collections.Generic;
using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// A list of comments.
    /// </summary>
    public class CommentList
    {
        /// <summary>
        /// The comments.
        /// </summary>
        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }
        
        /// <summary>
        /// The URL to obtain further comments, if applicable.
        /// </summary>
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}