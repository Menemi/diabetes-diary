using AspNetServer.Data.Classes;
using AspNetServer.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AspNetServer.Data.Repositories;

public class DosesRepository
{
    private async static Task<DosesClass> GetDosesByIdAsync(int id)
    {
        using (var db = new AppDbContext())
        {
            return await db.Doses.FirstOrDefaultAsync(dose => dose.Id == id);
        }
    }

    internal async static Task<List<DosesClass>> GetDosesAsync()
    {
        using (var db = new AppDbContext())
        {
            return await db.Doses.ToListAsync();
        }
    }

    internal async static Task<bool> CreateDosesAsync(DosesClass dose)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var startTime = DateTime.Parse(dose.StartTime);
                var endTime = DateTime.Parse(dose.EndTime);

                dose.StartTime = startTime.ToShortTimeString();
                dose.EndTime = endTime.ToShortTimeString();

                await db.Doses.AddAsync(dose);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal async static Task<bool> UpdateDosesAsync(DosesClass dose)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var startTime = DateTime.Parse(dose.StartTime);
                var endTime = DateTime.Parse(dose.EndTime);

                dose.StartTime = startTime.ToShortTimeString();
                dose.EndTime = endTime.ToShortTimeString();

                db.Doses.Update(dose);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal async static Task<bool> RemoveDosesAsync(int doseId)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var dose = await GetDosesByIdAsync(doseId);
                db.Remove(dose);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}