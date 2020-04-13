using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Contains the URL to the full image of a single image work.
    /// </summary>
    public class MetaSinglePage
    {
        /// <summary>
        /// The URL to the full image of a single page work.
        /// </summary>
        [JsonProperty("original_image_url")]
        public string OriginalImageUrl { get; set; }
    }
}