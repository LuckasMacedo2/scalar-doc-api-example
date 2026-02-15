using Scalar.AspNetCore;
using WebApiScalarExample.Endpoints;
using WebApiScalarExample.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.Title = "API example with Scalar";
        options.Theme = ScalarTheme.DeepSpace;
    });
}

app.MapProductsEndpoints();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
