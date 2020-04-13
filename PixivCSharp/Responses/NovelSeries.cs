using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Information about a novel series.
    /// </summary>
    public class NovelSeries : Series
    {
        /// <summary>
        /// The series caption.
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }
        
        /// <summary>
        /// Whether the series is original or derivative.
        /// </summary>
        [JsonProperty("is_original")]
        public bool IsOriginal { get; set; }
        
        /// <summary>
        /// Whether the series is concluded.
        /// </summary>
        [JsonProperty("is_concluded")]
        public bool IsConcluded { get; set; }
        
        /// <summary>
        /// The number of novels in the series.
        /// </summary>
        [JsonProperty("content_count")]
        public int NovelCount { get; set; }
        
        /// <summary>
        /// The total number of characters in the series.
        /// </summary>
        [JsonProperty("total_character_count")]
        public int CharacterCount { get; set; }
        
        /// <summary>
        /// The user who created the series.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
        
        /// <summary>
        /// The dispaly text of the series.
        /// </summary>
        [JsonProperty("display_text")]
        public string DisplayText { get; set; }
    }
}