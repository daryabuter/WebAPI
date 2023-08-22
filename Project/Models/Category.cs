using Project.Models;

namespace Project.Data.Models
{
    public class Category
    {
        public int CategoryID { set; get; }
        public string? CategoryName { set; get; }
        public List<Products>? Products { set; get; }
    }
}
