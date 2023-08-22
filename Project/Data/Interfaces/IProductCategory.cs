using Project.Data.Models;

namespace Project.Data.Interfaces
{
    public interface IProductCategory
    {
        IEnumerable<Category> GetCategories { get; }
    }
}
