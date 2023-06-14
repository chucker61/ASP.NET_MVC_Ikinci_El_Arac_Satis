namespace AracSatis.Models.Entity
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
