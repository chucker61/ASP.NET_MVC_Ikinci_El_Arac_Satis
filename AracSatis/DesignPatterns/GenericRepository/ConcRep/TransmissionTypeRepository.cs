using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.BaseRep;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;

namespace AracSatis.DesignPatterns.GenericRepository.ConcRep
{
    public class TransmissionTypeRepository : BaseRepository<TransmissionType>, ITransmissionTypeRepository
    {
        public TransmissionTypeRepository(AppDbContext db) : base(db)
        {
        }
    }
}
