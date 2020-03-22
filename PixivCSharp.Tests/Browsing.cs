using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        // Test viewing new illusts
        private static async Task ViewNewIllusts()
        {
            IllustSearchResult result;
            
            // Error handling
            try
            {
                result = await Client.NewIllustsAsync("illust");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("New illusts");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in result.Illusts)
            {
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Next URL: " + result.NextUrl);
        }
        
        // Tests viewing new illusts from followed accounts
        private static async Task ViewNewFollowIllusts()
        {
            IllustSearchResult result;
            
            // Error handling
            try
            {
                result = await Client.NewFollowIllustsAsync("all");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("New illusts from following");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in result.Illusts)
            {
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Next URL: " + result.NextUrl);
        }
        
        // Tests viewing new illusts from my pixiv accounts
        private static async Task ViewNewMyPixivIllusts()
        {
            IllustSearchResult result;
            
            // Error handling
            try
            {
                result = await Client.NewMyPixivIllustsAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("New illusts from my pixiv");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in result.Illusts)
            {
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Next URL: " + result.NextUrl);
        }
        
        // Tests viewing new novels
        private static async Task ViewNewNovels()
        {
            NovelSearchResult result;
            
            // Error handling
            try
            {
                result = await Client.NewNovelsAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("New novels");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Novel novel in result.Novels)
            {
                Output.TestNovel(novel);
            }
            
            Console.WriteLine("Next URL: " + result.NextUrl);
        }
        
        // Tests viewing novels from following
        private static async Task ViewNewFollowNovels()
        {
            NovelSearchResult result;
            
            // Error handling
            try
            {
                result = await Client.NewFollowNovelsAsync("public");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("New novels from following");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Novel novel in result.Novels)
            {
                Output.TestNovel(novel);
            }
            
            Console.WriteLine("Next URL: " + result.NextUrl);
        }
        
        // Tests new viewing novels from mypixiv
        private static async Task ViewNewMyPixivNovels()
        {
            NovelSearchResult result;
            
            // Error handling
            try
            {
                result = await Client.NewMyPixivNovelsAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("New novels from my pixiv");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Novel novel in result.Novels)
            {
                Output.TestNovel(novel);
            }
            
            Console.WriteLine("Next URL: " + result.NextUrl);
        }
    }
}