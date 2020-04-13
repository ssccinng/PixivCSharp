using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Information recieved when loggin in or refreshing access tokens.
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// The access token.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        
        /// <summary>
        /// How many seconds the access token expires in.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        
        /// <summary>
        /// The type of token.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        
        /// <summary>
        /// The scope the token applies to.
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }
        
        /// <summary>
        /// The refresh token.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        
        /// <summary>
        /// Information of the logged in user.
        /// </summary>
        [JsonProperty("user")]
        public ClientUser User { get; set; }
        
        /// <summary>
        /// The device token.
        /// </summary>
        [JsonProperty("device_token")]
        public string DeviceToken { get; set; }
    }
}