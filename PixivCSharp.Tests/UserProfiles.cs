using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        // Tests viewing user profiles
        private static async Task ViewProfile()
        {
            UserDetail result;
            Console.Write("Please enter the id of a user to view\n> ");
            
            // Error handling
            try
            {
                result = await Client.ViewProfileAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("User:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Output.TestUser(result.User);
            Console.WriteLine("User profile:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Webpage: {0}", result.Profile.WebPage);
            Console.WriteLine("Gender: {0}", result.Profile.Gender);
            Console.WriteLine("Birth: {0}", result.Profile.Birth);
            Console.WriteLine("Birthday: {0}", result.Profile.BirthDay);
            Console.WriteLine("Birth year: {0}", result.Profile.BirthYear);
            Console.WriteLine("Region: {0}", result.Profile.Region);
            Console.WriteLine("AddressID: {0}", result.Profile.AddressID);
            Console.WriteLine("Country code: {0}", result.Profile.CountryCode);
            Console.WriteLine("Job: {0}", result.Profile.CountryCode);
            Console.WriteLine("Job ID: {0}", result.Profile.JobID);
            Console.WriteLine("Followers: {0}", result.Profile.Followers);
            Console.WriteLine("My Pixiv Users: {0}", result.Profile.MyPixivUsers);
            Console.WriteLine("Illusts: {0}", result.Profile.Illusts);
            Console.WriteLine("Manga: {0}", result.Profile.Manga);
            Console.WriteLine("Novels: {0}", result.Profile.Novels);
            Console.WriteLine("Public illust bookmarks: {0}", result.Profile.IllustBookmarks);
            Console.WriteLine("Illust series: {0}", result.Profile.IllustSeries);
            Console.WriteLine("Novel series: {0}", result.Profile.NovelSeries);
            Console.WriteLine("Background image url: {0}", result.Profile.BackgroundUrl);
            Console.WriteLine("Twitter account: {0}", result.Profile.TwitterAccount);
            Console.WriteLine("Twitter Url: {0}", result.Profile.TwitterUrl);
            Console.WriteLine("Pawoo Url: {0}", result.Profile.PawooUrl);
            Console.WriteLine("Is premium: {0}", result.Profile.IsPremium);
            Console.WriteLine("Is using custom profile image: {0}", result.Profile.CustomProfileImage);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Profile publicity:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Gender: {0}", result.ProfilePublicity.Gender);
            Console.WriteLine("Region: {0}", result.ProfilePublicity.Region);
            Console.WriteLine("Birthday: {0}", result.ProfilePublicity.BirthDay);
            Console.WriteLine("Birth year: {0}", result.ProfilePublicity.BirthYear);
            Console.WriteLine("Job: {0}", result.ProfilePublicity.Job);
            Console.WriteLine("Pawoo: {0}", result.ProfilePublicity.Pawoo);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Workspace:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("PC: {0}", result.Workspace.PC);
            Console.WriteLine("Monitor: {0}", result.Workspace.Monitor);
            Console.WriteLine("Tool: {0}", result.Workspace.Tool);
            Console.WriteLine("Scanner: {0}", result.Workspace.Scanner);
            Console.WriteLine("Tablet: {0}", result.Workspace.Tablet);
            Console.WriteLine("Mouse: {0}", result.Workspace.Mouse);
            Console.WriteLine("Printer: {0}", result.Workspace.Printer);
            Console.WriteLine("Desktop: {0}", result.Workspace.Desktop);
            Console.WriteLine("Music: {0}", result.Workspace.Music);
            Console.WriteLine("Desk: {0}", result.Workspace.Desk);
            Console.WriteLine("Chair: {0}", result.Workspace.Chair);
            Console.WriteLine("Comment: {0}", result.Workspace.Commment);
            Console.WriteLine("Workspace image url: {0}", result.Workspace.WorkspaceImageUrl);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }
        
        // Tests viewing a user's illusts
        private static async Task ViewUserIllusts()
        {
            IllustSearchResult result;
            Console.Write("Please enter the ID of the user to view illusts from\n> ");
            
            // Error handling
            try
            {
                result = await Client.UserIllustsAsync(Console.ReadLine(), "illust");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("User illusts:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in result.Illusts)
            {
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Next url: {0}", result.NextUrl);
        }
        
        // Tests viewing a user's novels
        private static async Task ViewUserNovels()
        {
            NovelSearchResult result;
            Console.Write("Please enter the ID of the user to view novels from\n> ");
            
            // Error handling
            try
            {
                result = await Client.UserNovelsAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("User novels:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Novel novel in result.Novels)
            {
                Output.TestNovel(novel);
            }
            
            Console.WriteLine("Next url: {0}", result.NextUrl);
        }
        
        // Tests viewing a user's bookmarked illusts
        private static async Task ViewBookmarkedIllusts()
        {
            IllustSearchResult result;
            Console.Write("Please enter the id of the user to view bookmarked illusts of\n> ");
            
            // Error handling
            try
            {
                result = await Client.BookmarkedIllustsAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Bookmarked illusts:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in result.Illusts)
            {
                Output.TestIllust(illust);
            }

            Console.WriteLine("Next url: {0}", result.NextUrl);
        }
        
        // Tests viewing a user's bookmarked novels
        private static async Task ViewBookmarkedNovels()
        {
            NovelSearchResult result;
            Console.Write("Please enter the id of the user to view bookmarked novels of\n> ");
            
            // Error handling
            try
            {
                result = await Client.BookmarkedNovelsAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Bookmarked novels:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Novel novel in result.Novels)
            {
                Output.TestNovel(novel);
            }
            
            Console.WriteLine("Next url: {0}", result.NextUrl);
        }
        
        // Tests viewing followers
        private static async Task ViewFollowers()
        {
            UserSearchResult result;
            
            // Errror handling
            try
            {
                result = await Client.FollowersAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Followers:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (UserPreview userPreview in result.UserPreviews)
            {
                Output.TestUser(userPreview.User);
                Output.TestIllust(userPreview.Illusts[0]);
            }

            Console.WriteLine("Next URL: {0}", result.NextUrl);
        }
        
        // Tests viewing followed users
        private static async Task ViewFollowing()
        {
            UserSearchResult result;
            Console.Write("Enter the user id of the user followed accounts of\n> ");
            
            // Error handling
            try
            {
                result = await Client.FollowingAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Accounts followed by 30249784:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (UserPreview userPreview in result.UserPreviews)
            {
                Output.TestUser(userPreview.User);
                Output.TestIllust(userPreview.Illusts[0]);
            }
            
            Console.WriteLine("Next URL: {0}", result.NextUrl);
        }

        // Tests viewing users on a profile's my pixiv list
        private static async Task ViewMyPixiv()
        {
            UserSearchResult result;
            Console.Write("Please enter the user view my pixiv users of\n> ");
            
            // Error handling
            try
            {
                result = await Client.MyPixivAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("My Pixiv Accounts:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (UserPreview userPreview in result.UserPreviews)
            {
                Output.TestUser(userPreview.User);
                Output.TestIllust(userPreview.Illusts[0]);
            }
            
            Console.WriteLine("Next URL: {0}", result.NextUrl);
        }
        
        // Tests following a user
        private static async Task FollowUser()
        {
            Console.Write("Please enter the ID of the user to follow\n> ");
            
            // Error handling
            try
            {
                await Client.FollowAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        // Tests unfollowing a user
        private static async Task UnFollowUser()
        {
            Console.Write("Please enter the ID of the user to unfollow\n> ");
            
            // Error handling
            try
            {
                await Client.RemoveFollowAsync(Console.ReadLine());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}