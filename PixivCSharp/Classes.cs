using System.Collections.Generic;
using System.Dynamic;

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
        public abstract void bookmark();
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
        public override void bookmark()
        {
            //
        }
    }

    public class Novel : Works
    {
        public int text_length { get; set; }
        public bool is_mypixiv_only { get; set; }
        public bool is_x_restricted { get; set; }
        public int total_comments { get; set; }
        public override void bookmark()
        {
            //
        }
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
        public string square_medium { get; set; }
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