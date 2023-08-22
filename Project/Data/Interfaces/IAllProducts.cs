using Project.Models;

namespace Project.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Products> Products { get; }
        Products GetProductById(int id);
        IEnumerable<Products> GetProductsByCategory(string categoryName);
        void AddProduct(Products product);
        void DeleteProduct(int id);
        void UpdateProduct(Products product);
    }
}
