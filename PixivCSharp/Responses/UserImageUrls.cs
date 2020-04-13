using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// URLs to the profile picture of the logged in user.
    /// </summary>
    public class UserImageUrls
    {
        /// <summary>
        /// URL to the 16x16 iamge of the profile picture.
        /// </summary>
        [JsonProperty("px_16x16")]
        public string Px16x16 { get; set; }
        
        /// <summary>
        /// URL to the 50x50 iamge of the profile picture.
        /// </summary>
        [JsonProperty("px_50x50")]
        public string Px50x50 { get; set; }
        
        /// <summary>
        /// URL to the 170x170 iamge of the profile picture.
        /// </summary>
        [JsonProperty("px_170x170")]
        public string Px170x170 { get; set; }
    }
}