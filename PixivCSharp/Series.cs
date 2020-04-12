using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        // Returns a series context of an illust
        public async Task<IllustSeriesContext> IllustSeriesContextAsync(string illustID, string filter = null)
        {
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

            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.SeriesFromIllust, encodedParams)
                .ConfigureAwait(false);

            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            IllustSeriesContext result = Json.DeserializeJson<IllustSeriesContext>(responseContent);
            return result;
        }
        
        // Returns information about an illust series
        public async Task<IllustSeriesInfo> IllustSeriesInfoAsync(string illustSeriesID, string filter = null)
        {
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

            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.IllustSeries, encodedParams)
                .ConfigureAwait(false);

            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            IllustSeriesInfo result = Json.DeserializeJson<IllustSeriesInfo>(responseContent);
            return result;
        }
        
        // Returns information about a novel series
        public async Task<NovelSeriesInfo> NovelSeriesInfoAsync(string novelSeriesID)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "series_id", novelSeriesID }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.NovelSeries, encodedParams)
                .ConfigureAwait(false);

            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            NovelSeriesInfo result = Json.DeserializeJson<NovelSeriesInfo>(responseContent);
            return result;
        }
    }
}