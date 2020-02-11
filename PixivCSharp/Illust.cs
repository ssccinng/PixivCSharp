using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        public async Task<Illust> ViewIllust(string id)
        {
            //Sets parameters
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_id", id}
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            
            //Sends request and retrieves illust
            HttpResponseMessage response = await requestClient.Request(PixivUrls.ViewIllust, encodedParams).ConfigureAwait(false);
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            Illust result = json["illust"].ToObject<Illust>();
            return result;
        }
    }
}