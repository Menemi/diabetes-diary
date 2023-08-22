using AspNetServer.Data.Classes;
using AspNetServer.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using NetTopologySuite.IO.Converters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policyBuilder =>
        {
            policyBuilder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1.0", new OpenApiInfo
        {
            Title = "DiabetesDiary", Version = "v1.0"
        });
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "DiabetesDiary";
        options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Web API");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

#region Sugars

app.MapGet("/sugars", async (string? date1, string? date2) => await SugarsRepository.GetSugarsAsync(date1, date2))
    .WithTags("Sugars");

app.MapGet("/sugars/avg", async (string? date1, string? date2) => await SugarsRepository.GetAvgSugarAsync(date1, date2))
    .WithTags("Sugars");

app.MapPost("/sugars", async ([FromBody] SugarClass sugar) =>
{
    var isCreated = await SugarsRepository.CreateSugarAsync(sugar);

    return isCreated ? Results.Ok(sugar) : Results.BadRequest();
}).WithTags("Sugars");

app.MapPut("/sugars", async ([FromBody] SugarClass sugar) =>
{
    var isUpdated = await SugarsRepository.UpdateSugarAsync(sugar);

    return isUpdated ? Results.Ok(sugar) : Results.BadRequest();
}).WithTags("Sugars");

app.MapDelete("/sugars/{id}", async (int id) =>
{
    var isRemoved = await SugarsRepository.RemoveSugarAsync(id);

    return isRemoved ? Results.Ok($"Sugar with id {id} was removed") : Results.BadRequest();
}).WithTags("Sugars");

#endregion

#region Food

app.MapGet("/food", async (string? date1, string? date2) => await FoodRepository.GetFoodAsync(date1, date2))
    .WithTags("Food");

app.MapPost("/food", async ([FromBody] FoodClass food) =>
{
    var isCreated = await FoodRepository.CreateFoodAsync(food);

    return isCreated ? Results.Ok(food) : Results.BadRequest();
}).WithTags("Food");

app.MapPut("/food", async ([FromBody] FoodClass food) =>
{
    var isUpdated = await FoodRepository.UpdateFoodAsync(food);

    return isUpdated ? Results.Ok(food) : Results.BadRequest();
}).WithTags("Food");

app.MapDelete("/food/{id}", async (int id) =>
{
    var isRemoved = await FoodRepository.RemoveFoodAsync(id);

    return isRemoved ? Results.Ok($"Food with id {id} was removed") : Results.BadRequest();
}).WithTags("Food");

#endregion

#region Insulin

app.MapGet("/insulin", async (string? date1, string? date2) => await InsulinRepository.GetInsulinAsync(date1, date2))
    .WithTags("Insulin");

app.MapGet("/insulin/last", async () => await InsulinRepository.GetLastInsulinAsync())
    .WithTags("Insulin");

app.MapPost("/insulin", async ([FromBody] InsulinClass insulin) =>
{
    var isCreated = await InsulinRepository.CreateInsulinAsync(insulin);

    return isCreated ? Results.Ok(insulin) : Results.BadRequest();
}).WithTags("Insulin");

app.MapPut("/insulin", async ([FromBody] InsulinClass insulin) =>
{
    var isUpdated = await InsulinRepository.UpdateInsulinAsync(insulin);

    return isUpdated ? Results.Ok(insulin) : Results.BadRequest();
}).WithTags("Insulin");

app.MapDelete("/insulin/{id}", async (int id) =>
{
    var isRemoved = await InsulinRepository.RemoveInsulinAsync(id);

    return isRemoved ? Results.Ok($"Insulin with id {id} was removed") : Results.BadRequest();
}).WithTags("Insulin");

#endregion

#region Catheter

app.MapGet("/catheters",
        async (string? date1, string? date2) => await CathetersRepository.GetCatheterAsync(date1, date2))
    .WithTags("Catheters");

app.MapGet("/catheter/last", async () => await CathetersRepository.GetLastCatheterAsync())
    .WithTags("Catheters");

app.MapPost("/catheters", async ([FromBody] CatheterClass catheter) =>
{
    var isCreated = await CathetersRepository.CreateCatheterAsync(catheter);

    return isCreated ? Results.Ok(catheter) : Results.BadRequest();
}).WithTags("Catheters");

app.MapPut("/catheters", async ([FromBody] CatheterClass catheter) =>
{
    var isUpdated = await CathetersRepository.UpdateCatheterAsync(catheter);

    return isUpdated ? Results.Ok(catheter) : Results.BadRequest();
}).WithTags("Catheters");

app.MapDelete("/catheters/{id}", async (int id) =>
{
    var isRemoved = await CathetersRepository.RemoveCatheterAsync(id);

    return isRemoved ? Results.Ok($"Catheter with id {id} was removed") : Results.BadRequest();
}).WithTags("Catheters");

#endregion

#region Doses

app.MapGet("/doses", async () => await DosesRepository.GetDosesAsync())
    .WithTags("Doses");

app.MapPost("/doses", async ([FromBody] DosesClass dose) =>
{
    var isCreated = await DosesRepository.CreateDosesAsync(dose);

    return isCreated ? Results.Ok(dose) : Results.BadRequest();
}).WithTags("Doses");

app.MapPut("/doses", async ([FromBody] DosesClass dose) =>
{
    var isUpdated = await DosesRepository.UpdateDosesAsync(dose);

    return isUpdated ? Results.Ok(dose) : Results.BadRequest();
}).WithTags("Doses");

app.MapDelete("/doses/{id}", async (int id) =>
{
    var isRemoved = await DosesRepository.RemoveDosesAsync(id);

    return isRemoved ? Results.Ok($"Dose with id {id} was removed") : Results.BadRequest();
}).WithTags("Doses");

#endregion

app.Run();