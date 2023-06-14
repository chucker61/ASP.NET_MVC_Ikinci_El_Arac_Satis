using AracSatis.Models.Entity;

namespace AracSatis.Models.ViewModels.Extras
{
    public class ExtraVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public List<Extra> Extras { get; set; }
        public List<ExtraType>? ExtraTypes { get; set; }
    }
}
