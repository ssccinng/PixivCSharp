using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            Stopwatch timer = new Stopwatch();
            timer.Start();

            List<Illust> illusts = list.Illusts.GetRange(0, 10);
            var tasks = illusts.Select(async x =>
            {
                string filename = x.MetaSinglePage.OriginalImageUrl.Split("/").Last();
                Stream image = await Client.GetImageAsync(x.ImageUrls.SquareMedium);
                FileStream file = File.Open(filename, FileMode.OpenOrCreate);
                await image.CopyToAsync(file);
            });

            await Task.WhenAll(tasks);
            
            timer.Stop();
            Console.WriteLine(timer.Elapsed.TotalMilliseconds);
        }

        // Download image test
        static async Task DownloadImageTest()
        {
            Console.Write("Enter the ID of the image to download\n> ");
            
            // Error handling
            try
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                Illust result = await Client.ViewIllustAsync(Console.ReadLine());
                string url = result.MetaSinglePage.OriginalImageUrl ?? result.MetaPages[0].ImageUrls.Original;
                Stream image = await Client.GetImageAsync(url);
                using (FileStream file = File.Open(url.Split("/").Last(), FileMode.OpenOrCreate))
                {
                    await image.CopyToAsync(file);
                }

                timer.Stop();
                Console.WriteLine(timer.Elapsed.TotalMilliseconds);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
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
            Console.Write("Enter 1 to add a bookmark, enter 2 to remove a bookmark\n> ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter the id of the illust to bookmark\n> ");
                await Client.AddBookmarkIllustAsync(Console.ReadLine(), "public");
            }
            else if (choice == "2")
            {
                Console.Write("Enter the id of illust to remove from bookmarks\n> ");
                await Client.RemoveBookmarkIllustAsync(Console.ReadLine());
            }
        }
    }
}