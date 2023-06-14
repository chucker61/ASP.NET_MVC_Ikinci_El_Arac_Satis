using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.BaseRep;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using System.Drawing;

namespace AracSatis.DesignPatterns.GenericRepository.ConcRep
{
    public class ImageRepository : BaseRepository<Models.Entity.Image>, IImageRepository
    {
        public ImageRepository(AppDbContext db) : base(db)
        {
        }
    }
}
