using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.BaseRep;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;

namespace AracSatis.DesignPatterns.GenericRepository.ConcRep
{
    public class ExtraTypeRepository : BaseRepository<ExtraType> , IExtraTypeRepository
    {
        public ExtraTypeRepository(AppDbContext db) : base(db)
        {

        }
    }
}
