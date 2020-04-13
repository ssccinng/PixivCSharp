using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Information about the current privacy policy.
    /// </summary>
    public class PrivacyPolicy
    {
        /// <summary>
        /// The version of the privacy policy.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
        
        /// <summary>
        /// A message about the privacy policy.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        
        /// <summary>
        /// The URL to the full privacy policy.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}