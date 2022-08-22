using JonasCodingTestNet6.API.DbContexts;
using JonasCodingTestNet6.API.Services;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;
using JonasCodingTestNet6.API;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/jonascodingtestnet6.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();


// Add services to the container.

builder.Services.AddControllers(options =>
    options.ReturnHttpNotAcceptable = true

    ); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CompanyInfoContext>(
    dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:CompanyInfoDBConnectionString"]));

builder.Services.AddScoped<ICompanyInfoRepository, CompanyInfoRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(err => {
    err.Run(async context => {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "appliation/json";
        var feature = context.Features.Get<IExceptionHandlerFeature>();
        if (feature == null)
        {
            return;
        }
        Log.Error($"Things went wrong in the {feature.Error}");
        await context.Response.WriteAsync(new AppError
        {
            StatusCode = context.Response.StatusCode,
            Message = $"Internal server error with message {feature.Error}"

        }.ToString());
    });
});


app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
