using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        public async Task<Illust> ViewIllustAsync(string id)
        {
            // Sets parameters
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_id", id}
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            
            // Sends request and retrieves illust
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.ViewIllust, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            Illust result = json["illust"].ToObject<Illust>();
            return result;
        }

        // Gets image from url and returns as stream
        public async Task<Stream> GetImageAsync(string imageUrl)
        {
            HttpResponseMessage response = await RequestClient.GetImageAsync(imageUrl).ConfigureAwait(false);
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        // Retrieves a list of comments for an illust
        public async Task<CommentList> IllustCommentsAsync(string id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_id", id}
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.IllustComments, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            CommentList result = json.ToObject<CommentList>();
            return result;
        }

        // Retrieves a list of replies to a comment
        public async Task<CommentList> IllustCommentRepliesAsync(string id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "comment_id", id}
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.IllustCommentReplies, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            CommentList result = json.ToObject<CommentList>();
            return result;
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