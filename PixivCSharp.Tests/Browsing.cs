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
            
            Console.WriteLine("Illusts");
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

            Console.WriteLine("Illusts");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in result.Illusts)
            {
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Next URL: " + result.NextUrl);
        }
    }
}