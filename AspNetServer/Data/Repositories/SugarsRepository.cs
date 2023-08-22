using AspNetServer.Data.Classes;
using AspNetServer.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AspNetServer.Data.Repositories;

internal static class SugarsRepository
{
    private async static Task<SugarClass> GetSugarByIdAsync(int id)
    {
        using (var db = new AppDbContext())
        {
            return await db.Sugars.FirstOrDefaultAsync(sugar => sugar.Id == id);
        }
    }

    internal async static Task<List<SugarClass>> GetSugarsAsync(string? date1, string? date2)
    {
        using (var db = new AppDbContext())
        {
            switch (date1)
            {
                case null when date2 == null:
                    return await db.Sugars.ToListAsync();
                case null:
                    return new List<SugarClass>();
            }

            List<DateTime> gotDates;
            try
            {
                gotDates = DateConverter.StringToDateTime(date1, date2);
            }
            catch (DateTimeFormatException)
            {
                return new List<SugarClass>();
            }

            var firstDate = gotDates[0].Date;
            List<SugarClass>? resultData;
            if (date2 != null)
            {
                var secondDate = gotDates[1].Date;
                resultData = new List<SugarClass>();

                foreach (var sugar in db.Sugars)
                {
                    if (firstDate <= DateTime.Parse(sugar.Time).Date &&
                        DateTime.Parse(sugar.Time).Date <= secondDate)
                    {
                        resultData.Add(sugar);
                    }
                }

                return resultData;
            }

            resultData = new List<SugarClass>();

            foreach (var sugar in db.Sugars)
            {
                if (firstDate == DateTime.Parse(sugar.Time).Date)
                {
                    resultData.Add(sugar);
                }
            }

            return resultData;
        }
    }

    internal async static Task<double> GetAvgSugarAsync(string? date1, string? date2)
    {
        var sugars = await GetSugarsAsync(date1, date2);
        if (sugars.Count == 0)
        {
            return 0;
        }

        return Math.Round(sugars.Sum(sugar => sugar.Sugar) / sugars.Count, 1);
    }

    internal async static Task<bool> CreateSugarAsync(SugarClass sugar)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var time = DateTime.Parse(sugar.Time);

                sugar.Time = $"{time.ToShortTimeString()} {time.ToShortDateString()}";

                await db.Sugars.AddAsync(sugar);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal async static Task<bool> UpdateSugarAsync(SugarClass sugar)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var time = DateTime.Parse(sugar.Time);

                sugar.Time = $"{time.ToShortTimeString()} {time.ToShortDateString()}";

                db.Sugars.Update(sugar);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal async static Task<bool> RemoveSugarAsync(int sugarId)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var sugar = await GetSugarByIdAsync(sugarId);
                db.Remove(sugar);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}