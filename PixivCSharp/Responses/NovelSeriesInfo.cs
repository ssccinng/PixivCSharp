using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Information about a novel series, and its novels.
    /// </summary>
    public class NovelSeriesInfo
    {
        /// <summary>
        /// Information about the novel series.
        /// </summary>
        [JsonProperty("novel_series_detail")]
        public NovelSeries SeriesDetail { get; set; }
        
        /// <summary>
        /// Details of the first novel in the series.
        /// </summary>
        [JsonProperty("novel_series_first_novel")]
        public Novel FirstNovel { get; set; }
        
        /// <summary>
        /// Details of up to 30 novels, newest to oldest.
        /// </summary>
        [JsonProperty("novels")]
        public Novel[] Novels { get; set; }
        
        /// <summary>
        /// The URL to obtain further novels, if applicable.
        /// </summary>
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
}