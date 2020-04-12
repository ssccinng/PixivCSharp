using System;

namespace PixivCSharp.Tests
{
    public class Output
    {
        public static void TestIllust(Illust illust)
        {
            Console.WriteLine("Illust: ");
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
            TestUser(illust.User);
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

        public static void TestNovel(Novel novel)
        {
            Console.WriteLine("Novel:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Novel ID: {0}", novel.ID);
            Console.WriteLine("Novel title: {0}", novel.Title);
            Console.WriteLine("Novel caption: {0}", novel.Caption);
            Console.WriteLine("Novel restrict: {0}", novel.Restrict);
            Console.WriteLine("Novel x-restrict: {0}", novel.XRestrict);
            Console.WriteLine("Is original: {0}", novel.IsOriginal);
            Console.WriteLine("Novel medium image url: {0}", novel.ImageUrls.Medium);
            Console.WriteLine("Novel square medium url: {0}", novel.ImageUrls.SquareMedium);
            Console.WriteLine("Novel large image url: {0}", novel.ImageUrls.large);
            Console.WriteLine("Novel create date: {0}", novel.CreateDate);
            Console.WriteLine("Tags:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach (Tag tag in novel.Tags)
            {
                Console.WriteLine("Tag name: {0}", tag.Name);
                Console.WriteLine("Translated name: {0}", tag.TranslatedName);
                Console.WriteLine("Added by uploader: {0}", tag.AddedByUploader);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Page count: {0}", novel.PageCount);
            Console.WriteLine("Text count: {0}", novel.TextLength);
            Console.WriteLine("-------------------------------------------------------------------------------");
            TestUser(novel.User);
            Console.WriteLine("Series:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Series ID: {0}", novel.Series.ID);
            Console.WriteLine("Series Title: {0}", novel.Series.Title);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Is bookmarked: {0}", novel.IsBookmarked);
            Console.WriteLine("Total bookmarks: {0}", novel.TotalBookmarks);
            Console.WriteLine("Total views: {0}", novel.TotalView);
            Console.WriteLine("Visible: {0}", novel.Visible);
            Console.WriteLine("Total comments: {0}", novel.total_comments);
            Console.WriteLine("Is muted: {0}", novel.IsMuted);
            Console.WriteLine("Is my pixiv only: {0}", novel.IsMyPixivOnly);
            Console.WriteLine("Is x restricted: {0}", novel.IsXRestricted);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        public static void TestComment(Comment comment)
        {
            Console.WriteLine("Comment:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Comment ID: {0}", comment.ID);
            Console.WriteLine("Comment: {0}", comment.Content);
            Console.WriteLine("Comment date: {0}", comment.Date);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("User id: {0}", comment.User.ID.ToString());
            Console.WriteLine("User name: {0}", comment.User.Name);
            Console.WriteLine("User account: {0}", comment.User.Account);
            Console.WriteLine("User profile picture url: {0}", comment.User.ProfileImageUrls.Medium);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Comment has replies: {0}", comment.HasReplies);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        public static void TestUser(User user)
        {
            Console.WriteLine("User:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("User id: {0}", user.ID.ToString());
            Console.WriteLine("User name: {0}", user.Name);
            Console.WriteLine("User account: {0}", user.Account);
            Console.WriteLine("User profile picture url: {0}", user.ProfileImageUrls.Medium);
            Console.WriteLine("Is user followed: {0}", user.IsFollowed);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        public static void TestIllustSeries(IllustSeries series)
        {
            Console.WriteLine("Illust series info:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("ID: {0}", series.ID);
            Console.WriteLine("Title: {0}", series.Title);
            Console.WriteLine("Caption: {0}", series.Caption);
            Console.WriteLine("Cover image url: {0}", series.CoverImageUrls.Medium);
            Console.WriteLine("Work count: {0}", series.SeriesWorkCount);
            Console.WriteLine("Create date: {0}", series.CreateDate);
            Console.WriteLine("Width: {0}", series.Width);
            Console.WriteLine("Height: {0}", series.Height);
            TestUser(series.User);
        }

        public static void TestNovelSeries(NovelSeries series)
        {
            Console.WriteLine("Novel series info:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("ID: {0}", series.ID);
            Console.WriteLine("Title: {0}", series.Title);
            Console.WriteLine("Caption: {0}", series.Caption);
            Console.WriteLine("Is original: {0}", series.IsOriginal);
            Console.WriteLine("Is concluded: {0}", series.IsConcluded);
            Console.WriteLine("Novel count: {0}", series.NovelCount);
            Console.WriteLine("Character count: {0}", series.CharacterCount);
            TestUser(series.User);
            Console.WriteLine("Display text: {0}", series.DisplayText);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }
    }
}