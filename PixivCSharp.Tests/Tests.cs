using System;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        private static PixivClient Client;
        static async Task Main()
        {
            // Loops until the user exits
            Client = new PixivClient();
            string choice = string.Empty;
            while (choice != "0")
            {
                Console.WriteLine("Please enter a function to test:\n" +
                                  "1 - Walkthough\n" +
                                  "2 - EmojiList\n" +
                                  "3 - Login\n" +
                                  "4 - Refresh login\n" +
                                  "5 - View Illust\n" +
                                  "6 - Illust download test\n" +
                                  "7 - Download image test\n" +
                                  "8 - View comments\n" +
                                  "9 - Load tokens\n" +
                                  "10 - Add/remove illust bookmark\n" +
                                  "11 - View novel\n" +
                                  "12 - View novel text\n" +
                                  "13 - Add/remove novel bookmark\n" +
                                  "0 - Exit");
            
                // User choice
                Console.Write("> ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        await Walkthrough();
                        break;
                    case "2":
                        Console.Clear();
                        await EmojiList();
                        break;
                    case "3":
                        Console.Clear();
                        await FirstLogin();
                        break;
                    case "4":
                        Console.Clear();
                        await RefreshToken();
                        break;
                    case "5" :
                        Console.Clear();
                        await ViewIllust();
                        break;
                    case "6":
                        Console.Clear();
                        await TimeTest();
                        break;
                    case "7" :
                        Console.Clear();
                        await DownloadImageTest();
                        break;
                    case "8":
                        Console.Clear();
                        await ViewComments();
                        break;
                    case "9":
                        Console.Clear();
                        ReadTokens();
                        break;
                    case "10":
                        Console.Clear();
                        await BookmarkIllust();
                        break;
                    case "11":
                        Console.Clear();
                        await ViewNovel();
                        break;
                    case "13" :
                        Console.Clear();
                        await BookmarkNovel();
                        break;
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}