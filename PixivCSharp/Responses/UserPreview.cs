using System.Collections.Generic;
using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Contains information about a user, and some example illusts.
    /// </summary>
    public class UserPreview
    {
        /// <summary>
        /// The user.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
        
        /// <summary>
        /// Example illusts of the user.
        /// </summary>
        [JsonProperty("illusts")]
        public List<Illust> Illusts { get; set; }
    }
}