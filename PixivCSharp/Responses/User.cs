using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Contains information about the author of a work.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The ID of the user.
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; set; }
        
        /// <summary>
        /// The username of the user.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// The name of the user's account
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }
        
        /// <summary>
        /// Links to user's profile picture
        /// </summary>
        [JsonProperty("profile_image_urls")]
        public ImageUrls ProfileImageUrls { get; set; }
        
        /// <summary>
        /// Whether the account is followed by the logged in user.
        /// </summary>
        [JsonProperty("is_followed")]
        public bool IsFollowed { get; set; }
    }
}