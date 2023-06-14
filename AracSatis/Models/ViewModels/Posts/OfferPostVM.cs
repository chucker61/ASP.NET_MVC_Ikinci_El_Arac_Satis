using AracSatis.Models.Entity;
using System.Reflection.Metadata.Ecma335;

namespace AracSatis.Models.ViewModels.Posts
{
    public class OfferPostVM
    {
        public Car Car { get; set; }
        public Post Post { get; set; }
        public Category Category { get; set; }
        public FuelType FuelType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public List<Image> Images { get; set; }
        public List<Extra> Extras { get; set; }
        public List<ExtraType> ExtraTypes { get; set; }
    }
}
