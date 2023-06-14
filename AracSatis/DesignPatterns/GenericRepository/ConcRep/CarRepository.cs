using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.BaseRep;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;

namespace AracSatis.DesignPatterns.GenericRepository.ConcRep
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext db) : base(db)
        {
        }
    }
}
