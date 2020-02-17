using System.Collections.Generic;
using System.Text;

namespace PixivCSharp
{
    //Works base class
    public abstract class Works
    {
        public int id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public IllustImageUrls image_urls { get; set; }
        public string caption { get; set; }
        public int restrict { get; set; }
        public int x_restrict { get; set; }
        public User user { get; set; }
        public Tag[] tags { get; set; }
        public string create_date { get; set; }
        public int page_count { get; set; }
        public Series series { get; set; }
        public int total_view { get; set; }
        public int total_bookmarks { get; set; }
        public bool is_bookmarked { get; set; }
        public bool visible { get; set; }
        public bool is_muted { get; set; }
    }
    
    //Main works classes
    public class Illust : Works
    {
        public string[] tools { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int sanity_level { get; set; }
        public MetaSinglePage meta_single_page { get; set; }
        public MetaPages[] meta_pages { get; set; }
    }

    public class Novel : Works
    {
        public bool is_original { get; set; }
        public int text_length { get; set; }
        public bool is_mypixiv_only { get; set; }
        public bool is_x_restricted { get; set; }
        public int total_comments { get; set; }
    }

    public class NovelTetxt : Novel
    {
        public string novel_text { get; set; }
        public Novel series_prev { get; set; }
        public Novel series_next { get; set; }
    }

    //Works helper classes
    public class MetaSinglePage
    {
        public string original_image_url { get; set; }
    }

    public class ImageUrls
    {
        public string medium { get; set; }
    }

    public class IllustImageUrls : ImageUrls
    {
        private string _square_medium;
        public string square_medium
        {
            get => _square_medium;
            //Pixiv currently provides the square thumbnail in the android api in webp format, which isn't usable
            //on many platforms, to get around this this square thumbnail url is changed to the one provided by the
            //public api, this has the cost of the speed of loading thumbnails. To be changed when webp can be
            //converted to jpg.
            set
            {
                StringBuilder urlBuilder = new StringBuilder(value);
                urlBuilder.Replace("540x540_10_webp", "600x600");
                _square_medium = urlBuilder.ToString();
            }
        }
        //Large thumbnail is provided as a webp file, there is currently no reliable way to replace the link.
        public string large { get; set; }
    }

    public class MetaPagesImageUrls : ImageUrls
    {
        public string square_medium { get; set; }
        public string large { get; set; }
        public string original { get; set; }
    }
    
    public class MetaPages
    {
        public MetaPagesImageUrls image_urls { get; set; }
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

    //Comment classes
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

    //Search results classes
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
    
    //Emoji classes
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
    
    //Login class
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