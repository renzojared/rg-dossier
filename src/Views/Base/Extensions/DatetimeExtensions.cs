namespace Views.Base.Extensions;

public static class DatetimeExtensions
{
    private static DateTime Today => DateTime.Today;

    public static DateTime FirstDayMonth(this DateTime dateTime)
        => new(Today.Year, Today.Month, 1);

    public static DateTime LastDayMonth(this DateTime dateTime)
        => dateTime.FirstDayMonth().AddMonths(1).AddDays(-1);
}