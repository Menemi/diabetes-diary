using AspNetServer.Data.Classes;
using AspNetServer.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AspNetServer.Data.Repositories;

internal static class InsulinRepository
{
    private async static Task<InsulinClass> GetInsulinByIdAsync(int id)
    {
        using (var db = new AppDbContext())
        {
            return await db.Insulin.FirstOrDefaultAsync(insulin => insulin.Id == id);
        }
    }

    internal async static Task<InsulinClass> GetLastInsulinAsync()
    {
        using (var db = new AppDbContext())
        {
            var lastInsulin = new InsulinClass();

            var maxTime = DateTime.MinValue;
            
            foreach (var insulin in db.Insulin)
            {
                if (maxTime.Date < DateTime.Parse(insulin.Time).Date)
                {
                    lastInsulin = insulin;
                    maxTime = DateTime.Parse(insulin.Time).Date;
                }
            }

            return lastInsulin;
        }
    }

    internal async static Task<List<InsulinClass>> GetInsulinAsync(string? date1, string? date2)
    {
        using (var db = new AppDbContext())
        {
            switch (date1)
            {
                case null when date2 == null:
                    return await db.Insulin.ToListAsync();
                case null:
                    return new List<InsulinClass>();
            }

            List<DateTime> gotDates;
            try
            {
                gotDates = DateConverter.StringToDateTime(date1, date2);
            }
            catch (DateTimeFormatException)
            {
                return new List<InsulinClass>();
            }

            var firstDate = gotDates[0].Date;
            List<InsulinClass>? resultData;
            if (date2 != null)
            {
                var secondDate = gotDates[1].Date;
                resultData = new List<InsulinClass>();

                foreach (var insulin in db.Insulin)
                {
                    if (firstDate <= DateTime.Parse(insulin.Time).Date &&
                        DateTime.Parse(insulin.Time).Date <= secondDate)
                    {
                        resultData.Add(insulin);
                    }
                }

                return resultData;
            }

            resultData = new List<InsulinClass>();

            foreach (var insulin in db.Insulin)
            {
                if (firstDate == DateTime.Parse(insulin.Time).Date)
                {
                    resultData.Add(insulin);
                }
            }

            return resultData;
        }
    }

    internal async static Task<bool> CreateInsulinAsync(InsulinClass insulin)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var time = DateTime.Parse(insulin.Time);

                insulin.Time = $"{time.ToShortTimeString()} {time.ToShortDateString()}";

                await db.Insulin.AddAsync(insulin);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal async static Task<bool> UpdateInsulinAsync(InsulinClass insulin)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var time = DateTime.Parse(insulin.Time);

                insulin.Time = $"{time.ToShortTimeString()} {time.ToShortDateString()}";

                db.Insulin.Update(insulin);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal async static Task<bool> RemoveInsulinAsync(int insulinId)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var insulin = await GetInsulinByIdAsync(insulinId);
                db.Remove(insulin);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}