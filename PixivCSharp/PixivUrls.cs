namespace PixivCSharp
{
    public static class PixivUrls
    {
        // Login urls
        public static URL Login = new URL() {Address = "https://oauth.secure.pixiv.net/auth/token", Type = "POST"};
        
        // Account urls
        public static URL AccountState = new URL() {Address = "https://app-api.pixiv.net/v1/user/me/state", Type = "GET"};
        public static URL AccountPresets = new URL() {Address = "https://app-api.pixiv.net/v1/user/profile/presets", Type = "GET"};
        public static URL EditAccount = new URL() {Address = "https://app-api.pixiv.net/v1/user/profile/edit", Type = "POST", Multipart = true};
        
        // Recommended urls
        public static URL RecommendedIllusts = new URL() {Address = "https://app-api.pixiv.net/v1/illust/recommended", Type = "GET"};
        public static URL RecommendedManga = new URL() {Address = "https://app-api.pixiv.net/v1/manga/recommended", Type = "GET"};
        public static URL RecommendedNovels = new URL() {Address = "https://app-api.pixiv.net/v1/novel/recommended", Type = "GET"};
        public static URL RecommendedUsers = new URL() {Address = "https://app-api.pixiv.net/v1/user/recommended", Type = "GET"};
        
        // Rankings urls
        public static URL RankingIllusts = new URL() {Address = "https://app-api.pixiv.net/v1/illust/ranking", Type = "GET"};
        public static URL RankingNovels = new URL() {Address = "https://app-api.pixiv.net/v1/novel/ranking", Type = "GET"};
        
        // Viewing illust/novels urls
        public static URL ViewIllust = new URL() {Address = "https://app-api.pixiv.net/v1/illust/detail", Type = "GET"};
        public static URL IllustComments = new URL() {Address = "https://app-api.pixiv.net/v2/illust/comments", Type = "GET"};
        public static URL IllustCommentReplies = new URL() {Address = "https://app-api.pixiv.net/v1/illust/comment/replies", Type = "GET"};
        public static URL IllustBookmarkAdd = new URL() {Address = "https://app-api.pixiv.net/v2/illust/bookmark/add", Type = "POST"};
        public static URL IllustBookmarkRemove = new URL() {Address = "https://app-api.pixiv.net/v1/illust/bookmark/delete", Type = "POST"};
        public static URL ViewNovel = new URL() {Address = "https://app-api.pixiv.net/v2/novel/detail", Type = "GET"};
        public static URL ViewNovelText = new URL() {Address = "https://app-api.pixiv.net/v2/novel/text", Type = "GET"};
        public static URL NovelComments = new URL() {Address = "https://app-api.pixiv.net/v2/novel/comments", Type = "GET"};
        public static URL NovelCommentsReplies = new URL() {Address = "https://app-api.pixiv.net/v1/novel/comment/replies", Type = "GET"};
        public static URL NovelBookmarkAdd = new URL() {Address = "https://app-api.pixiv.net/v2/novel/bookmark/add", Type = "POST"};
        public static URL NovelBookmarkRemove = new URL() {Address = "https://app-api.pixiv.net/v1/novel/bookmark/delete", Type = "POST"};
        
        // Series urls
        public static URL SeriesFromIllust = new URL() {Address = "https://app-api.pixiv.net/v1/illust-series/illust", Type = "GET"};
        public static URL IllustSeries = new URL() {Address = "https://app-api.pixiv.net/v1/illust/series", Type = "GET"};
        public static URL NovelSeries = new URL() {Address = "https://app-api.pixiv.net/v2/novel/series", Type = "GET"};
        
        // New works urls
        public static URL NewIllusts = new URL() {Address = "https://app-api.pixiv.net/v1/illust/new", Type = "GET"};
        public static URL NewFollowIllusts = new URL() {Address = "https://app-api.pixiv.net/v2/illust/follow", Type = "GET"};
        public static URL NewMyPixivIllusts = new URL() {Address = "https://app-api.pixiv.net/v2/illust/mypixiv", Type = "GET"};
        public static URL NewNovels = new URL() {Address = "https://app-api.pixiv.net/v1/novel/new", Type = "GET"};
        public static URL NewFollowNovels = new URL() {Address = "https://app-api.pixiv.net/v1/novel/follow", Type = "GET"};
        public static URL NewMyPixivNovels = new URL() {Address = "https://app-api.pixiv.net/v1/novel/mypixiv", Type = "GET"};
        
        // Profile urls
        public static URL ViewProfile = new URL() {Address = "https://app-api.pixiv.net/v1/user/detail", Type = "GET"};
        public static URL FollowProfile = new URL() {Address = "https://app-api.pixiv.net/v1/user/follow/add", Type = "POST"};
        public static URL UnfollowProfile = new URL() {Address = "https://app-api.pixiv.net/v1/user/follow/delete", Type = "POST"};
        public static URL ProfileIllusts = new URL() {Address = "https://app-api.pixiv.net/v1/user/illusts", Type = "GET"};
        public static URL ProfileNovels = new URL() {Address = "https://app-api.pixiv.net/v1/user/novels", Type = "GET"};
        public static URL BookmarkedIllusts = new URL() {Address = "https://app-api.pixiv.net/v1/user/bookmarks/illust", Type = "GET"};
        public static URL BookmarkedNovels = new URL() {Address = "https://app-api.pixiv.net/v1/user/bookmarks/novel", Type = "GET"};
        public static URL ViewFollowers = new URL() {Address = "https://app-api.pixiv.net/v1/user/follower", Type = "GET"};
        public static URL ViewFollowing = new URL() {Address = "https://app-api.pixiv.net/v1/user/following", Type = "GET"};
        public static URL MyPixiv = new URL() {Address = "https://app-api.pixiv.net/v1/user/mypixiv", Type = "GET"};
        
        // Search urls
        public static URL IllustSearch = new URL() {Address = "https://app-api.pixiv.net/v1/search/illust", Type = "GET"};
        public static URL NovelSearch = new URL() {Address = "https://app-api.pixiv.net/v1/search/novel", Type = "GET"};
        public static URL UserSearch = new URL() {Address = "https://app-api.pixiv.net/v1/search/user", Type = "GET"};
        
        // Trending tag urls
        public static URL TrendingIllustTags = new URL() {Address = "https://app-api.pixiv.net/v1/trending-tags/illust", Type = "GET"};
        public static URL TrendingNovelTags =  new URL() {Address = "https://app-api.pixiv.net/v1/trending-tags/novel", Type = "GET"};
        
        // Submission urls
        public static URL UploadIllust = new URL() {Address = "https://app-api.pixiv.net/v1/upload/illust", Type = "POST", Multipart = true};
        public static URL DeleteIllust = new URL() {Address = "https://app-api.pixiv.net/v1/illust/delete", Type = "POST"};
        public static URL AddIllustComment = new URL() {Address = "https://app-api.pixiv.net/v1/illust/comment/add", Type = "POST"};
        public static URL DeleteIllustComment = new URL() {Address = "https://app-api.pixiv.net/v1/illust/comment/delete"};
        public static URL GetNovelCoveres = new URL() {Address = "https://app-api.pixiv.net/v1/upload/novel/covers", Type = "GET"};
        public static URL UploadNovelDraft = new URL() {Address = "https://app-api.pixiv.net/v1/upload/novel/draft", Type = "POST"};
        public static URL ListNovelDrafts = new URL() {Address = "https://app-api.pixiv.net/v1/user/novel-draft-previews", Type = "GET"};
        public static URL ViewNovelDraft = new URL() {Address = "https://app-api.pixiv.net/v1/user/novel/draft/detail", Type = "GET"};
        public static URL DeleteNovelDraft = new URL() {Address = "https://app-api.pixiv.net/v1/user/novel/draft/delete", Type = "POST"};
        public static URL UploadNovel = new URL() {Address = "https://app-api.pixiv.net/v1/upload/novel", Type = "POST"};
        public static URL DeleteNovel = new URL() {Address = "https://app-api.pixiv.net/v1/novel/delete", Type = "POST"};
        public static URL AddNovelComment = new URL() {Address = "https://app-api.pixiv.net/v1/novel/comment/add", Type = "POST"};
        public static URL DeleteNovelComment = new URL() {Address = "https://app-api.pixiv.net/v1/novel/comment/delete", Type = "POST"};
        
        // Misc urls
        public static URL GetEmoji = new URL() {Address = "https://app-api.pixiv.net/v1/emoji", Type = "GET", AuthRequired = false};
        public static URL WalkthroughIllusts = new URL() {Address = "https://app-api.pixiv.net/v1/walkthrough/illusts", Type = "GET", AuthRequired = false};
        public static URL RegisterNotifications = new URL() {Address = "https://app-api.pixiv.net/v1/notification/user/register", Type = "GET", AuthRequired = false};
    }

    // Url class
    public class URL
    {
        public string Address { get; set; }
        public string Type { get; set; }
        public bool AuthRequired { get; set; } = true;
        public bool Multipart { get; set; }
    }
}