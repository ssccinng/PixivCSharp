using System;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    static class Login
    {
        private static PixivClient Client;
        static async Task Main(string[] args)
        {
            //Loops until the user exits
            Client = new PixivClient();
            string choice = string.Empty;
            while (choice != "0")
            {
                Console.WriteLine("Please enter a function to test:\n" +
                                  "1 - Walkthough\n" +
                                  "2 - EmojiList\n" +
                                  "3 - Login\n" +
                                  "4 - Refresh login\n" +
                                  "0 - Exit");
            
                //User choice
                Console.Write("> ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        await Walkthrough();
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        await EmojiList();
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        await FirstLogin();
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        RefreshToken();
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            }
        }

        //Walkthrough illusts test
        static async Task Walkthrough()
        {
            IllustSearchResult walkthough = await Client.WalkthoughIllusts();

            Console.WriteLine("Walkthough Illusts: ");

            foreach (Illust illust in walkthough.illusts)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust ID: {0}", illust.id.ToString());
                Console.WriteLine("Illust title: {0}", illust.title);
                Console.WriteLine("Illust type: {0}", illust.type);
                Console.WriteLine("Illust image urls: {0}", illust.image_urls.large);
                Console.WriteLine("Illust caption: {0}", illust.caption);
                Console.WriteLine("Illust restrict: {0}", illust.restrict.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("User:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("User id: {0}", illust.user.id.ToString());
                Console.WriteLine("User name: {0}", illust.user.name);
                Console.WriteLine("User account: {0}", illust.user.account);
                Console.WriteLine("User profile picture url: {0}", illust.user.profile_image_urls.medium);
                Console.WriteLine("Is user followed: {0}", illust.user.is_followed);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Illust tag: {0} | Illust translated tag: {1}", illust.tags[0].name, illust.tags[0].translated_name);
                if (illust.tools.Length != 0) Console.WriteLine("Illust tools: {0}", illust.tools[0]);
                Console.WriteLine("Illust creation date: {0}", illust.create_date);
                Console.WriteLine("Illust page count: {0}", illust.page_count.ToString());
                Console.WriteLine("Illust width: {0}", illust.width.ToString());
                Console.WriteLine("Illust height: {0}", illust.height.ToString());
                Console.WriteLine("Illust sanity level: {0}", illust.sanity_level.ToString());
                Console.WriteLine("Illust x restrict: {0}", illust.x_restrict.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Series:");
                Console.WriteLine("-------------------------------------------------------------------------------");
                if (illust.series != null)
                {
                    Console.WriteLine("Series ID: {0}", illust.series.id);
                    Console.WriteLine("Series title: {0}", illust.series.title);
                }
                else
                {
                    Console.WriteLine("Not part of a series");
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
                if (illust.meta_single_page != null)
                {
                    Console.WriteLine("Page url: {0}", illust.meta_single_page.original_image_url);
                }
                else if (illust.meta_single_page == null)
                {
                    Console.WriteLine("First page url: {0}", illust.meta_pages[0].image_urls.original);
                }
                Console.WriteLine("Illust view count: {0}", illust.total_view.ToString());
                Console.WriteLine("Illust bookmarks: {0}", illust.total_bookmarks.ToString());
                Console.WriteLine("Is illust visible: {0}", illust.visible);
                Console.WriteLine("Is illust muted: {0}", illust.is_muted);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }

            Console.WriteLine("Next url: {0}", walkthough.next_url);
            Console.WriteLine("\n\n\n");
        }

        //Emoji Test
        public static async Task EmojiList()
        {
            EmojiList emojis = await Client.EmojiList();
            
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
        
        //Password login test
        static async Task FirstLogin()
        {
            Console.Write("Please enter your username\n> ");
            string username = Console.ReadLine();
            Console.Write("Please enter your password\n> ");
            string password = Console.ReadLine();
            Console.Clear();

            LoginResponse response = await Client.Login(username, password);
            
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
            Console.WriteLine("profile_image_url: {0}", response.user.profile_image_urls.px_170x170);
            Console.WriteLine("User ID: {0}", response.user.id);
            Console.WriteLine("Username: {0}", response.user.name);
            Console.WriteLine("User account: {0}", response.user.account);
            Console.WriteLine("Mail address: {0}", response.user.mail_address);
            Console.WriteLine("Is premium: {0}", response.user.is_premium);
            Console.WriteLine("X restrict: {0}", response.user.x_restrict);
            Console.WriteLine("Is mail authorised: {0}", response.user.is_mail_authorizde);
            Console.WriteLine("Require policy agreement: {0}", response.user.require_policy_agreement);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Device token: {0}", response.device_token);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\n");
        }
        
        static async void RefreshToken()
        {
            LoginResponse response;
            
            if (Client.CheckTokens() == false)
            {
                Console.WriteLine("Please login to obtain access tokens before testing login refresh.");
                return;
            }

            try
            {
                response = await Client.RefreshLogin();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
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
            Console.WriteLine("profile_image_url: {0}", response.user.profile_image_urls.px_170x170);
            Console.WriteLine("User ID: {0}", response.user.id);
            Console.WriteLine("Username: {0}", response.user.name);
            Console.WriteLine("User account: {0}", response.user.account);
            Console.WriteLine("Mail address: {0}", response.user.mail_address);
            Console.WriteLine("Is premium: {0}", response.user.is_premium);
            Console.WriteLine("X restrict: {0}", response.user.x_restrict);
            Console.WriteLine("Is mail authorised: {0}", response.user.is_mail_authorizde);
            Console.WriteLine("Require policy agreement: {0}", response.user.require_policy_agreement);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Device token: {0}", response.device_token);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\n");
        }
    }
}