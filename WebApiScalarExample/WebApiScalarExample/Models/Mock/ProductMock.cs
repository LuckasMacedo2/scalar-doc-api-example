namespace WebApiScalarExample.Models
{
    public static class ProductMock
    {
        public static List<Product> Products { get => new List<Product>
            {
                new Product { Id = 1, Name = "KeyBoard", Price = 100 },
                new Product { Id = 2, Name = "Mouse", Price = 50 }
            };
        }
    }
}
