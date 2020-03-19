using System;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        // Tests viewing novel info
        static async Task ViewNovel()
        {
            Console.Write("Please enter the id of the novel to view\n> ");
            Novel novel = await Client.ViewNovelAsync(Console.ReadLine());

            Output.TestNovel(novel);
        }
        
        // Tests novel bookmarks
        static async Task ViewNovelText()
        {
            Console.Write("Please enter the ID of the novel to view\n> ");
            NovelText noveltext = await Client.ViewNovelTextAsync(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine(noveltext.Content);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        // Tests viewing novel comments
        static async Task ViewNovelComments()
        {
            CommentList list;
            Console.Write("Enter 1 for comments of a novel, enter 2 for replies of a comment\n> ");
            string choice = Console.ReadLine();
            Console.Clear();
            
            if (choice == "1")
            {
                Console.Write("Please enter the id of the novel to view comments of\n> ");
                list = await Client.NovelCommentsAsync(Console.ReadLine());
            }
            else if (choice == "2")
            {
                Console.Write("Please enter the id of the comment to see replies to\n> ");
                list = await Client.NovelCommentRepliesAsync(Console.ReadLine());
            }
            else
            {
                return;
            }
            
            Console.WriteLine("Comments:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach (Comment comment in list.Comments)
            {
                Output.TestComment(comment);
            }
            Console.WriteLine("Next url: {0}", list.NextUrl);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }
            
        static async Task BookmarkNovel()
        {
            Console.Write("Enter 1 to add a bookmark, enter 0 to remove a bookmark\n> ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter the id of the novel to bookmark\n> ");
                await Client.AddBookmarkNovelAsync(Console.ReadLine(), "public");
            }
            else if (choice == "2")
            {
                Console.Write("Enter the id of novel to remove from bookmarks");
                await Client.RemoveBookmarkNovelAsync(Console.ReadLine());
            }
        }
    }
    
    
}