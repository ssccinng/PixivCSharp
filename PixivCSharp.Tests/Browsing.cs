using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        // View recommended illust test
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
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Ranking illusts");
            
            foreach (Illust illust in recIllusts.RankingIllusts)
            {
                Output.TestIllust(illust);
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