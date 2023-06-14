using AracSatis.Models.Entity;

namespace AracSatis.Models.ViewModels.Categories
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
}
