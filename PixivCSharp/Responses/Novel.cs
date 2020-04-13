using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Represents novels.
    /// </summary>
    public class Novel : Work
    {
        /// <summary>
        /// Whether the novel is original or derivative.
        /// </summary>
        [JsonProperty("is_original")]
        public bool IsOriginal { get; set; }
        
        /// <summary>
        /// The number of characters in the novel.
        /// </summary>
        [JsonProperty("text_length")]
        public int TextLength { get; set; }
        
        /// <summary>
        /// Whether the novel in only available to users on the author's mypixiv list.
        /// </summary>
        [JsonProperty("is_mypixiv_only")]
        public bool IsMyPixivOnly { get; set; }
        
        /// <summary>
        /// Whether the novel is restricted to accounts set to show explicit content.
        /// </summary>
        [JsonProperty("is_x_restricted")]
        public bool IsXRestricted { get; set; }

        /// <summary>
        /// The number of comments on the novel.
        /// </summary>
        [JsonProperty("total_comments")]
        public int total_comments { get; set; }
    }
}