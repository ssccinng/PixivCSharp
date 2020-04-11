using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        // Tests searching for illusts
        private static async Task ViewIllustSearch()
        {
            IllustSearchResult result;
            Console.Write("Please enter tags to search for\n> ");
            
            // Error handling
            try
            {
                result = await Client.SearchIllustsAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Illust search result:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in result.Illusts)
            {
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Next URL: {0}", result.NextUrl);
        }

        // Tests searching for novels
        private static async Task ViewNovelSearch()
        {
            NovelSearchResult result;
            Console.Write("Please enter the tags to search for\n> ");
            
            // Error handling
            try
            {
                result = await Client.SearchNovelsAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Novel search result:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Novel novel in result.Novels)
            {
                Output.TestNovel(novel);
            }
            
            Console.WriteLine("Next URL: {0}", result.NextUrl);
        }
        
        // Tests searching for users
        private static async Task ViewUserSearch()
        {
            UserSearchResult result;
            Console.Write("Please enter the name of the user to search for\n> ");
            
            // Error handling
            try
            {
                result = await Client.SearchUsersAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("User search result:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (UserPreview user in result.UserPreviews)
            {
                Output.TestUser(user.User);
                Output.TestIllust(user.Illusts[0]);
            }
            
            Console.WriteLine("Next URL: {0}", result.NextUrl);
        }
        
        // Tests viewing autocomplete tags
        private static async Task ViewAutocompleteTags()
        {
            Tag[] result;
            Console.Write("Please enter input to produce autocomplete tags for\n> ");
            
            // Error handling
            try
            {
                result = await Client.AutocompleteTagAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Autocomplete tags:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Tag tag in result)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Name: {0}", tag.Name);
                Console.WriteLine("Translated name: {0}", tag.TranslatedName);
            }
        }
        
        // Tests viewing popular illust previews
        private static async Task ViewPopularIllustPreview()
        {
            IllustSearchResult result;
            Console.Write("Please enter the term to search\n> ");
            
            // Error handling
            try
            {
                result = await Client.PopularIllustsPreviewAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Popular illusts preview:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in result.Illusts)
            {
                Output.TestIllust(illust);
            }
        }
        
        // Tests viewing popular novel previews
        private static async Task ViewPopularNovelsPreview()
        {
            NovelSearchResult result;
            Console.Write("Please enter the term to search\n> ");
            
            // Error handling
            try
            {
                result = await Client.PopularNovelsPreviewAsync(Console.ReadLine());
            }

            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Popular novels preview:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Novel novel in result.Novels)
            {
                Output.TestNovel(novel);
            }
        }
    }
}