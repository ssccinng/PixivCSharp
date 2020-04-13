using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// The base class for ImageUrl classes, used for profile picture URLs.
    /// </summary>
    public class ImageUrls
    {
        /// <summary>
        /// URL to medium image.
        /// </summary>
        [JsonProperty("medium")]
        public string Medium { get; set; }
    }
}