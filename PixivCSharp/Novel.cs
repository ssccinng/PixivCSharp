using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        // Views a novel
        public async Task<Novel> ViewNovelAsync(string id)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.ViewNovel, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<Novel>(response, "novel");
        }

        // Retrieves novel text
        public async Task<NovelText> ViewNovelTextAsync(string id)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.ViewNovelText, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<NovelText>(response);
        }

        // Retrieves comments of a novel
        public async Task<CommentList> NovelCommentsAsync(string id)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.NovelComments, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<CommentList>(response);
        }
        
        // Retrieves replies to a comment on a novel
        public async Task<CommentList> NovelCommentRepliesAsync(string id)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "comment_id", id}
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.NovelCommentReplies, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<CommentList>(response);
        }
        
        // Bookmarks a novel
        public async Task AddBookmarkNovelAsync(string id, string restrict)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id },
                { "restrict", restrict }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            await RequestClient.RequestAsync(PixivUrls.NovelBookmarkAdd, encodedParams).ConfigureAwait(false);
        }

        // Removes a novel bookmark
        public async Task RemoveBookmarkNovelAsync(string id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            await RequestClient.RequestAsync(PixivUrls.NovelBookmarkRemove, encodedParams).ConfigureAwait(false);
        }
    }
}