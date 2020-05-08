namespace PixivCSharp
{
    /// <summary>
    /// Potential values for filter parameter.
    /// </summary>
    public enum Filter
    {
        /// <summary>
        /// No filter.
        /// </summary>
        None,
        
        /// <summary>
        /// Filters all images that potentially contain sensetive content.
        /// </summary>
        [JsonValue("for_android")]
        Android,

        /// <summary>
        /// Filters all images that potentially contain sensetive content.
        /// </summary>
        [JsonValue("for_ios")]
        IOS
    }

    /// <summary>
    /// Potential values for the restrict parameter.
    /// </summary>
    public enum Publicity
    {
        /// <summary>
        /// Public works.
        /// </summary>
        [JsonValue("public")]
        Public,

        /// <summary>
        /// Private works.
        /// </summary>
        [JsonValue("private")]
        Private,

        /// <summary>
        /// Works restricted to mypixiv users.
        /// </summary>
        [JsonValue("mypixiv")]
        MyPixiv
    }

    /// <summary>
    /// Potential values of the sort parameter.
    /// </summary>
    public enum Sort
    {
        /// <summary>
        /// Date descending.
        /// </summary>
        [JsonValue("date_desc")]
        DateDesc,

        /// <summary>
        /// Date ascending.
        /// </summary>
        [JsonValue("date_asc")]
        DateAsc
    }

    /// <summary>
    /// Specifies the search target.
    /// </summary>
    public enum SearchTarget
    {
        /// <summary>
        /// Match tags partially.
        /// </summary>
        [JsonValue("partial_match_for_tags")]
        PartialTagMatch,

        /// <summary>
        /// Matchs tags exactly.
        /// </summary>
        [JsonValue("exact_match_for_tags")]
        ExactTagMatch,

        /// <summary>
        /// Matchs title and caption.
        /// </summary>
        [JsonValue("title_and_caption")]
        TitleAndCaption
    }

    /// <summary>
    /// Specifies the rankings to view.
    /// </summary>
    public enum RankingMode
    {
        /// <summary>
        /// Daily rankings.
        /// </summary>
        [JsonValue("day")]
        Day,

        /// <summary>
        /// Weekly rankings.
        /// </summary>
        [JsonValue("week")]
        Week,

        /// <summary>
        /// Monthly rankings
        /// </summary>
        [JsonValue("month")]
        Month,

        /// <summary>
        /// Daily rankings for male users.
        /// </summary>
        [JsonValue("day_male")]
        DayMale,

        /// <summary>
        /// Daily rankings for female users.
        /// </summary>
        [JsonValue("day_female")]
        DayFemale,

        /// <summary>
        /// Weekly ranking for original works.
        /// </summary>
        [JsonValue("week_original")]
        WeekOriginal,

        /// <summary>
        /// Daily rankings for manga.
        /// </summary>
        [JsonValue("day_manga")]
        DayManga,

        /// <summary>
        /// Weekly rankings for rookie manga.
        /// </summary>
        [JsonValue("week_rookie_manga")]
        WeekRookieManga,

        /// <summary>
        /// Weekly rankings for manga.
        /// </summary>
        [JsonValue("week_manga")]
        WeekManga,

        /// <summary>
        /// Monthly rankings for manga.
        /// </summary>
        [JsonValue("month_manga")]
        MonthManga
    }
}