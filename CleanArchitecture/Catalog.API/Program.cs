using Catalog.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Catalog.Infrastructure;
using Catalog.Application;
using MediatR;
using Catalog.Application.Features.Products.Queries.GetAllProducts;
using Catalog.Application.Features.Products.Queries.GetProductById;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CatalogConnection");
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//minimal api'de, Controller yok. Dolayısıyla action da yok ve bundan dolayı Filter da yok.
app.MapGet("/products", async (IMediator mediator) =>
{
    var query = new GetAllProductsQuery();
    var response = await mediator.Send(query);
    return Results.Ok(response);

});

app.MapGet("/products/{id}", async (IMediator mediator, int id) =>
{
    var query = new GetProductByIdQuery(id);
    var response = await mediator.Send(query);
    return Results.Ok(response);
});

app.Run();

