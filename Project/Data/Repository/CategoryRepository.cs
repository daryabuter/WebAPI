using Project.Data.Interfaces;
using Project.Data.Models;

namespace Project.Data.Repository
{
    public class CategoryRepository : IProductCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> GetCategories => appDBContent.Category;
    }
}
