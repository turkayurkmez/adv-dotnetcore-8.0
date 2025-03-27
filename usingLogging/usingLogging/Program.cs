using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Enrichers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddEventLog();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .Enrich.WithMachineName() // Ensure you have the Serilog.Enrichers.Environment package installed
    .Enrich.WithEnvironmentName()
    .WriteTo.Console(outputTemplate:"[{Timestampt:HH:mm:ss} {Level: u3}] {SourceContext} {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

//builder.Logging.AddSerilog(Log.Logger);
builder.Host.UseSerilog();

//builder.Logging.AddFilter("System", LogLevel.Warning);
//builder.Logging.AddFilter("Microsoft", LogLevel.Warning);
//builder.Logging.AddFilter("WeatherForecastController", LogLevel.Debug);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var info = app.Configuration.GetValue<string>("Info");
app.Logger.LogInformation($"Belgedeki değer: {info}");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
