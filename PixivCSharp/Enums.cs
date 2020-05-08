namespace PixivCSharp
{
    public enum Filter
    {
        None,
        Android,
        IOS
    }

    public enum Publicity
    {
        Public,
        Private,
        MyPixiv
    }

    public enum Sort
    {
        DateDesc,
        DateAsc
    }

    public enum SearchTarget
    {
        PartialTagMatch,
        ExactTagMatch,
        TitleAndCaption
    }

    public enum RankingMode
    {
        Day,
        Week,
        Month,
        DayMale,
        DayFemale,
        WeekOriginal,
        DayManga,
        WeekRookieManga,
        WeekManga,
        MonthManga
    }
}