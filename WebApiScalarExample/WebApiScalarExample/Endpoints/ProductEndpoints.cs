using WebApiScalarExample.Endpoints.Interface;
using WebApiScalarExample.Models;
using WebApiScalarExample.Repository;

namespace WebApiScalarExample.Endpoints
{
    public class ProductEndpoints : IBaseEndpoints
    {
        private const string PRODUCT_NOT_FOUND_MESSAGE = "Product not found!!!";
        public void Map(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/product").RequireAuthorization();

            group.MapGet("/", GetAll);
            group.MapGet("/{id:int}", GetById);
            group.MapPost("/", AddProduct);
            group.MapPatch("/{id:int}", UpdateProduct);
            group.MapDelete("/{id:int}", DeleteProduct);
        }

        private IResult GetAll(ProductRepository productRepository) => Results.Ok(productRepository.GetAll());

        private IResult GetById(int id, ProductRepository productRepository)
        {
            var product = productRepository.GetById(id);
            return product is not null ? Results.Ok(product) : Results.NotFound(PRODUCT_NOT_FOUND_MESSAGE);
        }

        private IResult AddProduct(ProductUpdate product, ProductRepository productRepository)
        {
            var productCreated = productRepository.AddProduct(product);
            return Results.Created($"/product/{productCreated.Id}", productCreated);
        }

        private IResult UpdateProduct(ProductUpdate product, int id, ProductRepository productRepository)
        {
            bool isProductAdd = productRepository.UpdateProduct(product, id);
            return isProductAdd ? Results.NoContent() : Results.NotFound(PRODUCT_NOT_FOUND_MESSAGE);
        }

        private IResult DeleteProduct(int id, ProductRepository productRepository)
        {
            bool isProductDeleted = productRepository.DeleteProduct(id);
            return isProductDeleted ? Results.NoContent() : Results.NotFound(PRODUCT_NOT_FOUND_MESSAGE);
        }
    }
}
