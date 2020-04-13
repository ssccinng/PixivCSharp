using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// A collection of information about a user.
    /// </summary>
    public class UserDetail
    {
        /// <summary>
        /// Main information about a user.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// Additional information about a user.
        /// </summary>
        [JsonProperty("profile")]
        public Profile Profile { get; set; }
        
        /// <summary>
        /// Information about the publicity of information about the user.
        /// </summary>
        [JsonProperty("profile_publicity")]
        public ProfilePublicity ProfilePublicity { get; set; }
        
        /// <summary>
        /// Information about the user's workspace.
        /// </summary>
        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }
    }
}