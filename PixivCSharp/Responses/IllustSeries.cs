using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Information about an illust series.
    /// </summary>
    public class IllustSeries : Series
    {
        /// <summary>
        /// The caption of the series.
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }
       
        /// <summary>
        /// URLs to the series' cover.
        /// </summary>
        [JsonProperty("cover_image_urls")]
        public ImageUrls CoverImageUrls { get; set; }
       
        /// <summary>
        /// The number of works in the series.
        /// </summary>
        [JsonProperty("series_work_count")]
        public int SeriesWorkCount { get; set; }
       
        /// <summary>
        /// The date the series was created.
        /// </summary>
        [JsonProperty("create_date")]
        public string CreateDate { get; set; }
       
        /// <summary>
        /// Currently unknown.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }
       
        /// <summary>
        /// Currently unknown.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }
       
        /// <summary>
        /// The user who created the series.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
    }
}