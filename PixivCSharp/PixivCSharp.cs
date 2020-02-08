using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public class Pixiv
    {
        public Pixiv()
        {
            WebRequests.ClientInit();
        }
        public IllustSearchResult WalkthoughIllusts()
        {
            //Retrieves walkthrough illusts and converts to json
            IllustSearchResult result = new IllustSearchResult();
            string response = WebRequests.Request(PixivUrls.WalkthroughIllusts).Result;
            JObject json = JObject.Parse(response);
            JArray illusts = (JArray)json["illusts"];

            //converts json to IllustSearchResults object and returns object
            foreach (JToken illust in illusts)
            {
                Illust newIllust = new Illust
                {
                    id = (int)illust["id"],
                    title = (string)illust["title"],
                    type = (string)illust["type"],
                    image_urls = (illust["image_urls"]).ToObject<IllustImageUrls>(),
                    caption = (string)illust["caption"],
                    restrict = (int)illust["restrict"],
                    user =
                        new User()
                        {
                            id = (int)illust["user"]["id"],
                            name = (string)illust["user"]["name"],
                            account = (string)illust["user"]["account"],
                            profile_image_urls = (illust["user"]["profile_image_urls"]).ToObject<ImageUrls>(),
                            is_followed = (bool)illust["user"]["is_followed"]
                        },
                    tags = ((JArray)illust["tags"]).ToObject<Tag[]>(),
                    tools = ((JArray)illust["tools"]).ToObject<string[]>(),
                    create_date = (string)illust["create_date"],
                    page_count = (int)illust["page_count"],
                    width = (int)illust["width"],
                    height = (int)illust["height"],
                    sanity_level = (int)illust["sanity_level"],
                    x_restrict = (int)illust["x_restrict"],
                    series = (illust["series"]).ToObject<Series>(),
                    meta_single_page = (illust["meta_single_page"]).ToObject<MetaSinglePage>(),
                    meta_pages = (illust["meta_pages"]).ToObject<MetaPages[]>(),
                    total_view = (int)illust["total_view"],
                    total_bookmarks = (int)illust["total_bookmarks"],
                    is_bookmarked = (bool)illust["is_bookmarked"],
                    visible = (bool)illust["visible"],
                    is_muted = (bool)illust["is_muted"]
                };

                result.illusts.Add(newIllust);
            }
            result.next_url = (string)json["next_url"];
            return result;
        }
    }
    
    class Auth
    {
        
    }
}