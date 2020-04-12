using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PixivCSharp
{
    // Works base class
    public abstract class Work
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
    public class Illust : Work
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

    public class Novel : Work
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
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("translated_name")]
        public string TranslatedName { get; set; }
        
        [JsonProperty("added_by_uploader")]
        public bool AddedByUploader { get; set; }
    }

    public class TrendTag : Tag
    {
        [JsonProperty("tag")]
        public new string Name { get; set; }
        
        [JsonProperty("illust")]
        public Illust Illust { get; set; }
    }

    public class User
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("account")]
        public string Account { get; set; }
        
        [JsonProperty("profile_image_urls")]
        public ImageUrls ProfileImageUrls { get; set; }
        
        [JsonProperty("is_followed")]
        public bool IsFollowed { get; set; }
    }

    public class Profile
    {
        [JsonProperty("webpage")]
        public string WebPage { get; set; }
        
        [JsonProperty("gender")]
        public string Gender { get; set; }
        
        [JsonProperty("birth")]
        public string Birth { get; set; }
        
        [JsonProperty("birth_day")]
        public string BirthDay { get; set; }
        
        [JsonProperty("birth_year")]
        public int BirthYear { get; set; }
        
        [JsonProperty("region")]
        public string Region { get; set; }
        
        [JsonProperty("address_id")]
        public int AddressID { get; set; }
        
        [JsonProperty("country")]
        public string CountryCode { get; set; }
        
        [JsonProperty("job")]
        public string job { get; set; }
        
        [JsonProperty("job_id")]
        public int JobID { get; set; }

        [JsonProperty("total_follow_users")]
        public int Followers { get; set; }

        [JsonProperty("total_mypixiv_users")]
        public int MyPixivUsers { get; set; }
        
        [JsonProperty("total_illusts")]
        public int Illusts { get; set; }
        
        [JsonProperty("total_manga")]
        public int Manga { get; set; }
        
        [JsonProperty("total_novels")]
        public int Novels { get; set; }
        
        [JsonProperty("total_illust_bookmarks_public")]
        public int IllustBookmarks { get; set; }
        
        [JsonProperty("total_illust_series")]
        public int IllustSeries { get; set; }
        
        [JsonProperty("total_novel_series")]
        public int NovelSeries { get; set; }
        
        [JsonProperty("background_image_url")]
        public string BackgroundUrl { get; set; }
        
        [JsonProperty("twitter_account")]
        public string TwitterAccount { get; set; }
        
        [JsonProperty("twitter_url")]
        public string TwitterUrl { get; set; }

        [JsonProperty("pawoo_url")]
        public string PawooUrl { get; set; }

        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }
        
        [JsonProperty("is_using_custom_profile_image")]
        public bool CustomProfileImage { get; set; }
    }

    public class ProfilePublicity
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }
        
        [JsonProperty("region")]
        public string Region { get; set; }
        
        [JsonProperty("birth_day")]
        public string BirthDay { get; set; }
        
        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }
        
        [JsonProperty("job")]
        public string Job { get; set; }
        
        [JsonProperty("pawoo")]
        public string Pawoo { get; set; }
    }

    public class Workspace
    {
        [JsonProperty("pc")]
        public string PC { get; set; }
        
        [JsonProperty("monitor")]
        public string Monitor { get; set; }
        
        [JsonProperty("tool")]
        public string Tool { get; set; }
        
        [JsonProperty("scanner")]
        public string Scanner { get; set; }
        
        [JsonProperty("tablet")]
        public string Tablet { get; set; }
        
        [JsonProperty("mouse")]
        public string Mouse { get; set; }
        
        [JsonProperty("printer")]
        public string Printer { get; set; }
        
        [JsonProperty("desktop")]
        public string Desktop { get; set; }
        
        [JsonProperty("music")]
        public string Music { get; set; }
        
        [JsonProperty("desk")]
        public string Desk { get; set; }
        
        [JsonProperty("Chair")]
        public string Chair { get; set; }
        
        [JsonProperty("comment")]
        public string Commment { get; set; }
        
        [JsonProperty("workspace_image_url")]
        public string WorkspaceImageUrl { get; set; }
    }

    public class UserDetail
    {
        [JsonProperty("user")]
        public User User { get; set; }
        
        [JsonProperty("profile")]
        public Profile Profile { get; set; }
        
        [JsonProperty("profile_publicity")]
        public ProfilePublicity ProfilePublicity { get; set; }
        
        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }
    }

    public class ClientUser : User
    {
        [JsonProperty("profile_image_urls")]
        public new UserImageUrls ProfileImageUrls { get; set; }
        
        [JsonProperty("mail_address")]
        public string MailAddress { get; set; }
        
        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }
        
        [JsonProperty("x_restrict")]
        public int XRestrict { get; set; }
        
        [JsonProperty("is_mail_authorized")]
        public bool IsMailAuthorized { get; set; }
        
        [JsonProperty("require_policy_agreement")]
        public bool RequirePolicyAggreement { get; set; }
    }
    
    public class UserImageUrls
    {
        [JsonProperty("px_16x16")]
        public string Px16x16 { get; set; }
        
        [JsonProperty("px_50x50")]
        public string Px50x50 { get; set; }
        
        [JsonProperty("px_170x170")]
        public string Px170x170 { get; set; }
    }
    
    // Series classes
    public class Series
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class IllustSeries : Series
    {
       [JsonProperty("caption")]
       public string Caption { get; set; }
       
       [JsonProperty("cover_image_urls")]
       public ImageUrls CoverImageUrls { get; set; }
       
       [JsonProperty("series_work_count")]
       public int SeriesWorkCount { get; set; }
       
       [JsonProperty("create_date")]
       public string CreateDate { get; set; }
       
       [JsonProperty("width")]
       public int Width { get; set; }
       
       [JsonProperty("height")]
       public int Height { get; set; }
       
       [JsonProperty("user")]
       public User User { get; set; }
    }

    public class NovelSeries : Series
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }
        
        [JsonProperty("is_original")]
        public bool IsOriginal { get; set; }
        
        [JsonProperty("is_concluded")]
        public bool IsConcluded { get; set; }
        
        [JsonProperty("content_count")]
        public int NovelCount { get; set; }
        
        [JsonProperty("total_character_count")]
        public int CharacterCount { get; set; }
        
        [JsonProperty("user")]
        public User User { get; set; }
        
        [JsonProperty("display_text")]
        public string DisplayText { get; set; }
    }

    public class SeriesContext
    {
        [JsonProperty("content_order")]
        public int ContentOrder { get; set; }
        
        [JsonProperty("prev")]
        public Illust Prev { get; set; }
        
        [JsonProperty("next")]
        public Illust Next { get; set; }
    }

    public class IllustSeriesContext
    {
        [JsonProperty("illust_series_detail")]
        public IllustSeries SeriesDetail { get; set; }
        
        [JsonProperty("illust_series_context")]
        public SeriesContext SeriesContext { get; set; }
    }

    public class IllustSeriesInfo
    {
        [JsonProperty("illust_series_detail")]
        public IllustSeries SeriesDetail { get; set; }
        
        [JsonProperty("illust_series_first_illust")]
        public Illust FirstIllust { get; set; }
        
        [JsonProperty("illusts")]
        public Illust[] Illusts { get; set; }
        
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }

    public class NovelSeriesInfo
    {
        [JsonProperty("novel_series_detail")]
        public NovelSeries SeriesDetail { get; set; }
        
        [JsonProperty("novel_series_first_novel")]
        public Novel FirstNovel { get; set; }
        
        [JsonProperty("novels")]
        public Novel[] Novels { get; set; }
        
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }

    // Comment classes
    public class Comment
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        
        [JsonProperty("comment")]
        public string Content { get; set; }
        
        [JsonProperty("date")]
        public string Date { get; set; }
        
        [JsonProperty("user")]
        public User User { get; set; }
        
        [JsonProperty("has_replies")]
        public bool HasReplies { get; set; }
    }

    public class CommentList
    {
        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }
        
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }

    // Search results classes
    public class IllustSearchResult
    {
        [JsonProperty("illusts")]
        public List<Illust> Illusts { get; set; }
        
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }

    public class NovelSearchResult
    {
        [JsonProperty("novels")]
        public List<Novel> Novels { get; set; }
        
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }

    public class UserPreview
    {
        [JsonProperty("user")]
        public User User { get; set; }
        
        [JsonProperty("illusts")]
        public List<Illust> Illusts { get; set; }
    }
    
    public class UserSearchResult
    {
        [JsonProperty("user_previews")]
        public List<UserPreview> UserPreviews { get; set; }
        
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }
    
    // Recommended works classes
    public class RecommendedIllusts : IllustSearchResult
    {
        [JsonProperty("ranking_illusts")]
        public List<Illust> RankingIllusts { get; set; }
        
        [JsonProperty("content_exists")]
        public bool ContentExists { get; set; }
        
        [JsonProperty("privacy_policy")]
        public PrivacyPolicy PrivacyPolicy { get; set; }
    }

    public class RecommendedNovels : NovelSearchResult
    {
        [JsonProperty("ranking_novels")]
        public List<Novel> RankingNovels { get; set; }
        
        [JsonProperty("privacy_policy")]
        public PrivacyPolicy PrivacyPolicy { get; set; }
    }

    //Privacy policy class
    public class PrivacyPolicy
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    // Emoji classes
    public class EmojiDef
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("image_url_medium")]
        public string ImageUrlMedium { get; set; }
    }
    
    public class EmojiList
    {
        [JsonProperty("emoji_definitions")]
        public EmojiDef[] EmojiDefinitions { get; set; }
    }
    
    // Login class
    public class LoginResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        
        [JsonProperty("scope")]
        public string Scope { get; set; }
        
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        
        [JsonProperty("user")]
        public ClientUser User { get; set; }
        
        [JsonProperty("device_token")]
        public string DeviceToken { get; set; }
    }
}