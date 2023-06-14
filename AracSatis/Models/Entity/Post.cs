namespace AracSatis.Models.Entity
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
        public bool isPublic { get; set; }
        public string CreatorId { get; set; }
        public int CarId { get; set; }

        //Relations
        public AppUser Creator { get; set; }
        public Car Car { get; set; }
    }
}
