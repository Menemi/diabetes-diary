using AspNetServer.Data.Exceptions;

namespace AspNetServer.Data.Classes;

internal static class DateConverter
{
    internal static List<DateTime> StringToDateTime(string date1, string? date2 = null)
    {
        DateTime firstDate;

        if (date2 != null)
        {
            DateTime secondDate;

            try
            {
                firstDate = DateTime.Parse(date1).Date;
                secondDate = DateTime.Parse(date2).Date;
            }
            catch (DateTimeFormatException)
            {
                throw new DateTimeFormatException();
            }

            return firstDate > secondDate
                ? new List<DateTime> { secondDate, firstDate }
                : new List<DateTime> { firstDate, secondDate };
        }

        try
        {
            firstDate = DateTime.Parse(date1).Date;
        }
        catch (Exception)
        {
            throw new DateTimeFormatException();
        }

        return new List<DateTime> { firstDate };
    }
}