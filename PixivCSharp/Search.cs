using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        /// <summary>
        /// Gets a list of illusts for the given search term.
        /// </summary>
        /// <param name="searchTerm">The search term to use. Tags should be seperated with a space.</param>
        /// <param name="sort">How to sort the results. Can be: 'date_desc' or 'date_asc'.</param>
        /// <param name="searchTarget">
        /// The method of search. Can be: 'partial_match_for_tags', 'exact_match_for_tags' or 'title_and_caption'.
        /// </param>
        /// <param name="includeTranslatedTags">Whether to include tag translations.</param>
        /// <param name="mergePlainKeywordResults">Currnetly unknown.</param>
        /// <param name="filter">The filter to use. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="IllustSearchResult"/></returns>
        public async Task<IllustSearchResult> SearchIllustsAsync(string searchTerm, string sort ="date_desc",
            string searchTarget = "partial_match_for_tags", bool includeTranslatedTags = true,
            bool mergePlainKeywordResults = true, string filter = null)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "word", searchTerm },
                { "search_target", searchTarget },
                { "sort", sort },
                { "include_translated_tags", includeTranslatedTags.ToString().ToLower() },
                { "merge_plain_keywork_results", mergePlainKeywordResults.ToString().ToLower() }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.IllustSearch, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<IllustSearchResult>(response);
        }
        
        /// <summary>
        /// Gets a list of novels for the give search term.
        /// </summary>
        /// <param name="searchTerm">The search term to use. Tags should be seperated with a space.</param>
        /// <param name="sort">How to sort the results. Can be: 'date_desc' or 'date_asc'.</param>
        /// <param name="searchTarget">The method of search. Can be: 'partial_match_for_tags', 'exact_match_for_tags' or 'title_and_caption'.</param>
        /// <param name="includeTranslatedTags">Whether to include tag translations.</param>
        /// <param name="mergePlainKeywordResults">Currently unknown.</param>
        /// <returns><seealso cref="NovelSearchResult"/></returns>
        public async Task<NovelSearchResult> SearchNovelsAsync(string searchTerm, string sort = "date_desc",
            string searchTarget = "partial_match_for_tags", bool includeTranslatedTags = true,
            bool mergePlainKeywordResults = true)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "word", searchTerm },
                { "search_target", searchTarget },
                { "sort", sort },
                { "include_translated_tags", includeTranslatedTags.ToString().ToLower() },
                { "merge_plain_keyword_results", mergePlainKeywordResults.ToString().ToLower() }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.NovelSearch, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<NovelSearchResult>(response);
        }
        
        /// <summary>
        /// Gets a list of users for the given search term.
        /// </summary>
        /// <param name="searchTerm">The search term to use. Tags should be seperated with a space.</param>
        /// <param name="filter">The filter to use. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="UserSearchResult"/></returns>
        public async Task<UserSearchResult> SearchUsersAsync(string searchTerm, string filter = null)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "word", searchTerm }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.UserSearch, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<UserSearchResult>(response);
        }
        
        /// <summary>
        /// Gets a list of potential autocomplete tags for the given search term.
        /// </summary>
        /// <param name="searchTerm">The search term to use. Tags should be seperated with a space.</param>
        /// <param name="mergePlainKeywordResults">Currently unknown.</param>
        /// <returns><seealso cref="Tag"/>[]</returns>
        public async Task<Tag[]> AutocompleteTagAsync(string searchTerm, bool mergePlainKeywordResults = true)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "word", searchTerm },
                { "merge_plain_keyword_results", mergePlainKeywordResults.ToString().ToLower() }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.AutocompleteTag, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<Tag[]>(response, "tags");
        }
        
        /// <summary>
        /// Gets a list of the first 30 popular illusts for a given search term.
        /// </summary>
        /// <param name="searchTerm">The search term to use. Tags should be seperated with a space.</param>
        /// <param name="sort">How to sort the results. Can be: 'date_desc' or 'date_asc'.</param>
        /// <param name="searchTarget">The method of search. Can be: 'partial_match_for_tags', 'exact_match_for_tags' or 'title_and_caption'.</param>
        /// <param name="includeTranslatedTags">Whether to include tag translations.</param>
        /// <param name="mergePlainKeywordResults">Currently unknown.</param>
        /// <param name="filter">The filter to use. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="IllustSearchResult"/></returns>
        public async Task<IllustSearchResult> PopularIllustsPreviewAsync(string searchTerm, string sort = "date_desc",
            string searchTarget = "partial_match_for_tags", bool includeTranslatedTags = true,
            bool mergePlainKeywordResults = true, string filter = null)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"word", searchTerm},
                {"sort", sort},
                {"search_target", searchTarget},
                {"include_translated_tags", includeTranslatedTags.ToString().ToLower()},
                {"merge_plain_keyword_results", mergePlainKeywordResults.ToString().ToLower()}
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            response = await RequestClient.RequestAsync(PixivUrls.PopularIllustsPreview, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<IllustSearchResult>(response);
        }
        
        /// <summary>
        /// Gets a list of the first 30 popular novels for the given search term.
        /// </summary>
        /// <param name="searchTerm">The search term to use. Tags should be seperated with a space.</param>
        /// <param name="sort">How to sort the results. Can be: 'date_desc' or 'date_asc'.</param>
        /// <param name="searchTarget">The method of search. Can be: 'partial_match_for_tags', 'exact_match_for_tags' or 'title_and_caption'.</param>
        /// <param name="includeTranslatedTags">Whether to include tag translations.</param>
        /// <param name="mergePlainKeywordResults">Currently unknown.</param>
        /// <returns></returns>
        public async Task<NovelSearchResult> PopularNovelsPreviewAsync(string searchTerm, string sort = "date_desc",
            string searchTarget = "partial_match_for_tags", bool includeTranslatedTags = true,
            bool mergePlainKeywordResults = true)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "word", searchTerm },
                { "sort", sort },
                { "search_target", searchTarget},
                { "include_translated_tags", includeTranslatedTags.ToString().ToLower() },
                { "merge_plain_keyword_results", mergePlainKeywordResults.ToString().ToLower() }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            response = await RequestClient.RequestAsync(PixivUrls.PopularNovelsPreview, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<NovelSearchResult>(response);
        }
    }
}