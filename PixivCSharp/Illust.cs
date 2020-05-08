using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        /// <summary>
        /// Gets information about an illust.
        /// </summary>
        /// <param name="id">Specifies the ID of the illut to search for.</param>
        /// <param name="filter">Specifies whether to use a filter. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="Illust"/></returns>
        public async Task<Illust> ViewIllustAsync(string id, string filter = null)
        {
            // Sets parameters
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_id", id}
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            
            // Sends request and retrieves illust
            response = await RequestClient.RequestAsync(PixivUrls.ViewIllust, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<Illust>(response, "illust");
        }

        /// <summary>
        /// Gets a stream of an image from a url.
        /// </summary>
        /// <param name="imageUrl">The URL of the image to get.</param>
        /// <returns><seealso cref="Stream"/> of the image.</returns>
        public async Task<Stream> GetImageAsync(string imageUrl)
        {
            return await RequestClient.GetImageAsync(imageUrl).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a list of comments for an illust.
        /// </summary>
        /// <param name="id">The ID of the illust to get comments for.</param>
        /// <returns><seealso cref="CommentList"/></returns>
        public async Task<CommentList> IllustCommentsAsync(string id)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_id", id}
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.IllustComments, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<CommentList>(response);
        }

        /// <summary>
        /// Gets a list of replies to a comment.
        /// </summary>
        /// <param name="id">The ID of the comment to get replies to.</param>
        /// <returns><seealso cref="CommentList"/></returns>
        public async Task<CommentList> IllustCommentRepliesAsync(string id)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "comment_id", id}
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.IllustCommentReplies, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<CommentList>(response);
        }
        
        /// <summary>
        /// Bookmarks the illust.
        /// </summary>
        /// <param name="id">The illust to bookmarks.</param>
        /// <param name="restrict">The publicity for the bookmark - 'public' or 'private'</param>
        public async Task AddBookmarkIllustAsync(string id, Publicity restrict = Publicity.Public)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_id", id },
                { "restrict", restrict.JsonValue() }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            await RequestClient.RequestAsync(PixivUrls.IllustBookmarkAdd, encodedParams).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes an illust bookmark.
        /// </summary>
        /// <param name="id">The ID of the illust to unbookmark.</param>
        public async Task RemoveBookmarkIllustAsync(string id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_id", id }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            await RequestClient.RequestAsync(PixivUrls.IllustBookmarkRemove, encodedParams).ConfigureAwait(false);
        }
    }
}