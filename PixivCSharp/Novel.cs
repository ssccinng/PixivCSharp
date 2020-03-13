using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        // Views a novel
        public async Task<Novel> ViewNovelAsync(string id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.ViewNovel, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            return json["novel"].ToObject<Novel>();
        }

        // Retrieves novel text
        public async Task<NovelText> ViewNovelTextAsync(string id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.ViewNovelText, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            return json.ToObject<NovelText>();
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