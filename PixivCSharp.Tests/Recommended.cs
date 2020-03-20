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
        
        // View recommended manga test
        private static async Task ViewRecommendedManga()
        {
            RecommendedIllusts recommendedManga;
            
            // Error handling
            try
            {
                recommendedManga = await Client.RecommendedMangaAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Recommended manga");
            Console.WriteLine("-------------------------------------------------------------------------------");
            
            foreach (Illust illust in recommendedManga.Illusts)
            {
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Ranking manga");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in recommendedManga.RankingIllusts)
            {
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Content exists: " + recommendedManga.ContentExists);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Privacy Policy");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Version: " + recommendedManga.PrivacyPolicy.Version);
            Console.WriteLine("Message: " + recommendedManga.PrivacyPolicy.Message);
            Console.WriteLine("URL: " + recommendedManga.PrivacyPolicy.URL);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Next Url: " + recommendedManga.NextUrl);
        }

        private static async Task ViewRecommendedNovels()
        {
            RecommendedNovels novels;

            try
            {
                novels = await Client.RecommendedNovelsAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Recommended novels");
            Console.WriteLine("-------------------------------------------------------------------------------");
            
            foreach (Novel novel in novels.Novels)
            {
                Output.TestNovel(novel);
            }
            
            Console.WriteLine("Ranking novels");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Novel novel in novels.RankingNovels)
            {
                Output.TestNovel(novel);
            }
            
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Privacy Policy");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Version: " + novels.PrivacyPolicy.Version);
            Console.WriteLine("Message: " + novels.PrivacyPolicy.Message);
            Console.WriteLine("URL: " + novels.PrivacyPolicy.URL);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Next Url: " + novels.NextUrl);
        }

        // Tests recommended users
        private static async Task ViewRecommendedUsers()
        {
            RecommendedUsers recommendedUsers;
            
            // Error handling
            try
            {
                recommendedUsers = await Client.RecommendedUsersAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            foreach (UserPreview userPreview in recommendedUsers.UserPreviews)
            {
                Output.TestUser(userPreview.User);
                Output.TestIllust(userPreview.Illusts[0]);
            }
            
            Console.WriteLine("Next URL: " + recommendedUsers.NextUrl);
        }
    }
}