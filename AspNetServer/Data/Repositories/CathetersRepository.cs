using AspNetServer.Data.Classes;
using AspNetServer.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AspNetServer.Data.Repositories;

internal static class CathetersRepository
{
    private async static Task<CatheterClass> GetCatheterByIdAsync(int id)
    {
        using (var db = new AppDbContext())
        {
            return await db.Catheters.FirstOrDefaultAsync(catheter => catheter.Id == id);
        }
    }
    
    internal async static Task<CatheterClass> GetLastCatheterAsync()
    {
        using (var db = new AppDbContext())
        {
            var lastCatheter = new CatheterClass();

            var maxTime = DateTime.MinValue;
            
            foreach (var catheter in db.Catheters)
            {
                if (maxTime.Date < DateTime.Parse(catheter.Time).Date)
                {
                    lastCatheter = catheter;
                    maxTime = DateTime.Parse(catheter.Time).Date;
                }
            }

            return lastCatheter;
        }
    }

    internal async static Task<List<CatheterClass>> GetCatheterAsync(string? date1, string? date2)
    {
        using (var db = new AppDbContext())
        {
            switch (date1)
            {
                case null when date2 == null:
                    return await db.Catheters.ToListAsync();
                case null:
                    return new List<CatheterClass>();
            }

            List<DateTime> gotDates;
            try
            {
                gotDates = DateConverter.StringToDateTime(date1, date2);
            }
            catch (DateTimeFormatException)
            {
                return new List<CatheterClass>();
            }

            var firstDate = gotDates[0].Date;
            List<CatheterClass>? resultData;
            if (date2 != null)
            {
                var secondDate = gotDates[1].Date;
                resultData = new List<CatheterClass>();

                foreach (var catheter in db.Catheters)
                {
                    if (firstDate <= DateTime.Parse(catheter.Time).Date &&
                        DateTime.Parse(catheter.Time).Date <= secondDate)
                    {
                        resultData.Add(catheter);
                    }
                }

                return resultData;
            }

            resultData = new List<CatheterClass>();

            foreach (var catheter in db.Catheters)
            {
                if (firstDate == DateTime.Parse(catheter.Time).Date)
                {
                    resultData.Add(catheter);
                }
            }

            return resultData;
        }
    }

    internal async static Task<bool> CreateCatheterAsync(CatheterClass catheter)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var time = DateTime.Parse(catheter.Time);

                catheter.Time = $"{time.ToShortTimeString()} {time.ToShortDateString()}";

                await db.Catheters.AddAsync(catheter);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal async static Task<bool> UpdateCatheterAsync(CatheterClass catheter)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var time = DateTime.Parse(catheter.Time);

                catheter.Time = $"{time.ToShortTimeString()} {time.ToShortDateString()}";

                db.Catheters.Update(catheter);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal async static Task<bool> RemoveCatheterAsync(int catheterId)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var catheter = await GetCatheterByIdAsync(catheterId);
                db.Remove(catheter);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}