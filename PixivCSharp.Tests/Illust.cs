using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    static partial class Tests
    {
        // View illust test
        static async Task ViewIllust()
        {
            Illust illust;
            Console.Write("Enter the id of the illust to view\n> ");
            string id = Console.ReadLine();
            Console.Clear();
            
            // Error handling
            try
            {
                illust = await Client.ViewIllustAsync(id);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

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
            Console.WriteLine("Illust tag: {0} | Illust translated tag: {1}", illust.Tags[0].Name, illust.Tags[0].TranslatedName);
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
                Console.WriteLine("Series ID: {0}", illust.Series.id);
                Console.WriteLine("Series title: {0}", illust.Series.title);
            }
            else
            {
                Console.WriteLine("Not part of a series");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            if (illust.MetaSinglePage != null)
            {
                Console.WriteLine("Page url: {0}", illust.MetaSinglePage.OriginalImageUrl);
            }
            else if (illust.MetaSinglePage == null)
            {
                Console.WriteLine("First page url: {0}", illust.MetaPages[0].ImageUrls.Original);
            }
            Console.WriteLine("Illust view count: {0}", illust.TotalView.ToString());
            Console.WriteLine("Illust bookmarks: {0}", illust.TotalBookmarks.ToString());
            Console.WriteLine("Is bookmarked: {0}", illust.IsBookmarked);
            Console.WriteLine("Is illust visible: {0}", illust.Visible);
            Console.WriteLine("Is illust muted: {0}", illust.IsMuted);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        // Download time test
        static async Task TimeTest()
        {
            IllustSearchResult list = await Client.WalkthoughIllustsAsync();
            Task<Stream>[] taskArray = new Task<Stream>[10];
            Stopwatch timer = new Stopwatch();
            timer.Start();
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list.illusts[i].ImageUrls.SquareMedium);
                taskArray[i] = Client.GetImageAsync(list.illusts[i].ImageUrls.SquareMedium);
            }

            for (int i = 0; i < 10; i++)
            {
                Stream image = await taskArray[i];
                using (FileStream filestream = new FileStream((i + ".jpg"), FileMode.OpenOrCreate, FileAccess.Write))
                {
                    image.Seek(0, SeekOrigin.Begin);
                    await image.CopyToAsync(filestream);
                }
            }
            
            timer.Stop();
            Console.WriteLine(timer.Elapsed.Seconds);
        }

        // Download image test
        static async Task DownloadImageTest()
        {
            IllustSearchResult list = await Client.WalkthoughIllustsAsync();
            Stream imageStream = await Client.GetImageAsync(list.illusts[0].ImageUrls.Medium);
            using (FileStream fileStream = new FileStream("test.jpg", FileMode.OpenOrCreate, FileAccess.Write))
            {
                imageStream.Seek(0, SeekOrigin.Begin);
                imageStream.CopyTo(fileStream);
            }
        }

        // Viewing comments test
        static async Task ViewComments()
        {
            CommentList list;
            Console.Write("Enter 1 for comments for an illust, enter 2 for replies to a comment\n> ");
            string choice = Console.ReadLine();
            Console.Clear();

            if (choice == "1")
            {
                Console.Write("Please enter the id of an illust to view comments of\n> ");
                list = await Client.IllustCommentsAsync(Console.ReadLine());
            }
            else if (choice == "2")
            {
                Console.Write("Please enter the id of the comment to view replies to\n> ");
                list = await Client.IllustCommentRepliesAsync(Console.ReadLine());
            }
            else
            {
                return;
            }
            
            
            Console.WriteLine("Comments:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach (Comment comment in list.comments)
            {
                Console.WriteLine("Comment:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Comment ID: {0}", comment.id);
                Console.WriteLine("Comment: {0}", comment.comment);
                Console.WriteLine("Comment date: {0}", comment.date);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("User id: {0}", comment.user.ID.ToString());
                Console.WriteLine("User name: {0}", comment.user.Name);
                Console.WriteLine("User account: {0}", comment.user.Account);
                Console.WriteLine("User profile picture url: {0}", comment.user.ProfileImageUrls.Medium);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Comment has replies: {0}", comment.has_replies);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            Console.WriteLine("Next url: {0}", list.next_url);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        // Tests bookmarks
        static async Task BookmarkIllust()
        {
            Console.Write("Enter 1 to add a bookmark, enter 0 to remove a bookmark\n> ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter the id of the illust to bookmark\n> ");
                await Client.AddBookmarkIllustAsync(Console.ReadLine(), "public");
            }
            else if (choice == "2")
            {
                Console.Write("Enter the id of illust to remove from bookmarks");
                await Client.RemoveBookmarkIllustAsync(Console.ReadLine());
            }
        }
    }
}