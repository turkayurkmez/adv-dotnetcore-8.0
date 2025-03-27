using OptionsPattern.Models;
using OptionsPattern.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<EmailMonitorService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
 * appsettings/json dosyayindaki veriyi EmailSettings nesnesine bind etmek ve bu nesneyi
 * herhangi bir nesneye enjekte etmek için Configure metodu kullanılır.
 * 
 * Eğer sadece bind etmek isteseydim:
 * builder.Configuration.GetSection("EmailSettings").Bind(new EmailSettings());
   builder.Configuration.Get<EmailSettings>();
 */


builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddSingleton<MailService>();
builder.Services.AddScoped<ConfigAwareService>();


var app = builder.Build();

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
