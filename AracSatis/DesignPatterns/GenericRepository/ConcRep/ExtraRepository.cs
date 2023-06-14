using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.BaseRep;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;

namespace AracSatis.DesignPatterns.GenericRepository.ConcRep
{
    public class ExtraRepository : BaseRepository<Extra> , IExtraRepository
    {
        public ExtraRepository(AppDbContext db) : base(db)
        {
        }
    }
}
