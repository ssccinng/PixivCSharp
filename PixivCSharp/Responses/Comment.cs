using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Represents a comment or comment reply.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// The ID of the comment.
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; set; }
        
        /// <summary>
        /// The contents of the comment.
        /// </summary>
        [JsonProperty("comment")]
        public string Content { get; set; }
        
        /// <summary>
        /// The date the comment was uploaded.
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }
        
        /// <summary>
        /// The user who uploaded the comment.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
        
        /// <summary>
        /// Whether the comment has replies.
        /// </summary>
        [JsonProperty("has_replies")]
        public bool HasReplies { get; set; }
    }
}