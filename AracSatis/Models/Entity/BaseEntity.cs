
namespace AracSatis.Models.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool isDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
