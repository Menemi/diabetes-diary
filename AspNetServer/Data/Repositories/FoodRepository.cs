using AspNetServer.Data.Classes;
using AspNetServer.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AspNetServer.Data.Repositories;

internal static class FoodRepository
{
    private async static Task<FoodClass> GetFoodByIdAsync(int id)
    {
        using (var db = new AppDbContext())
        {
            return await db.Food.FirstOrDefaultAsync(food => food.Id == id);
        }
    }

    internal async static Task<List<FoodClass>> GetFoodAsync(string? date1, string? date2)
    {
        using (var db = new AppDbContext())
        {
            switch (date1)
            {
                case null when date2 == null:
                    return await db.Food.ToListAsync();
                case null:
                    return new List<FoodClass>();
            }

            List<DateTime> gotDates;
            try
            {
                gotDates = DateConverter.StringToDateTime(date1, date2);
            }
            catch (DateTimeFormatException)
            {
                return new List<FoodClass>();
            }

            var firstDate = gotDates[0].Date;
            List<FoodClass>? resultData;
            if (date2 != null)
            {
                var secondDate = gotDates[1].Date;
                resultData = new List<FoodClass>();

                foreach (var food in db.Food)
                {
                    if (firstDate <= DateTime.Parse(food.Time).Date &&
                        DateTime.Parse(food.Time).Date <= secondDate)
                    {
                        resultData.Add(food);
                    }
                }

                return resultData;
            }

            resultData = new List<FoodClass>();

            foreach (var food in db.Food)
            {
                if (firstDate == DateTime.Parse(food.Time).Date)
                {
                    resultData.Add(food);
                }
            }

            return resultData;
        }
    }

    internal async static Task<bool> CreateFoodAsync(FoodClass food)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var time = DateTime.Parse(food.Time);

                food.Time = $"{time.ToShortTimeString()} {time.ToShortDateString()}";

                foreach (var dose in db.Doses)
                {
                    var startTime = DateTime.Parse(dose.StartTime);
                    var endTime = DateTime.Parse(dose.EndTime);

                    if (startTime.TimeOfDay <= time.TimeOfDay && time.TimeOfDay <= endTime.TimeOfDay)
                    {
                        food.Dose = dose.Dose;
                        break;
                    }
                }

                food.InsulinPinned = Math.Round(food.BreadUnits * food.Dose, 1);

                await db.Food.AddAsync(food);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal async static Task<bool> UpdateFoodAsync(FoodClass food)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var time = DateTime.Parse(food.Time);

                food.Time = $"{time.ToShortTimeString()} {time.ToShortDateString()}";
                
                foreach (var dose in db.Doses)
                {
                    var startTime = DateTime.Parse(dose.StartTime);
                    var endTime = DateTime.Parse(dose.EndTime);

                    if (startTime.TimeOfDay <= time.TimeOfDay && time.TimeOfDay <= endTime.TimeOfDay)
                    {
                        food.Dose = dose.Dose;
                        break;
                    }
                }
                
                food.InsulinPinned = Math.Round(food.BreadUnits * food.Dose, 1);

                db.Food.Update(food);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal async static Task<bool> RemoveFoodAsync(int foodId)
    {
        using (var db = new AppDbContext())
        {
            try
            {
                var food = await GetFoodByIdAsync(foodId);
                db.Remove(food);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}