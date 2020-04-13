using Newtonsoft.Json;

namespace PixivCSharp
{
    
    /// <summary>
    /// Basic information about a series of illusts/novels.
    /// </summary>
    public class Series
    {
        /// <summary>
        /// The ID of the series.
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; set; }
        
        /// <summary>
        /// The title of the series.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}