using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.BaseRep;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;

namespace AracSatis.DesignPatterns.GenericRepository.ConcRep
{
    public class CarExtraRepository : BaseRepository<CarExtra>, ICarExtraRepository
    {
        public CarExtraRepository(AppDbContext db) : base(db)
        {
        }
    }
}
