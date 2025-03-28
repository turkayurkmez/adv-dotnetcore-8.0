using dotnetWithDocker.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var defaultHost = builder.Configuration["DefaultHost"];
var defaultPass = builder.Configuration["DefaultPass"];


connectionString = connectionString!.Replace("[DefaultHost]", defaultHost)
                .Replace("[DefaultPass]", defaultPass);



builder.Services.AddDbContext<SampleDbContext>(option => option.UseSqlServer(connectionString, b=>b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));



var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<SampleDbContext>();
await context.Database.MigrateAsync();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
