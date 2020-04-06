using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        // Retrieves details of a user's profile
        public async Task<UserDetail> ViewProfileAsync(string UserID, string filter = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            
            FormUrlEncodedContent encodedParameters = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.ViewProfile, encodedParameters)
                .ConfigureAwait(false);

            UserDetail result =
                Json.DeserializeJson<UserDetail>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return result;
        }
        
        // Retrieves a list of a user's illusts
        public async Task<IllustSearchResult> UserIllustsAsync(string UserID, string type, string filter = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID },
                { "type", type },
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.ProfileIllusts, encodedParams)
                .ConfigureAwait(false);

            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            IllustSearchResult result = Json.DeserializeJson<IllustSearchResult>(responseContent);
            return result;
        }
        
        // Retrieves a list of a user's novels
        public async Task<NovelSearchResult> UserNovelsAsync(string UserID)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            HttpResponseMessage repsonse = await RequestClient.RequestAsync(PixivUrls.ProfileNovels, encodedParams)
                .ConfigureAwait(false);

            string responseContent = await repsonse.Content.ReadAsStringAsync().ConfigureAwait(false);
            NovelSearchResult result = Json.DeserializeJson<NovelSearchResult>(responseContent);
            return result;
        }
        
        // Retrieves a list of a user's bookmarked illusts
        public async Task<IllustSearchResult> BookmarkedIllustsAsync(string UserID, string restrict = "public")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID },
                { "restrict", restrict }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            HttpResponseMessage repsonse = await RequestClient.RequestAsync(PixivUrls.BookmarkedIllusts, encodedParams)
                .ConfigureAwait(false);

            string responseContent = await repsonse.Content.ReadAsStringAsync().ConfigureAwait(false);
            IllustSearchResult result = Json.DeserializeJson<IllustSearchResult>(responseContent);
            return result;
        }
        
        // Retrieves a list of a user's bookmarked novels
        public async Task<NovelSearchResult> BookmarkedNovelsAsync(string UserID, string restrict = "public")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID },
                { "restrict", restrict }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.BookmarkedNovels, encodedParams)
                .ConfigureAwait(false);

            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            NovelSearchResult result = Json.DeserializeJson<NovelSearchResult>(responseContent);
            return result;
        }

        // Retrieves a list of the user's followers
        public async Task<UserSearchResult> FollowersAsync(string filter = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            HttpResponseMessage repsonse = await RequestClient.RequestAsync(PixivUrls.ViewFollowers, encodedParams)
                .ConfigureAwait(false);

            string responseContent = await repsonse.Content.ReadAsStringAsync().ConfigureAwait(false);
            UserSearchResult result = Json.DeserializeJson<UserSearchResult>(responseContent);
            return result;
        }

        // Retrieves a list of the accounts followed by a user
        public async Task<UserSearchResult> FollowingAsync(string UserID, string restrict = "public", string filter = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID },
                { "restrict", restrict }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await RequestClient.RequestAsync(PixivUrls.ViewFollowing, encodedParams)
                .ConfigureAwait(false);

            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            UserSearchResult result = Json.DeserializeJson<UserSearchResult>(responseContent);
            return result;
        }
         
        // Retrieves a list of accounts from a user's my pixiv list
        public async Task<UserSearchResult> MyPixivAsync(string UserID, string filter = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID }
            };
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response =
                await RequestClient.RequestAsync(PixivUrls.MyPixiv, encodedParams).ConfigureAwait(false);

            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            UserSearchResult result = Json.DeserializeJson<UserSearchResult>(responseContent);
            return result;
        }
        
        // Follows a user
        public async Task FollowAsync(string UserID, string restrict = "public")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID },
                { "restrict", restrict }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            await RequestClient.RequestAsync(PixivUrls.FollowProfile, encodedParams).ConfigureAwait(false);
        }

        // Unfollows a user
        public async Task RemoveFollowAsync(string UserID)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);
            await RequestClient.RequestAsync(PixivUrls.UnfollowProfile, encodedParams).ConfigureAwait(false);
        }
    }
}