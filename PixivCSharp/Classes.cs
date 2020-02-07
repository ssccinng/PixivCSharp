using System;

namespace PixivCSharp
{
    //Works base class
    public abstract class Works
    {
        public string id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string[] image_urls { get; set; }
        public string caption { get; set; }
        public int restrict { get; set; }
        public int x_restrict { get; set; }
        public User user { get; set; }
        public string[] tags { get; set; }
        public string create_date { get; set; }
        public int page_count { get; set; }
        public int total_view { get; set; }
        public int total_bookmarks { get; set; }
        public bool is_bookmarked { get; set; }
        public bool visible { get; set; }
        public bool is_muted { get; set; }
        public abstract void bookmark();
    }
    
    public class Illust : Works
    {
        public override void bookmark()
        {
            //
        }
    }

    public class Novel : Works
    {
        public override void bookmark()
        {
            //
        }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string account { get; set; }
        public string[] image_urls { get; set; }
        public bool is_followed { get; set; }
    }

    public class Series
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}