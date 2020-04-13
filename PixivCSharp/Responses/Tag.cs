using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// The tag of a work.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// The original name of a tag.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// The translation of a tag.
        /// </summary>
        [JsonProperty("translated_name")]
        public string TranslatedName { get; set; }
        
        /// <summary>
        /// Whether the tag was added by the author.
        /// </summary>
        [JsonProperty("added_by_uploader")]
        public bool AddedByUploader { get; set; }
    }
}