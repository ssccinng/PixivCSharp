using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Information about the user's workspace.
    /// </summary>
    public class Workspace
    {
        /// <summary>
        /// The user's computer.
        /// </summary>
        [JsonProperty("pc")]
        public string PC { get; set; }
        
        /// <summary>
        /// The user's montitor.
        /// </summary>
        [JsonProperty("monitor")]
        public string Monitor { get; set; }
        
        /// <summary>
        /// Tools the user uses.
        /// </summary>
        [JsonProperty("tool")]
        public string Tool { get; set; }
        
        /// <summary>
        /// The scanner the user uses.
        /// </summary>
        [JsonProperty("scanner")]
        public string Scanner { get; set; }
        
        /// <summary>
        /// The tablet the user uses.
        /// </summary>
        [JsonProperty("tablet")]
        public string Tablet { get; set; }
        
        /// <summary>
        /// The mouse the user uses.
        /// </summary>
        [JsonProperty("mouse")]
        public string Mouse { get; set; }
        
        /// <summary>
        /// The printer the user uses.
        /// </summary>
        [JsonProperty("printer")]
        public string Printer { get; set; }
        
        /// <summary>
        /// The desktop the user uses.
        /// </summary>
        [JsonProperty("desktop")]
        public string Desktop { get; set; }
        
        /// <summary>
        /// The music the user listens to.
        /// </summary>
        [JsonProperty("music")]
        public string Music { get; set; }
        
        /// <summary>
        /// The desk the user uses.
        /// </summary>
        [JsonProperty("desk")]
        public string Desk { get; set; }
        
        /// <summary>
        /// The chair the user uses.
        /// </summary>
        [JsonProperty("Chair")]
        public string Chair { get; set; }
        
        /// <summary>
        /// Any additional comments.
        /// </summary>
        [JsonProperty("comment")]
        public string Commment { get; set; }
        
        /// <summary>
        /// The URL to a workspace image.
        /// </summary>
        [JsonProperty("workspace_image_url")]
        public string WorkspaceImageUrl { get; set; }
    }
}