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
                                  "8 - View illust comments\n" +
                                  "9 - Load tokens\n" +
                                  "10 - Add/remove illust bookmark\n" +
                                  "11 - View novel\n" +
                                  "12 - View novel text\n" +
                                  "13 - Add/remove novel bookmark\n" +
                                  "14 - View novel comments\n" +
                                  "15 - View recommended illusts\n" +
                                  "16 - View recommended manga\n" +
                                  "17 - View recommended novels\n" +
                                  "18 - View recommended users\n" +
                                  "19 - View new illusts\n" +
                                  "20 - View new illusts from followed\n" +
                                  "21 - View new illusts from my pixiv\n" +
                                  "22 - View new novels\n" +
                                  "23 - View new novels from followed\n" +
                                  "24 - View new novels from my pixiv\n" +
                                  "25 - Views trending illust tags\n" +
                                  "26 - View trending novel tags\n" +
                                  "27 - View profile\n" +
                                  "28 - View user illusts\n" +
                                  "29 - View user novels\n" +
                                  "30 - View user bookmared illusts\n" +
                                  "31 - View user bookmarked novels\n" +
                                  "32 - View followers\n" +
                                  "33 - View following\n" +
                                  "34 - View my pixiv users\n" +
                                  "35 - Follow user\n" +
                                  "36 - Unfollow user\n" +
                                  "37 - View ranking illusts\n" +
                                  "38 - View ranking novels\n" +
                                  "0 - Exit");
            
                // User choice
                Console.Write("> ");
                choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        await Walkthrough();
                        break;
                    case "2":
                        await EmojiList();
                        break;
                    case "3":
                        await FirstLogin();
                        break;
                    case "4":
                        await RefreshToken();
                        break;
                    case "5" :
                        await ViewIllust();
                        break;
                    case "6":
                        await TimeTest();
                        break;
                    case "7" :
                        await DownloadImageTest();
                        break;
                    case "8":
                        await ViewComments();
                        break;
                    case "9":
                        ReadTokens();
                        break;
                    case "10":
                        await BookmarkIllust();
                        break;
                    case "11":
                        await ViewNovel();
                        break;
                    case "12":
                        await ViewNovelText();
                        break;
                    case "13" :
                        await BookmarkNovel();
                        break;
                    case "14":
                        await ViewNovelComments();
                        break;
                    case "15":
                        await ViewRecommendedIllusts();
                        break;
                    case "16":
                        await ViewRecommendedManga();    
                        break;
                    case "17":
                        await ViewRecommendedNovels();
                        break;
                    case "18":
                        await ViewRecommendedUsers();
                        break;
                    case "19":
                        await ViewNewIllusts();
                        break;
                    case "20":
                        await ViewNewFollowIllusts();
                        break;
                    case "21":
                        await ViewNewMyPixivIllusts();
                        break;
                    case "22":
                        await ViewNewNovels();
                        break;
                    case "23":
                        await ViewNewFollowNovels();
                        break;
                    case "24":
                        await ViewNewMyPixivNovels();
                        break;
                    case "25":
                        await ViewTrendingIllustTags();
                        break;
                    case "26":
                        await ViewTrendingNovelTags();
                        break;
                    case "27":
                        await ViewProfile();
                        break;
                    case "28":
                        await ViewUserIllusts();
                        break;
                    case "29":
                        await ViewUserNovels();
                        break;
                    case "30":
                        await ViewBookmarkedIllusts();
                        break;
                    case "31":
                        await ViewBookmarkedNovels();
                        break;
                    case "32":
                        await ViewFollowers();
                        break;
                    case "33":
                        await ViewFollowing();
                        break;
                    case "34":
                        await ViewMyPixiv();
                        break;
                    case "35":
                        await FollowUser();
                        break;
                    case "36":
                        await UnFollowUser();
                        break;
                    case "37":
                        await ViewRankingIllusts();
                        break;
                    case "38":
                        await ViewRankingNovels();
                        break;
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}