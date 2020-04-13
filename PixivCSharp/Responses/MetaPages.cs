using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Contains URLs to each image in a multi-image work.
    /// </summary>
    public class MetaPages
    {
        /// <summary>
        /// ImageUrls object containing URLs to an image.
        /// </summary>
        [JsonProperty("image_urls")]
        public MetaPagesImageUrls ImageUrls { get; set; }
    }
}