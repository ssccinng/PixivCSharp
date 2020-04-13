using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Information about the position of an illust in a series.
    /// </summary>
    public class SeriesContext
    {
        /// <summary>
        /// The position of an illust in it's series.
        /// </summary>
        [JsonProperty("content_order")]
        public int ContentOrder { get; set; }
        
        /// <summary>
        /// The previous illust in the series.
        /// </summary>
        [JsonProperty("prev")]
        public Illust Prev { get; set; }
        
        /// <summary>
        /// The next illust in the series.
        /// </summary>
        [JsonProperty("next")]
        public Illust Next { get; set; }
    }
}