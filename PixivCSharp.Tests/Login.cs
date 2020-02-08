using System;

namespace PixivCSharp.Tests
{
    class Login
    {
        private static Pixiv client;
        static void Main(string[] args)
        {
            client = new Pixiv();
            Walkthrough();
        }

        static void Walkthrough()
        {
            IllustSearchResult walkthough = client.WalkthoughIllusts();

            Console.WriteLine("Walkthough Illusts: ");

            foreach (Illust illust in walkthough.illusts)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine(illust.id.ToString());
                Console.WriteLine(illust.title);
                Console.WriteLine(illust.type);
                Console.WriteLine(illust.image_urls.large);
                Console.WriteLine(illust.caption);
                Console.WriteLine(illust.restrict.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("User:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine(illust.user.id.ToString());
                Console.WriteLine(illust.user.name);
                Console.WriteLine(illust.user.account);
                Console.WriteLine(illust.user.profile_image_urls.medium);
                Console.WriteLine(illust.user.is_followed);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("{0} | {1}", illust.tags[0].name, illust.tags[0].translated_name);
                if (illust.tools.Length != 0) Console.WriteLine(illust.tools[0]);
                Console.WriteLine(illust.create_date);
                Console.WriteLine(illust.page_count.ToString());
                Console.WriteLine(illust.page_count.ToString());
                Console.WriteLine(illust.width.ToString());
                Console.WriteLine(illust.height.ToString());
                Console.WriteLine(illust.sanity_level.ToString());
                Console.WriteLine(illust.x_restrict.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Series:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                if (illust.series != null)
                {
                    Console.WriteLine(illust.series.id);
                    Console.WriteLine(illust.series.title);
                }
                else
                {
                    Console.WriteLine("Not part of a series");
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
                if (illust.meta_single_page != null)
                {
                    Console.WriteLine(illust.meta_single_page.original_image_url);
                }
                else if (illust.meta_single_page == null)
                {
                    Console.WriteLine(illust.meta_pages[0].image_urls.original);
                }
                Console.WriteLine(illust.total_view.ToString());
                Console.WriteLine(illust.total_bookmarks.ToString());
                Console.WriteLine(illust.visible);
                Console.WriteLine(illust.is_muted);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }

            Console.WriteLine(walkthough.next_url);
            Console.WriteLine("\n\n\n");
        }
    }
}