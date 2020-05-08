using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        /// <summary>
        /// Gets the context of an illust within a series.
        /// </summary>
        /// <param name="illustID">The ID of the illust to view the context of.</param>
        /// <param name="filter">The filter to use. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="IllustSeriesContext"/></returns>
        public async Task<IllustSeriesContext> IllustSeriesContextAsync(string illustID, FilterType filter = FilterType.None)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_id", illustID }
            };

            // Adds filter if required
            if ((filter.JsonValue() ?? Filter.JsonValue()) != null)
            {
                parameters.Add("filter", filter.JsonValue() ?? Filter.JsonValue());
            }

            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.SeriesFromIllust, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<IllustSeriesContext>(response);
        }
        
        /// <summary>
        /// Gets information about an illust series.
        /// </summary>
        /// <param name="illustSeriesID">The illust series ID to get information for.</param>
        /// <param name="filter">The filter to use. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="IllustSeriesInfo"/></returns>
        public async Task<IllustSeriesInfo> IllustSeriesInfoAsync(string illustSeriesID, FilterType filter = FilterType.None)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "illust_series_id", illustSeriesID }
            };

            // Adds filter if required
            if ((filter.JsonValue() ?? Filter.JsonValue()) != null)
            {
                parameters.Add("filter", filter.JsonValue() ?? Filter.JsonValue());
            }

            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.IllustSeries, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<IllustSeriesInfo>(response);
        }
        
        /// <summary>
        /// Gets information about a novel series.
        /// </summary>
        /// <param name="novelSeriesID">The novel series ID to get information for.</param>
        /// <returns><seealso cref="NovelSeriesInfo"/></returns>
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