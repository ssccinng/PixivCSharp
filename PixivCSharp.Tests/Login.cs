using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    static partial class Tests
    {
        // Walkthrough illusts test
        static async Task Walkthrough()
        {
            IllustSearchResult walkthough = await Client.WalkthoughIllustsAsync();

            Console.WriteLine("Walkthough Illusts: ");

            foreach (Illust illust in walkthough.Illusts)
            {
                Output.TestIllust(illust);
            }

            Console.WriteLine("Next url: {0}", walkthough.NextUrl);
            Console.WriteLine("\n\n\n");
        }

        // Emoji Test
        public static async Task EmojiList()
        {
            EmojiList emojis = await Client.EmojiListAsync();
            
            Console.WriteLine("Emojis: ");

            foreach (EmojiDef emoji in emojis.EmojiDefinitions)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Emoji ID: {0}", emoji.ID.ToString());
                Console.WriteLine("Emoji slug: {0}", emoji.Slug);
                Console.WriteLine("Emoji image url: {0}", emoji.ImageUrlMedium);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            
            Console.WriteLine("\n\n\n");
        }
        
        // Password login test
        static async Task FirstLogin()
        {
            LoginResponse response;
            Console.Write("Please enter your username\n> ");
            string username = Console.ReadLine();
            Console.Write("Please enter your password\n> ");
            string password = Console.ReadLine();
            Console.Clear();

            // Error handling
            try
            {
                response = await Client.LoginAsync(username, password);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("An error occured. Status code: {0}", e.Message);
                return;
            }

            Console.WriteLine("Login respones");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Access token: {0}", response.AccessToken);
            Console.WriteLine("expires in: {0}", response.ExpiresIn);
            Console.WriteLine("token_type: {0}", response.TokenType);
            Console.WriteLine("scope: {0}", response.Scope);
            Console.WriteLine("refresh_token: {0}", response.RefreshToken);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("User: ");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("profile_image_url: {0}", response.User.ProfileImageUrls.Px170x170);
            Console.WriteLine("User ID: {0}", response.User.ID);
            Console.WriteLine("Username: {0}", response.User.Name);
            Console.WriteLine("User account: {0}", response.User.Account);
            Console.WriteLine("Mail address: {0}", response.User.MailAddress);
            Console.WriteLine("Is premium: {0}", response.User.IsPremium);
            Console.WriteLine("X restrict: {0}", response.User.XRestrict);
            Console.WriteLine("Is mail authorised: {0}", response.User.IsMailAuthorized);
            Console.WriteLine("Require policy agreement: {0}", response.User.RequirePolicyAggreement);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Device token: {0}", response.DeviceToken);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\n");
            
            // Stores tokens in local storage
            string[] tokens = new string[3] { response.AccessToken, response.RefreshToken, response.DeviceToken };
            string tokenSring = String.Join(",", tokens);
            StoreTokens(tokenSring);
        }
        
        static async Task RefreshToken()
        {
            LoginResponse response;
            
            // Checks tokens are set
            if (Client.CheckTokens())
            {
                Console.WriteLine("Please login to obtain access tokens before testing login refresh.");
                return;
            }

            // Error handling
            try
            {
                response = await Client.RefreshLoginAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("An error occured. Status code: {0}", e.Message);
                return;
            }
            
            Console.WriteLine("Login respones");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Access token: {0}", response.AccessToken);
            Console.WriteLine("expires in: {0}", response.ExpiresIn);
            Console.WriteLine("token_type: {0}", response.TokenType);
            Console.WriteLine("scope: {0}", response.Scope);
            Console.WriteLine("refresh_token: {0}", response.RefreshToken);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("User: ");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("profile_image_url: {0}", response.User.ProfileImageUrls.Px170x170);
            Console.WriteLine("User ID: {0}", response.User.ID);
            Console.WriteLine("Username: {0}", response.User.Name);
            Console.WriteLine("User account: {0}", response.User.Account);
            Console.WriteLine("Mail address: {0}", response.User.MailAddress);
            Console.WriteLine("Is premium: {0}", response.User.IsPremium);
            Console.WriteLine("X restrict: {0}", response.User.XRestrict);
            Console.WriteLine("Is mail authorised: {0}", response.User.IsMailAuthorized);
            Console.WriteLine("Require policy agreement: {0}", response.User.RequirePolicyAggreement);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Device token: {0}", response.DeviceToken);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\n");
            
            // Stores tokens in local storage
            string[] tokens = new string[3] { response.AccessToken, response.RefreshToken, response.DeviceToken };
            string tokenSring = String.Join(",", tokens);
            StoreTokens(tokenSring);
        }
    }
}