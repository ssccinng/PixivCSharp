using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        // Returns a series context of an illust
        public async Task<IllustSeriesContext> IllustSeriesContextAsync(string illustID, string filter = null)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_id", illustID }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.SeriesFromIllust, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<IllustSeriesContext>(response);
        }
        
        // Returns information about an illust series
        public async Task<IllustSeriesInfo> IllustSeriesInfoAsync(string illustSeriesID, string filter = null)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_series_id", illustSeriesID }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.IllustSeries, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<IllustSeriesInfo>(response);
        }
        
        // Returns information about a novel series
        public async Task<NovelSeriesInfo> NovelSeriesInfoAsync(string novelSeriesID)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "series_id", novelSeriesID }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            response = await RequestClient.RequestAsync(PixivUrls.NovelSeries, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<NovelSeriesInfo>(response);
        }
    }
}