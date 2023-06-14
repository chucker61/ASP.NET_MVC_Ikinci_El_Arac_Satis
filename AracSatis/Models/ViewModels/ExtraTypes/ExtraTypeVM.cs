using AracSatis.Models.Entity;
using System.Reflection.Metadata.Ecma335;

namespace AracSatis.Models.ViewModels.ExtraTypes
{
    public class ExtraTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExtraType> extraTypes { get; set; }
    }
}
