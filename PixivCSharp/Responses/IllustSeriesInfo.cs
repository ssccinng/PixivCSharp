using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Details of an illust series, and the illust within it.
    /// </summary>
    public class IllustSeriesInfo
    {
        /// <summary>
        /// Details of the illust series.
        /// </summary>
        [JsonProperty("illust_series_detail")]
        public IllustSeries SeriesDetail { get; set; }
        
        /// <summary>
        /// Details of the first illust in the series.
        /// </summary>
        [JsonProperty("illust_series_first_illust")]
        public Illust FirstIllust { get; set; }
        
        /// <summary>
        /// Information of up to 30 illusts in the series, newest to oldest.
        /// </summary>
        [JsonProperty("illusts")]
        public Illust[] Illusts { get; set; }
        
        /// <summary>
        /// The URL to obtain details further illusts in the series, if applicable.
        /// </summary>
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}