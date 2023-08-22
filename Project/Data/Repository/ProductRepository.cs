using Project.Data.Interfaces;
using Project.Data.Mocks;
using Project.Models;


namespace Project.Data.Repository
{
    public class ProductRepository : IAllProducts
    {
        private readonly IProductCategory _productCategory = new MockCategory();
        private readonly List<Products> _products;

        public ProductRepository()
        {
            _products = new List<Products>
            {
            };
        }

        public IEnumerable<Products> Products => _products;

        public Products GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.ID == id);
        }

        public void AddProduct(Products product)
        {
            product.ID = _products.Max(p => p.ID) + 1;
            _products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _products.FirstOrDefault(p => p.ID == id);
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
            }
        }

        public void UpdateProduct(Products product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ID == product.ID);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }

        public IEnumerable<Products> GetProductsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category) || category.ToLower() == "all")
            {
                return Products;
            }
            else
            {
                return Products.Where(p => p.CategoryName.ToLower() == category.ToLower());
            }
        }
    }
}
