using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        /// <summary>
        /// Gets a list of ranking illusts.
        /// </summary>
        /// <param name="mode">
        /// The mode to use. Can be: 'day', 'week', 'month', 'day_male', 'day_female', 'week_original', 'week_rookie',
        /// 'day_manga', 'week_rookie_manga', 'week_manga' or 'month_manga'.
        /// </param>
        /// <param name="date">The date to get ranking illusts for.</param>
        /// <param name="filter">The filter to use. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="IllustSearchResult"/> for ranking illusts.</returns>
        public async Task<IllustSearchResult> RankingIllustsAsync(string mode = "day", DateTime? date = null,
            string filter = null)
        {
            // Converts time to the correct timezone and produces a date string in correct format
            Stream response;
            DateTime dateValue = date ?? DateTime.Now.AddDays(-1);
            string dateString = dateValue.Year.ToString("0000") + "-" + dateValue.Month.ToString("00")
                                + "-" + dateValue.Day.ToString("00");

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "mode", mode },
                { "date", dateString }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            response = await RequestClient.RequestAsync(PixivUrls.RankingIllusts, encodedParams)
                .ConfigureAwait(false);

            return Json.DeserializeJson<IllustSearchResult>(response);
        }
        
        /// <summary>
        /// Gets a list of ranking novels
        /// </summary>
        /// <param name="mode">The mode to use. Can be: 'day', 'week','day_male', 'day_female' or 'week_rookie'.</param>
        /// <param name="date">The date to get ranking novels for.</param>
        /// <returns><seealso cref="NovelSearchResult"/> for ranking novels.</returns>
        public async Task<NovelSearchResult> RankingNovelsAsync(string mode = "day", DateTime? date = null)
        {
            // Converts time to the correct timezone and produces a date string in correct format
            Stream response;
            DateTime dateValue = date ?? DateTime.Now.AddDays(-1);
            string dateString = dateValue.Year.ToString("0000") + "-" + dateValue.Month.ToString("00")
                                + "-" + dateValue.Day.ToString("00");
            
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "mode", mode },
                { "date", dateString }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            response = await RequestClient.RequestAsync(PixivUrls.RankingNovels, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<NovelSearchResult>(response);
        }
    }
}