using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.BaseRep;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;

namespace AracSatis.DesignPatterns.GenericRepository.ConcRep
{
    public class FuelTypeRepository : BaseRepository<FuelType>, IFuelTypeRepository
    {
        public FuelTypeRepository(AppDbContext db) : base(db)
        {
        }
    }
}
