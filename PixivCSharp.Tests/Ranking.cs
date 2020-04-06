using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        // Tests viewing ranking illusts
        private static async Task ViewRankingIllusts()
        {
            IllustSearchResult result;

            // Error handling
            try
            {
                result = await Client.RankingIllustsAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Ranking Illusts:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in result.Illusts)
            {
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Next URL: {0}", result.NextUrl);
        }
        
        // Tests viewing ranking novels
        private static async Task ViewRankingNovels()
        {
            NovelSearchResult result;
            
            // Error handling
            try
            {
                result = await Client.RankingNovelsAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            foreach (Novel novel in result.Novels)
            {
                Output.TestNovel(novel);
            }
            
            Console.WriteLine("Next URL: {0}", result.NextUrl);
        }
    }
}