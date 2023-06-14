namespace AracSatis.Models.Entity
{
    public class TransmissionType : BaseEntity
    {
        public string Name { get; set; }

        //Relations
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
