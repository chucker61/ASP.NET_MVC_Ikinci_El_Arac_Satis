using AracSatis.Models.Entity;

namespace AracSatis.Models.ViewModels.Posts
{
    public class SearchPostVM
    {
        public string SearchTerm { get; set; }
        public int minYear { get; set; }
        public int maxYear { get; set; }
        public int minKilometer { get; set; }
        public int maxKilometer { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public List<int> SelectedFuelTypeIds { get; set; }
        public List<int> SelectedTransmissionTypeIds { get; set; }
        public List<int> SelectedCategoryIds { get; set; }
        public List<Category> Categories { get; set; }
        public List<FuelType> FuelTypes { get; set; }
        public List<TransmissionType> TransmissionTypes { get; set; }
    }
}
