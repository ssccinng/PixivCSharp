using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Detailed information about a user.
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// A link to the user's website.
        /// </summary>
        [JsonProperty("webpage")]
        public string WebPage { get; set; }
        
        /// <summary>
        /// The user's gender.
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }
        
        /// <summary>
        /// The user's birth date.
        /// </summary>
        [JsonProperty("birth")]
        public string BirthDate { get; set; }
        
        /// <summary>
        /// The user's birthday.
        /// </summary>
        [JsonProperty("birth_day")]
        public string BirthDay { get; set; }
        
        /// <summary>
        /// The user's birth year.
        /// </summary>
        [JsonProperty("birth_year")]
        public int BirthYear { get; set; }
        
        /// <summary>
        /// The user's region.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }
        
        /// <summary>
        /// The Address ID of the user.
        /// </summary>
        [JsonProperty("address_id")]
        public int AddressID { get; set; }
        
        /// <summary>
        /// The user's country code.
        /// </summary>
        [JsonProperty("country")]
        public string CountryCode { get; set; }
        
        /// <summary>
        /// The user's job.
        /// </summary>
        [JsonProperty("job")]
        public string job { get; set; }
        
        /// <summary>
        /// The user's job ID.
        /// </summary>
        [JsonProperty("job_id")]
        public int JobID { get; set; }

        /// <summary>
        /// The number of followers the user's has.
        /// </summary>
        [JsonProperty("total_follow_users")]
        public int Followers { get; set; }

        /// <summary>
        /// The number of my pixiv users the user has.
        /// </summary>
        [JsonProperty("total_mypixiv_users")]
        public int MyPixivUsers { get; set; }
        
        /// <summary>
        /// The number of illusts the user has uploaded.
        /// </summary>
        [JsonProperty("total_illusts")]
        public int Illusts { get; set; }
        
        /// <summary>
        /// The number of manga the user has uploaded.
        /// </summary>
        [JsonProperty("total_manga")]
        public int Manga { get; set; }
        
        /// <summary>
        /// The number of novels the user has uploaded.
        /// </summary>
        [JsonProperty("total_novels")]
        public int Novels { get; set; }
        
        /// <summary>
        /// The number of illusts the user has publicy bookmarked.
        /// </summary>
        [JsonProperty("total_illust_bookmarks_public")]
        public int IllustBookmarks { get; set; }
        
        /// <summary>
        /// The number of illust series the user has created.
        /// </summary>
        [JsonProperty("total_illust_series")]
        public int IllustSeries { get; set; }
        
        /// <summary>
        /// The number of novel series the user has created.
        /// </summary>
        [JsonProperty("total_novel_series")]
        public int NovelSeries { get; set; }
        
        /// <summary>
        /// The URL to the user's background image.
        /// </summary>
        [JsonProperty("background_image_url")]
        public string BackgroundUrl { get; set; }
        
        /// <summary>
        /// The user's twitter handle.
        /// </summary>
        [JsonProperty("twitter_account")]
        public string TwitterAccount { get; set; }
        
        /// <summary>
        /// The URL to the user's twitter account.
        /// </summary>
        [JsonProperty("twitter_url")]
        public string TwitterUrl { get; set; }

        /// <summary>
        /// The URL to the user's pawoo accont.
        /// </summary>
        [JsonProperty("pawoo_url")]
        public string PawooUrl { get; set; }

        /// <summary>
        /// Whether the user has Pixiv Premium.
        /// </summary>
        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }
        
        /// <summary>
        /// Whether the user is using a custom profile picture.
        /// </summary>
        [JsonProperty("is_using_custom_profile_image")]
        public bool CustomProfileImage { get; set; }
    }
}