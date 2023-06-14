namespace AracSatis.Models.Entity
{
    public class Extra : BaseEntity
    {
        public string Name { get; set; }
        public int ExtraTypeId { get; set; }

        //Relations
        public ExtraType ExtraType { get; set; }
    }
}
