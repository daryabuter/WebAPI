using Project.Data.Interfaces;
using Project.Models;

namespace Project.Data.Mocks
{
    public class MockAllProducts : IAllProducts
    {
        private readonly IProductCategory _productCategory = new MockCategory();
        private readonly List<Products> _products;

        public MockAllProducts()
        {
            _products = new List<Products>
            {
                new Products { ID = 1, Name = "Селедка", CategoryName = _productCategory.GetCategories.First().CategoryName, Price = 10000, Note = "", SpecialNote = "", Discription = ""},
                new Products { ID = 2, Name = "Тушенка", CategoryName = _productCategory.GetCategories.First().CategoryName, Price = 20000, Note = "", SpecialNote = "", Discription = "" },
                new Products { ID = 3, Name = "Сгущенка", CategoryName = _productCategory.GetCategories.First().CategoryName, Price = 30000, Note = "", SpecialNote = "", Discription = "" },
                new Products { ID = 4, Name = "Квас", CategoryName = _productCategory.GetCategories.Last().CategoryName, Price = 15000, Note = "", SpecialNote = "", Discription = "" }
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

        public IEnumerable<Products> GetProductsByCategory(string categoryName)
        {
            return _products.Where(p => p.CategoryName == categoryName);
        }

    }
}
