using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Represents an Illust or Manga.
    /// </summary>
    public class Illust : Work
    {
        /// <summary>
        /// The tools used in production of the illust.
        /// </summary>
        [JsonProperty("tools")]
        public string[] Tools { get; set; }
        
        /// <summary>
        /// The width of the illust.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }
        
        /// <summary>
        /// The heigt of the illust
        /// </summary>
        [JsonProperty("Height")]
        public int Height { get; set; }
        
        /// <summary>
        /// The probability of an illust containing explicit content, a higher number representing a higher probability.
        /// </summary>
        [JsonProperty("sanity_level")]
        public int SanityLevel { get; set; }
        
        /// <summary>
        /// The link to full image of a single image work, empty if the work contains multiple images.
        /// </summary>
        [JsonProperty("meta_single_page")]
        public MetaSinglePage MetaSinglePage { get; set; }
        
        /// <summary>
        /// The links to all the full images of multi image works, empty if the work only has a single image.
        /// </summary>
        [JsonProperty("meta_pages")]
        public MetaPages[] MetaPages { get; set; }
    }
}