using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        //Views a novel
        public async Task<Novel> ViewNovel(string id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await RequestClient.Request(PixivUrls.ViewNovel, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            return json["novel"].ToObject<Novel>();
        }

        //Bookmarks a novel
        public async Task AddBookmarkNovel(string id, string restrict)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id },
                { "restrict", restrict }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            await RequestClient.Request(PixivUrls.NovelBookmarkAdd, encodedParams).ConfigureAwait(false);
        }

        //Removes a novel bookmark
        public async Task RemoveBookmarkNovel(string id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "novel_id", id }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            await RequestClient.Request(PixivUrls.NovelBookmarkRemove, encodedParams).ConfigureAwait(false);
        }
    }
}