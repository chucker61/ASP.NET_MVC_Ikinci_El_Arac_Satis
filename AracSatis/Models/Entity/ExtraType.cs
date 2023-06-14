namespace AracSatis.Models.Entity
{
    public class ExtraType : BaseEntity
    {
        public string Name { get; set; }

        //Relations
        public ICollection<Extra> Extras { get; set; } = new HashSet<Extra>();
    }
}
