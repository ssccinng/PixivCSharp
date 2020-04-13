using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Information about an emoji.
    /// </summary>
    public class EmojiDef
    {
        /// <summary>
        /// The ID of the emoji.
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; set; }
        
        /// <summary>
        /// The name of the emoji.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        /// <summary>
        /// The URL to the emoji.
        /// </summary>
        [JsonProperty("image_url_medium")]
        public string ImageUrlMedium { get; set; }
    }
}