using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        // Views a novel
        /// <summary>
        /// Gets information about a novel.
        /// </summary>
        /// <param name="id">The ID of the novel to view.</param>
        /// <returns><seealso cref="Novel"/></returns>
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
        /// <summary>
        /// View the full contents of a novel.
        /// </summary>
        /// <param name="id">The ID of the novel to view.</param>
        /// <returns><seealso cref="NovelText"/></returns>
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

        /// <summary>
        /// Gets comments of a novel.
        /// </summary>
        /// <param name="id">The ID of the novel to get comments for.</param>
        /// <returns><seealso cref="CommentList"/></returns>
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
        
        /// <summary>
        /// Gets a list of replies to a comment.
        /// </summary>
        /// <param name="id">The ID of the comment to get replies for.</param>
        /// <returns><seealso cref="CommentList"/></returns>
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
        
        /// <summary>
        /// Bookmarks a novel.
        /// </summary>
        /// <param name="id">The novel to bookmark.</param>
        /// <param name="restrict">The publicity at which to bookmark the novel.</param>
        public async Task AddBookmarkNovelAsync(string id, Publicity restrict = Publicity.Public)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id },
                { "restrict", restrict.JsonValue() }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            await RequestClient.RequestAsync(PixivUrls.NovelBookmarkAdd, encodedParams).ConfigureAwait(false);
        }

        /// <summary>
        /// Unbookmarks a novel.
        /// </summary>
        /// <param name="id">The ID of the bookmark to remove.</param>
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