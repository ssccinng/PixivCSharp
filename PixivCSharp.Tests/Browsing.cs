using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        private static async Task ViewRecommendedIllusts()
        {
            RecommendedIllusts recIllusts;

            // Error handling
            try
            {
                recIllusts = await Client.RecommendedIllustsAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Recommended illusts");
            Console.WriteLine("-------------------------------------------------------------------------------");
            
            foreach (Illust illust in recIllusts.Illusts)
            {
                Console.WriteLine("Illust: ");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust ID: {0}", illust.ID.ToString());
                Console.WriteLine("Illust title: {0}", illust.Title);
                Console.WriteLine("Illust type: {0}", illust.Type);
                Console.WriteLine("Illust medium image url: {0}", illust.ImageUrls.Medium);
                Console.WriteLine("Illust square medium url: {0}", illust.ImageUrls.SquareMedium);
                Console.WriteLine("Illust large image url: {0}", illust.ImageUrls.large);
                Console.WriteLine("Illust caption: {0}", illust.Caption);
                Console.WriteLine("Illust restrict: {0}", illust.Restrict.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("User:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("User id: {0}", illust.User.ID.ToString());
                Console.WriteLine("User name: {0}", illust.User.Name);
                Console.WriteLine("User account: {0}", illust.User.Account);
                Console.WriteLine("User profile picture url: {0}", illust.User.ProfileImageUrls.Medium);
                Console.WriteLine("Is user followed: {0}", illust.User.IsFollowed);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust tag: {0} | Illust translated tag: {1}", illust.Tags[0].Name,
                    illust.Tags[0].TranslatedName);
                if (illust.Tools.Length != 0) Console.WriteLine("Illust tools: {0}", illust.Tools[0]);
                Console.WriteLine("Illust creation date: {0}", illust.CreateDate);
                Console.WriteLine("Illust page count: {0}", illust.PageCount.ToString());
                Console.WriteLine("Illust width: {0}", illust.Width.ToString());
                Console.WriteLine("Illust height: {0}", illust.Height.ToString());
                Console.WriteLine("Illust sanity level: {0}", illust.SanityLevel.ToString());
                Console.WriteLine("Illust x restrict: {0}", illust.XRestrict.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Series:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                if (illust.Series != null)
                {
                    Console.WriteLine("Series ID: {0}", illust.Series.ID);
                    Console.WriteLine("Series title: {0}", illust.Series.Title);
                }
                else
                {
                    Console.WriteLine("Not part of a series");
                }

                Console.WriteLine("-------------------------------------------------------------------------------");
                if (illust.MetaSinglePage != null)
                    Console.WriteLine("Page url: {0}", illust.MetaSinglePage.OriginalImageUrl);
                else if (illust.MetaSinglePage == null)
                    Console.WriteLine("First page url: {0}", illust.MetaPages[0].ImageUrls.Original);
                Console.WriteLine("Illust view count: {0}", illust.TotalView.ToString());
                Console.WriteLine("Illust bookmarks: {0}", illust.TotalBookmarks.ToString());
                Console.WriteLine("Is bookmarked: {0}", illust.IsBookmarked);
                Console.WriteLine("Is illust visible: {0}", illust.Visible);
                Console.WriteLine("Is illust muted: {0}", illust.IsMuted);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            
            Console.WriteLine("Ranking illusts");
            
            foreach (Illust illust in recIllusts.RankingIllusts)
            {
                Console.WriteLine("Illust: ");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust ID: {0}", illust.ID.ToString());
                Console.WriteLine("Illust title: {0}", illust.Title);
                Console.WriteLine("Illust type: {0}", illust.Type);
                Console.WriteLine("Illust medium image url: {0}", illust.ImageUrls.Medium);
                Console.WriteLine("Illust square medium url: {0}", illust.ImageUrls.SquareMedium);
                Console.WriteLine("Illust large image url: {0}", illust.ImageUrls.large);
                Console.WriteLine("Illust caption: {0}", illust.Caption);
                Console.WriteLine("Illust restrict: {0}", illust.Restrict.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("User:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("User id: {0}", illust.User.ID.ToString());
                Console.WriteLine("User name: {0}", illust.User.Name);
                Console.WriteLine("User account: {0}", illust.User.Account);
                Console.WriteLine("User profile picture url: {0}", illust.User.ProfileImageUrls.Medium);
                Console.WriteLine("Is user followed: {0}", illust.User.IsFollowed);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust tag: {0} | Illust translated tag: {1}", illust.Tags[0].Name,
                    illust.Tags[0].TranslatedName);
                if (illust.Tools.Length != 0) Console.WriteLine("Illust tools: {0}", illust.Tools[0]);
                Console.WriteLine("Illust creation date: {0}", illust.CreateDate);
                Console.WriteLine("Illust page count: {0}", illust.PageCount.ToString());
                Console.WriteLine("Illust width: {0}", illust.Width.ToString());
                Console.WriteLine("Illust height: {0}", illust.Height.ToString());
                Console.WriteLine("Illust sanity level: {0}", illust.SanityLevel.ToString());
                Console.WriteLine("Illust x restrict: {0}", illust.XRestrict.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Series:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                if (illust.Series != null)
                {
                    Console.WriteLine("Series ID: {0}", illust.Series.ID);
                    Console.WriteLine("Series title: {0}", illust.Series.Title);
                }
                else
                {
                    Console.WriteLine("Not part of a series");
                }

                Console.WriteLine("-------------------------------------------------------------------------------");
                if (illust.MetaSinglePage != null)
                    Console.WriteLine("Page url: {0}", illust.MetaSinglePage.OriginalImageUrl);
                else if (illust.MetaSinglePage == null)
                    Console.WriteLine("First page url: {0}", illust.MetaPages[0].ImageUrls.Original);
                Console.WriteLine("Illust view count: {0}", illust.TotalView.ToString());
                Console.WriteLine("Illust bookmarks: {0}", illust.TotalBookmarks.ToString());
                Console.WriteLine("Is bookmarked: {0}", illust.IsBookmarked);
                Console.WriteLine("Is illust visible: {0}", illust.Visible);
                Console.WriteLine("Is illust muted: {0}", illust.IsMuted);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            
            Console.WriteLine("Content exists: " + recIllusts.ContentExists);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Privacy Policy");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Version: " + recIllusts.PrivacyPolicy.Version);
            Console.WriteLine("Message: " + recIllusts.PrivacyPolicy.Message);
            Console.WriteLine("URL: " + recIllusts.PrivacyPolicy.URL);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Next Url: " + recIllusts.NextUrl);
        }
    }
}