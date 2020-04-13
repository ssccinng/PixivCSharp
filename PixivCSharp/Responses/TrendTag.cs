using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Represents tags in trending tag lists.
    /// </summary>
    public class TrendTag : Tag
    {
        /// <summary>
        /// The name of the tag.
        /// </summary>
        [JsonProperty("tag")]
        public new string Name { get; set; }
        
        /// <summary>
        /// An example illust for the tag.
        /// </summary>
        [JsonProperty("illust")]
        public Illust Illust { get; set; }
    }
}