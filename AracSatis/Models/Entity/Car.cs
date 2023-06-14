namespace AracSatis.Models.Entity
{
    public class Car : BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Kilometer { get; set; }
        public int HorsePower { get; set; }
        public string LocationCountry { get; set; }
        public string LocationCity { get; set; }
        public int CategoryId { get; set; }
        public int FuelTypeId { get; set; }
        public int TransmissionTypeId { get; set; }

        //Relations
        public Post Post { get; set; }
        public Category Category { get; set; }
        public FuelType FuelType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public ICollection<CarExtra> CarExtras { get; set; } = new HashSet<CarExtra>();
    }
}
