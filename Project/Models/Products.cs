using Project.Data.Models;

namespace Project.Models
{
    public class Products
    {
        public int ID { set; get; }
        public string? Name { set; get; }
        public string CategoryName { set; get; }
        public virtual Category? Category { set; get; }
        public ushort Price { set; get; }
        public string? Note { set; get; }
        public string? SpecialNote { set; get; }
        public string? Discription { set; get; }
    }
}
