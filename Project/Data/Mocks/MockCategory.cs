using Project.Data.Interfaces;
using Project.Data.Models;

//реализация интерфейса IProductCategory для получeние всех категорий 
namespace Project.Data.Mocks
{
    public class MockCategory : IProductCategory
    {
        public IEnumerable<Category> GetCategories
        {
            get {
                return new List<Category> {
                    new Category { CategoryName = "Еда"},
                    new Category { CategoryName = "Вкусности"},
                    new Category { CategoryName = "Вода"}
                };
            }
        }
    }
}