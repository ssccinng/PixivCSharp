using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Contains the URLs to the images of a multi image work.
    /// </summary>
    public class MetaPagesImageUrls : ImageUrls
    {
        /// <summary>
        /// The square thumbnail of the image.
        /// </summary>
        [JsonProperty("square_medium")]
        public string SquareMedium { get; set; }
    
        /// <summary>
        /// The large thumbnail of the image.
        /// </summary>
        [JsonProperty("large")]
        public string Large { get; set; }
    
        /// <summary>
        /// The URL to the full image.
        /// </summary>
        [JsonProperty("original")]
        public string Original { get; set; }
    }
}