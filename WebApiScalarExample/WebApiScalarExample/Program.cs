using DotNetEnv;
using Scalar.AspNetCore;
using WebApiScalarExample.Configurations;
using WebApiScalarExample.Endpoints;
using WebApiScalarExample.Extensions;
using WebApiScalarExample.Repository;
using WebApiScalarExample.Services;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductRepository>();
builder.Services.AddScoped<LoginService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

builder.Services.AddAutenticationAndAutorization();

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
app.MapLoginEndpoints();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
