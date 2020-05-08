namespace PixivCSharp
{
    public enum Filter
    {
        None,
        [JsonValue("for_android")]
        Android,
        [JsonValue("for_ios")]
        IOS
    }

    public enum Publicity
    {
        [JsonValue("public")]
        Public,
        [JsonValue("private")]
        Private,
        [JsonValue("mypixiv")]
        MyPixiv
    }

    public enum Sort
    {
        [JsonValue("date_desc")]
        DateDesc,
        [JsonValue("date_asc")]
        DateAsc
    }

    public enum SearchTarget
    {
        [JsonValue("partial_match_for_tags")]
        PartialTagMatch,
        [JsonValue("exact_match_for_tags")]
        ExactTagMatch,
        [JsonValue("title_and_caption")]
        TitleAndCaption
    }

    public enum RankingMode
    {
        [JsonValue("day")]
        Day,
        [JsonValue("week")]
        Week,
        [JsonValue("month")]
        Month,
        [JsonValue("day_male")]
        DayMale,
        [JsonValue("day_female")]
        DayFemale,
        [JsonValue("week_original")]
        WeekOriginal,
        [JsonValue("day_manga")]
        DayManga,
        [JsonValue("week_rookie_manga")]
        WeekRookieManga,
        [JsonValue("week_manga")]
        WeekManga,
        [JsonValue("month_manga")]
        MonthManga
    }
}