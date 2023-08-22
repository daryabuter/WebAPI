using Project.Models.Project.ViewModels;

namespace Project.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Models.Products> AllProducts { get; set; }

        public string productCategory { get; set; }
        public string ProductCategory { get; internal set; }
        public ProductViewModel NewProduct { get; set; }

    }
}
