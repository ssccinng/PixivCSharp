using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// The context of an illust in a series, and details of the series.
    /// </summary>
    public class IllustSeriesContext
    {
        /// <summary>
        /// Details of the series.
        /// </summary>
        [JsonProperty("illust_series_detail")]
        public IllustSeries SeriesDetail { get; set; }
        
        /// <summary>
        /// The context of an illust in the series.
        /// </summary>
        [JsonProperty("illust_series_context")]
        public SeriesContext SeriesContext { get; set; }
    }
}