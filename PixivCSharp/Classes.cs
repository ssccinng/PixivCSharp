using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PixivCSharp
{
    // Works base class
    public abstract class Works
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("image_urls")]
        public IllustImageUrls ImageUrls { get; set; }
        
        [JsonProperty("caption")]
        public string Caption { get; set; }
        
        [JsonProperty("restrict")]
        public int Restrict { get; set; }
        
        [JsonProperty("x_restrict")]
        public int XRestrict { get; set; }
        
        [JsonProperty("user")]
        public User User { get; set; }
        
        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }
        
        [JsonProperty("create_date")]
        public string CreateDate { get; set; }
        
        [JsonProperty("page_count")]
        public int PageCount { get; set; }
        
        [JsonProperty("series")]
        public Series Series { get; set; }
        
        [JsonProperty("total_view")]
        public int TotalView { get; set; }
        
        [JsonProperty("total_bookmarks")]
        public int TotalBookmarks { get; set; }
        
        [JsonProperty("is_bookmarked")]
        public bool IsBookmarked { get; set; }
        
        [JsonProperty("visible")]
        public bool Visible { get; set; }
        
        [JsonProperty("is_muted")]
        public bool IsMuted { get; set; }
    }
    
    // Main works classes
    public class Illust : Works
    {
        [JsonProperty("tools")]
        public string[] Tools { get; set; }
        
        [JsonProperty("width")]
        public int Width { get; set; }
        
        [JsonProperty("Height")]
        public int Height { get; set; }
        
        [JsonProperty("sanity_level")]
        public int SanityLevel { get; set; }
        
        [JsonProperty("meta_single_page")]
        public MetaSinglePage MetaSinglePage { get; set; }
        
        [JsonProperty("meta_pages")]
        public MetaPages[] MetaPages { get; set; }
    }

    public class Novel : Works
    {
        [JsonProperty("is_original")]
        public bool IsOriginal { get; set; }
        
        [JsonProperty("text_length")]
        public int TextLength { get; set; }
        
        [JsonProperty("is_mypixiv_only")]
        public bool IsMyPixivOnly { get; set; }
        
        [JsonProperty("is_x_restricted")]
        public bool IsXRestricted { get; set; }

        [JsonProperty("total_comments")]
        public int total_comments { get; set; }
    }

    public class NovelText : Novel
    {
        [JsonProperty("novel_text")]
        public string Content { get; set; }
        
        [JsonProperty("series_prev")]
        public Novel SeriesPrev { get; set; }
        
        [JsonProperty("series_next")]
        public Novel SeriesNext { get; set; }
    }

    // Works helper classes
    public class MetaSinglePage
    {
        [JsonProperty("original_image_url")]
        public string OriginalImageUrl { get; set; }
    }

    public class ImageUrls
    {
        [JsonProperty("medium")]
        public string Medium { get; set; }
    }

    public class IllustImageUrls : ImageUrls
    {
        private string _SquareMedium;
        
        [JsonProperty("square_medium")]
        public string SquareMedium
        {
            get => _SquareMedium;
            // Pixiv currently provides the square thumbnail in the android api in webp format, which isn't usable
            // on many platforms, to get around this this square thumbnail url is changed to the one provided by the
            // public api, this has the cost of the speed of loading thumbnails. To be changed when webp can be
            // converted to jpg.
            set
            {
                StringBuilder urlBuilder = new StringBuilder(value);
                urlBuilder.Replace("540x540_10_webp", "600x600");
                _SquareMedium = urlBuilder.ToString();
            }
        }
        
        // Large thumbnail is provided as a webp file, there is currently no reliable way to replace the link.
        [JsonProperty("large")]
        public string large { get; set; }
    }

    public class MetaPagesImageUrls : ImageUrls
    {
        [JsonProperty("square_medium")]
        public string SquareMedium { get; set; }
        
        [JsonProperty("large")]
        public string Large { get; set; }
        
        [JsonProperty("original")]
        public string Original { get; set; }
    }
    
    public class MetaPages
    {
        [JsonProperty("image_urls")]
        public MetaPagesImageUrls ImageUrls { get; set; }
    }
    
    public class Tag
    {
        public string name { get; set; }
        public string translated_name { get; set; }
        public bool added_by_uploader { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string account { get; set; }
        public ImageUrls profile_image_urls { get; set; }
        public bool is_followed { get; set; }
    }

    public class ClientUser : User
    {
        public new UserImageUrls profile_image_urls { get; set; }
        public string mail_address { get; set; }
        public bool is_premium { get; set; }
        public int x_restrict { get; set; }
        public bool is_mail_authorizde { get; set; }
        public bool require_policy_agreement { get; set; }
    }
    
    public class UserImageUrls
    {
        public string px_16x16 { get; set; }
        public string px_50x50 { get; set; }
        public string px_170x170 { get; set; }
    }

    public class Series
    {
        public int? id { get; set; }
        public string title { get; set; }
    }

    // Comment classes
    public class Comment
    {
        public int id { get; set; }
        public string comment { get; set; }
        public string date { get; set; }
        public User user { get; set; }
        public bool has_replies { get; set; }
    }

    public class CommentList
    {
        public List<Comment> comments { get; set; }
        public string next_url { get; set; }
    }

    // Search results classes
    public class IllustSearchResult
    {
        public List<Illust> illusts { get; set; }
        public string next_url { get; set; }
    }

    public class NovelSearchResult
    {
        public List<Novel> novels { get; set; }
        public string next_url { get; set; }
    }

    public class UserSearchResult
    {
        public List<User> user_previews { get; set; }
        public string next_url { get; set; }
    }
    
    // Recommended works classes
    public class RecommendedIllusts : IllustSearchResult
    {
        public List<Illust> ranking_illusts { get; set; }
        public bool content_exists { get; set; }
        public PrivacyPolicy privacy_policy { get; set; }
    }

    public class RecommendedNovels : NovelSearchResult
    {
        public List<Novel> ranking_novels { get; set; }
        public PrivacyPolicy privacy_policy { get; set; }
    }

    public class UserPreview
    {
        public User user { get; set; }
        public List<Illust> illusts { get; set; }
    }

    public class RecommendedUsers
    {
        public List<UserPreview> user_previews { get; set; }
        public string next_url { get; set; }
    }

    //Privacy policy class
    public class PrivacyPolicy
    {
        public string version { get; set; }
        public string message { get; set; }
        public string url { get; set; }
    }

    // Emoji classes
    public class EmojiDef
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string image_url_medium { get; set; }
    }
    
    public class EmojiList
    {
        public EmojiDef[] emoji_definitions { get; set; }
    }
    
    // Login class
    public class LoginResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public string refresh_token { get; set; }
        public ClientUser user { get; set; }
        public string device_token { get; set; }
    }
}