using CustomMiddleware.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiMonitoring(option =>
{
    if (builder.Environment.IsProduction())
    {
        option.LogRequestBody = false;
        option.LogResponseBody = false;
        option.SlowRequestsThresholds = 2000;
        option.MaxLogLength = 4000;

    }
    else if (builder.Environment.IsDevelopment())
    {
        option.LogRequestBody = true;
        option.LogResponseBody = true;
        option.SlowRequestsThresholds = 1000;
        option.MaxLogLength = 2000;
    }
   
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseApiMonitoring();


app.MapControllers();

app.Run();
