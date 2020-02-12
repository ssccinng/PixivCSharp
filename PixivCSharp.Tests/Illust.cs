using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    static partial class Login
    {
        static async Task ViewIllust()
        {
            Illust illust;
            Console.Write("Enter the id of the illust to view\n> ");
            string id = Console.ReadLine();
            Console.Clear();
            try
            {
                illust = await Client.ViewIllust(id);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Illust: ");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Illust ID: {0}", illust.id.ToString());
            Console.WriteLine("Illust title: {0}", illust.title);
            Console.WriteLine("Illust type: {0}", illust.type);
            Console.WriteLine("Illust image urls: {0}", illust.image_urls.large);
            Console.WriteLine("Illust caption: {0}", illust.caption);
            Console.WriteLine("Illust restrict: {0}", illust.restrict.ToString());
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("User:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("User id: {0}", illust.user.id.ToString());
            Console.WriteLine("User name: {0}", illust.user.name);
            Console.WriteLine("User account: {0}", illust.user.account);
            Console.WriteLine("User profile picture url: {0}", illust.user.profile_image_urls.medium);
            Console.WriteLine("Is user followed: {0}", illust.user.is_followed);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Illust tag: {0} | Illust translated tag: {1}", illust.tags[0].name, illust.tags[0].translated_name);
            if (illust.tools.Length != 0) Console.WriteLine("Illust tools: {0}", illust.tools[0]);
            Console.WriteLine("Illust creation date: {0}", illust.create_date);
            Console.WriteLine("Illust page count: {0}", illust.page_count.ToString());
            Console.WriteLine("Illust width: {0}", illust.width.ToString());
            Console.WriteLine("Illust height: {0}", illust.height.ToString());
            Console.WriteLine("Illust sanity level: {0}", illust.sanity_level.ToString());
            Console.WriteLine("Illust x restrict: {0}", illust.x_restrict.ToString());
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Series:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            if (illust.series != null)
            {
                Console.WriteLine("Series ID: {0}", illust.series.id);
                Console.WriteLine("Series title: {0}", illust.series.title);
            }
            else
            {
                Console.WriteLine("Not part of a series");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            if (illust.meta_single_page != null)
            {
                Console.WriteLine("Page url: {0}", illust.meta_single_page.original_image_url);
            }
            else if (illust.meta_single_page == null)
            {
                Console.WriteLine("First page url: {0}", illust.meta_pages[0].image_urls.original);
            }
            Console.WriteLine("Illust view count: {0}", illust.total_view.ToString());
            Console.WriteLine("Illust bookmarks: {0}", illust.total_bookmarks.ToString());
            Console.WriteLine("Is illust visible: {0}", illust.visible);
            Console.WriteLine("Is illust muted: {0}", illust.is_muted);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        static async Task TimeTest()
        {
            Stopwatch timer = new Stopwatch();
            IllustSearchResult list = await Client.WalkthoughIllusts();
            timer.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list.illusts[i].image_urls.square_medium);
                Stream image = await Client.GetImage(list.illusts[i].image_urls.square_medium);
            }
            timer.Stop();
            Console.WriteLine(timer.Elapsed.Seconds);
        }
    }
}