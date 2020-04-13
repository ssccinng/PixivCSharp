using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Information about the logged in user.
    /// </summary>
    public class ClientUser : User
    {
        /// <summary>
        /// Links to user's profile picture.
        /// </summary>
        [JsonProperty("profile_image_urls")]
        public new UserImageUrls ProfileImageUrls { get; set; }
        
        /// <summary>
        /// The user's email address.
        /// </summary>
        [JsonProperty("mail_address")]
        public string MailAddress { get; set; }
        
        /// <summary>
        /// Whether the user has pixiv premium.
        /// </summary>
        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }
        
        /// <summary>
        /// The maximum XRestrict the user has access to.
        /// </summary>
        [JsonProperty("x_restrict")]
        public int XRestrict { get; set; }
        
        /// <summary>
        /// Whether the email account is authorised.
        /// </summary>
        [JsonProperty("is_mail_authorized")]
        public bool IsMailAuthorized { get; set; }
        
        /// <summary>
        /// Whether the policy agreement is required.
        /// </summary>
        [JsonProperty("require_policy_agreement")]
        public bool RequirePolicyAggreement { get; set; }
    }
}