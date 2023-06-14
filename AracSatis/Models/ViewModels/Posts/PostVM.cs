using AracSatis.Models.Entity;

namespace AracSatis.Models.ViewModels.Posts
{
    public class PostVM
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int minYear { get; set; }
        public int maxYear { get; set; }
        public int minKilometer { get; set; }
        public int maxKilometer { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public int SelectedFuelType { get; set; }
        public int SelectedTransmissionType { get; set; }
        public int SelectedCategory { get; set; }
        public List<int> SelectedExtras { get; set; } = new List<int>();
        public Post Post { get; set; }
        public Car Car { get; set; }
        public List<Image> Images { get; set; }
        public List<Category> Categories { get; set; }
        public List<Post> Posts { get; set; }
        public List<FuelType> FuelTypes { get; set; }
        public List<TransmissionType> TransmissionTypes { get; set; }
    }
}
