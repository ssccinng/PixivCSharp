using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// The full contents of a novel, also contains information about the next and previous novels in it's series,
    /// if applicable.
    /// </summary>
    public class NovelText : Novel
    {
        /// <summary>
        /// The full contents of the novel.
        /// </summary>
        [JsonProperty("novel_text")]
        public string Content { get; set; }
        
        /// <summary>
        /// The previous novel in it's series, if applicable.
        /// </summary>
        [JsonProperty("series_prev")]
        public Novel SeriesPrev { get; set; }
        
        /// <summary>
        /// The next novel in it's series, if applicable.
        /// </summary>
        [JsonProperty("series_next")]
        public Novel SeriesNext { get; set; }
    }
}