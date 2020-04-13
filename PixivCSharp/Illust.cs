using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
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

        // Gets image from url and returns as stream
        public async Task<Stream> GetImageAsync(string imageUrl)
        {
            return await RequestClient.GetImageAsync(imageUrl).ConfigureAwait(false);
        }

        // Retrieves a list of comments for an illust
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

        // Retrieves a list of replies to a comment
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
        
        // Bookmarks an illust
        public async Task AddBookmarkIllustAsync(string id, string restrict)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_id", id },
                { "restrict", restrict }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            await RequestClient.RequestAsync(PixivUrls.IllustBookmarkAdd, encodedParams).ConfigureAwait(false);
        }

        // Removes illust bookmark
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