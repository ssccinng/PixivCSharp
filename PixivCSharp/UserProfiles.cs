using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp
{
    public partial class PixivClient
    {
        /// <summary>
        /// Gets information about a user.
        /// </summary>
        /// <param name="UserID">The ID of the user to get view.</param>
        /// <param name="filter">The filter to use. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="UserDetail"/></returns>
        public async Task<UserDetail> ViewProfileAsync(string UserID, string filter = null)
        {
            Stream response;
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

            response = await RequestClient.RequestAsync(PixivUrls.ViewProfile, encodedParameters).ConfigureAwait(false);
            return Json.DeserializeJson<UserDetail>(response);
        }
        
        /// <summary>
        /// Gets a list of illusts by the specified user.
        /// </summary>
        /// <param name="UserID">The ID of the user to view illusts of.</param>
        /// <param name="type">The type of illusts to view. Can be: 'illust' or 'manga'</param>
        /// <param name="filter"></param>
        /// <returns><seealso cref="IllustSearchResult"/></returns>
        public async Task<IllustSearchResult> UserIllustsAsync(string UserID, string type, string filter = null)
        {
            Stream response;
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

            response = await RequestClient.RequestAsync(PixivUrls.ProfileIllusts, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<IllustSearchResult>(response);
        }
        
        /// <summary>
        /// Gets a list of novels by the specified user.
        /// </summary>
        /// <param name="UserID">The ID of the user to view novels of.</param>
        /// <returns><seealso cref="NovelSearchResult"/></returns>
        public async Task<NovelSearchResult> UserNovelsAsync(string UserID)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            response = await RequestClient.RequestAsync(PixivUrls.ProfileNovels, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<NovelSearchResult>(response);
        }
        
        /// <summary>
        /// View bookmarked illusts of the given user.
        /// </summary>
        /// <remarks>
        /// The request accepts no filter parameter, therefore any filtering must be done manually.
        /// </remarks>
        /// <param name="UserID">The ID of the user to view bookmarks of.</param>
        /// <param name="restrict">The publicity of bookmarks to view. Can be: 'all', 'public' or 'private'.</param>
        /// <returns><seealso cref="IllustSearchResult"/></returns>
        public async Task<IllustSearchResult> BookmarkedIllustsAsync(string UserID, string restrict = "public")
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID },
                { "restrict", restrict }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            response = await RequestClient.RequestAsync(PixivUrls.BookmarkedIllusts, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<IllustSearchResult>(response);
        }
        
        /// <summary>
        /// Gets a list of novels bookmarked by the given user.
        /// </summary>
        /// <param name="UserID">The ID of the user to view novel bookmarks of.</param>
        /// <param name="restrict">The publicity of bookmarks to view. Can be: 'all', 'public' or 'private'.</param>
        /// <returns><seealso cref="NovelSearchResult"/></returns>
        public async Task<NovelSearchResult> BookmarkedNovelsAsync(string UserID, string restrict = "public")
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "user_id", UserID },
                { "restrict", restrict }
            };
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            response = await RequestClient.RequestAsync(PixivUrls.BookmarkedNovels, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<NovelSearchResult>(response);
        }

        /// <summary>
        /// Gets a list of of followers of the logged in user.
        /// </summary>
        /// <remarks>
        /// This method can only be used to view the followers of the signed in user. There is no way to view the
        /// followers of another user.
        /// </remarks>
        /// <param name="filter">The filter to use. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="UserSearchResult"/></returns>
        public async Task<UserSearchResult> FollowersAsync(string filter = null)
        {
            Stream response;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            
            // Adds filter if required
            string filterText = filter ?? Filter;
            if (filterText != "none" && (filterText == "for_android" || filterText == "for_ios"))
            {
                parameters.Add("filter", filter ?? Filter);
            }
            FormUrlEncodedContent encodedParams = new FormUrlEncodedContent(parameters);

            response = await RequestClient.RequestAsync(PixivUrls.ViewFollowers, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<UserSearchResult>(response);
        }

        /// <summary>
        /// Gets a list of the users followed by the given user.
        /// </summary>
        /// <param name="UserID">The ID of the user to view following accounts from.</param>
        /// <param name="restrict">The publicity of follows to view. Can be: 'all', 'public' or 'private'.</param>
        /// <param name="filter">The filter to use. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="UserSearchResult"/></returns>
        public async Task<UserSearchResult> FollowingAsync(string UserID, string restrict = "public", string filter = null)
        {
            Stream response;
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

            response = await RequestClient.RequestAsync(PixivUrls.ViewFollowing, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<UserSearchResult>(response);
        }
         
        /// <summary>
        /// Gets a list of users on the specified user's my pixiv list.
        /// </summary>
        /// <param name="UserID">The ID of the user to view my pixiv users of.</param>
        /// <param name="filter">The filter to use. Can be 'none', 'for_android' or 'for_ios'.</param>
        /// <returns><seealso cref="UserSearchResult"/></returns>
        public async Task<UserSearchResult> MyPixivAsync(string UserID, string filter = null)
        {
            Stream response;
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

            response = await RequestClient.RequestAsync(PixivUrls.MyPixiv, encodedParams).ConfigureAwait(false);
            return Json.DeserializeJson<UserSearchResult>(response);
        }
        
        /// <summary>
        /// Follows a user.
        /// </summary>
        /// <param name="UserID">The ID of the user to follow.</param>
        /// <param name="restrict">The publicity at which to follow. Can be: 'all', 'public' or 'private'.</param>
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

        /// <summary>
        /// Unfollows a user.
        /// </summary>
        /// <param name="UserID">The ID of the user to unfollow.</param>
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