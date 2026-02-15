using WebApiScalarExample.Models;

namespace WebApiScalarExample.Repository
{
    public class ProductRepository
    {

        private readonly List<Product> _products = ProductMock.Products;
        private int _nextId = 3;
        public List<Product> GetAll() => _products;

        public Product GetById(int id)
        {
            return FindProductByIdInTheList(id);
        }

        public Product AddProduct(ProductUpdate product)
        {
            var productCreated = new Product
            {
                Id = _nextId++,
                Name = product.Name,
                Price = product.Price,
            };
            _products.Add(productCreated);
            return productCreated;
        }

        public bool UpdateProduct(ProductUpdate productUpdate, int id)
        {
            var index = FindIndexOfProductById(id);
            if (index == -1) return false;

            _products[index].Price = productUpdate.Price;
            _products[index].Name = productUpdate.Name;

            return true;
        }

        public bool DeleteProduct(int id)
        {
            var index = FindIndexOfProductById(id);
            if (index == -1) return false;

            _products.RemoveAt(index);

            return true;
        }

        private Product FindProductByIdInTheList(int id) => _products.Find(x => x.Id == id);

        private int FindIndexOfProductById(int id) => _products.FindIndex(x => x.Id == id);
    }
}
