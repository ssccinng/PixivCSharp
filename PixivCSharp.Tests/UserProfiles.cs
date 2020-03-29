using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        private static async Task ViewProfile()
        {
            UserDetail result;
            Console.WriteLine("Please enter the id of a user to view");
            
            // Error handling
            try
            {
                result = await Client.ViewProfile(Console.ReadLine());
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
    }
}