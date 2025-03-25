using POCforDI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ISingletonGuidGenerator, SingletonGuid>();
builder.Services.AddScoped<IScopedGuidGenerator, ScopedGuid>();
builder.Services.AddTransient<ITransientGuidGenerator, TransientGuid>();



builder.Services.AddTransient<ScopedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//ister middleware olarak:
app.Use((context,next) =>
{
    using var scope = app.Services.CreateScope();
    var scopedGuid = scope.ServiceProvider.GetRequiredService<IScopedGuidGenerator>();
    //scopedGuid'i kullan.

    return next(context);
});

//veya doğrudan kullan:

using var scope = app.Services.CreateScope();
var scopedGuid = scope.ServiceProvider.GetRequiredService<IScopedGuidGenerator>();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
