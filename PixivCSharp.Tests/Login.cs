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

            foreach (Illust illust in walkthough.illusts)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust ID: {0}", illust.ID.ToString());
                Console.WriteLine("Illust title: {0}", illust.Title);
                Console.WriteLine("Illust type: {0}", illust.Type);
                Console.WriteLine("Illust medium image url: {0}", illust.ImageUrls.Medium);
                Console.WriteLine("Illust square medium url: {0}", illust.ImageUrls.SquareMedium);
                Console.WriteLine("Illust large image url: {0}", illust.ImageUrls.large);
                Console.WriteLine("Illust caption: {0}", illust.Caption);
                Console.WriteLine("Illust restrict: {0}", illust.Restrict.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("User:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("User id: {0}", illust.User.ID.ToString());
                Console.WriteLine("User name: {0}", illust.User.Name);
                Console.WriteLine("User account: {0}", illust.User.Account);
                Console.WriteLine("User profile picture url: {0}", illust.User.ProfileImageUrls.Medium);
                Console.WriteLine("Is user followed: {0}", illust.User.IsFollowed);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust tag: {0} | Illust translated tag: {1}", illust.Tags[0].Name, illust.Tags[0].TranslatedName);
                if (illust.Tools.Length != 0) Console.WriteLine("Illust tools: {0}", illust.Tools[0]);
                Console.WriteLine("Illust creation date: {0}", illust.CreateDate);
                Console.WriteLine("Illust page count: {0}", illust.PageCount.ToString());
                Console.WriteLine("Illust width: {0}", illust.Width.ToString());
                Console.WriteLine("Illust height: {0}", illust.Height.ToString());
                Console.WriteLine("Illust sanity level: {0}", illust.SanityLevel.ToString());
                Console.WriteLine("Illust x restrict: {0}", illust.XRestrict.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Series:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                if (illust.Series != null)
                {
                    Console.WriteLine("Series ID: {0}", illust.Series.ID);
                    Console.WriteLine("Series title: {0}", illust.Series.Title);
                }
                else
                {
                    Console.WriteLine("Not part of a series");
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
                if (illust.MetaSinglePage != null)
                {
                    Console.WriteLine("Page url: {0}", illust.MetaSinglePage.OriginalImageUrl);
                }
                else if (illust.MetaSinglePage == null)
                {
                    Console.WriteLine("First page url: {0}", illust.MetaPages[0].ImageUrls.Original);
                }
                Console.WriteLine("Illust view count: {0}", illust.TotalView.ToString());
                Console.WriteLine("Illust bookmarks: {0}", illust.TotalBookmarks.ToString());
                Console.WriteLine("Is bookmarked: {0}", illust.IsBookmarked);
                Console.WriteLine("Is illust visible: {0}", illust.Visible);
                Console.WriteLine("Is illust muted: {0}", illust.IsMuted);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }

            Console.WriteLine("Next url: {0}", walkthough.next_url);
            Console.WriteLine("\n\n\n");
        }

        // Emoji Test
        public static async Task EmojiList()
        {
            EmojiList emojis = await Client.EmojiListAsync();
            
            Console.WriteLine("Emojis: ");

            foreach (EmojiDef emoji in emojis.emoji_definitions)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Emoji ID: {0}", emoji.id.ToString());
                Console.WriteLine("Emoji slug: {0}", emoji.slug);
                Console.WriteLine("Emoji image url: {0}", emoji.image_url_medium);
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
            Console.WriteLine("Access token: {0}", response.access_token);
            Console.WriteLine("expires in: {0}", response.expires_in);
            Console.WriteLine("token_type: {0}", response.token_type);
            Console.WriteLine("scope: {0}", response.scope);
            Console.WriteLine("refresh_token: {0}", response.refresh_token);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("User: ");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("profile_image_url: {0}", response.user.ProfileImageUrls.Px170x170);
            Console.WriteLine("User ID: {0}", response.user.ID);
            Console.WriteLine("Username: {0}", response.user.Name);
            Console.WriteLine("User account: {0}", response.user.Account);
            Console.WriteLine("Mail address: {0}", response.user.MailAddress);
            Console.WriteLine("Is premium: {0}", response.user.IsPremium);
            Console.WriteLine("X restrict: {0}", response.user.XRestrict);
            Console.WriteLine("Is mail authorised: {0}", response.user.IsMailAuthorized);
            Console.WriteLine("Require policy agreement: {0}", response.user.RequirePolicyAggreement);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Device token: {0}", response.device_token);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\n");
            
            // Stores tokens in local storage
            string[] tokens = new string[3] { response.access_token, response.refresh_token, response.device_token };
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
            Console.WriteLine("Access token: {0}", response.access_token);
            Console.WriteLine("expires in: {0}", response.expires_in);
            Console.WriteLine("token_type: {0}", response.token_type);
            Console.WriteLine("scope: {0}", response.scope);
            Console.WriteLine("refresh_token: {0}", response.refresh_token);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("User: ");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("profile_image_url: {0}", response.user.ProfileImageUrls.Px170x170);
            Console.WriteLine("User ID: {0}", response.user.ID);
            Console.WriteLine("Username: {0}", response.user.Name);
            Console.WriteLine("User account: {0}", response.user.Account);
            Console.WriteLine("Mail address: {0}", response.user.MailAddress);
            Console.WriteLine("Is premium: {0}", response.user.IsPremium);
            Console.WriteLine("X restrict: {0}", response.user.XRestrict);
            Console.WriteLine("Is mail authorised: {0}", response.user.IsMailAuthorized);
            Console.WriteLine("Require policy agreement: {0}", response.user.RequirePolicyAggreement);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Device token: {0}", response.device_token);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\n");
            
            // Stores tokens in local storage
            string[] tokens = new string[3] { response.access_token, response.refresh_token, response.device_token };
            string tokenSring = String.Join(",", tokens);
            StoreTokens(tokenSring);
        }
    }
}