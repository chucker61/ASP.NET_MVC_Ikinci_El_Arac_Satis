using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.BaseRep;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;

namespace AracSatis.DesignPatterns.GenericRepository.ConcRep
{
    public class CategoryRepository : BaseRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(AppDbContext db) : base(db)
        {
        }
    }
}
