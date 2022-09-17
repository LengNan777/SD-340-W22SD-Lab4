using Microsoft.EntityFrameworkCore;
using SD_340_W22SD_Lab4.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SD340W22SDLab4Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SD340W22SDLab4Context")));
var app = builder.Build();

app.MapGet("/", async () =>
    "Welcome to the transit website! \n\n" +
    "You can input the following command in address after the port number: \n\n" +
    "/routes \n to check all routes information\n\n" +
    "/routes/{id} \n to check the specific route\n\n" +
    "/stops \n to check all stops information\n\n" +
    "/stops/{id} \n to check the specific stop information \n\n" +
    "/stopSchedule \n to check all scheduled for all stops." +
    "/stopSchedule?number={}&top={} \n to check \"top\" amount of scheduled stops for stop."
);

app.MapGet("/routes", async (SD340W22SDLab4Context db) =>
    await db.Routes.ToListAsync()
);

app.MapGet("/routes/{id}", async (int id, SD340W22SDLab4Context db) =>
{
    var result = await db.Routes.FindAsync(id);
    if (result != null)
    {
        return Results.Ok(result);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/stops", async (SD340W22SDLab4Context db) =>
    await db.Stops.ToListAsync()
);

app.MapGet("/stops/{id}", async (int id, SD340W22SDLab4Context db) =>
    await db.Stops.Where(s => s.Number == id).ToListAsync()
);

app.MapGet("/stopSchedule", async (int? number, int? top, SD340W22SDLab4Context db) =>
{   
    if(number != null && top != null)
    {
        return await db.ScheduledStops.Where(s => s.StopNumber == number).Take((int)top).ToListAsync();
    }
    else
    {
        return await db.ScheduledStops.ToListAsync();
    } 
});

app.Run();