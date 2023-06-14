namespace AracSatis.Models.Entity
{
    public class CarExtra : BaseEntity
    {
        public int CarId { get; set; }
        public int ExtraId { get; set; }

        //Relations

        public Car Car { get; set; }
        public Extra Extra { get; set; }
    }
}
