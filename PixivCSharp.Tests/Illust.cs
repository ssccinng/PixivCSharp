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

            Output.TestIllust(illust);
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
                Console.WriteLine(list.Illusts[i].ImageUrls.SquareMedium);
                taskArray[i] = Client.GetImageAsync(list.Illusts[i].ImageUrls.SquareMedium);
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
            Stream imageStream = await Client.GetImageAsync(list.Illusts[0].ImageUrls.Medium);
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
            foreach (Comment comment in list.Comments)
            {
                Output.TestComment(comment);
            }
            Console.WriteLine("Next url: {0}", list.NextUrl);
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