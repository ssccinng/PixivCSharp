using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// A list of emojis.
    /// </summary>
    public class EmojiList
    {
        /// <summary>
        /// The list of emojis.
        /// </summary>
        [JsonProperty("emoji_definitions")]
        public EmojiDef[] EmojiDefinitions { get; set; }
    }
}