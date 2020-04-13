using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    ///  Base class for Illust and Novel classes.
    /// </summary>
    public abstract class Work
    {
        /// <summary>
        /// The ID of the work.
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; set; }
        
        /// <summary>
        /// The title of the work.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// The type of work: Illust/Novel.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        
        /// <summary>
        /// A collection of image urls for thumbnails of the work.
        /// </summary>
        [JsonProperty("image_urls")]
        public IllustImageUrls ImageUrls { get; set; }
        
        /// <summary>
        /// The caption of a work
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }
        
        /// <summary>
        /// The publicity of a work: public/private/mypixiv.
        /// </summary>
        [JsonProperty("restrict")]
        public int Restrict { get; set; }
        
        /// <summary>
        /// The age restriction of a work: None/R18.
        /// </summary>
        [JsonProperty("x_restrict")]
        public int XRestrict { get; set; }
        
        /// <summary>
        /// The author of the work.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
        
        /// <summary>
        /// The tags of a work.
        /// </summary>
        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }
        
        /// <summary>
        /// The date a work was uploaded.
        /// </summary>
        [JsonProperty("create_date")]
        public string CreateDate { get; set; }
        
        /// <summary>
        /// The number of pages a work has.
        /// </summary>
        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        /// <summary>
        /// Information about the series the work belongs to, if applicable.
        /// </summary>
        [JsonProperty("series")]
        public Series Series { get; set; }
        
        /// <summary>
        /// The number of Views a work has.
        /// </summary>
        [JsonProperty("total_view")]
        public int TotalView { get; set; }
        
        /// <summary>
        /// The number of bookmarks the work has.
        /// </summary>
        [JsonProperty("total_bookmarks")]
        public int TotalBookmarks { get; set; }

        /// <summary>
        /// Whether the logged in user has bookmarked the work.
        /// </summary>
        [JsonProperty("is_bookmarked")]
        public bool IsBookmarked { get; set; }
        
        /// <summary>
        /// Whether the work is visible to the logged in user.
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }
        
        /// <summary>
        /// Whether the work is muted by the logged in user.
        /// </summary>
        [JsonProperty("is_muted")]
        public bool IsMuted { get; set; }
    }
}