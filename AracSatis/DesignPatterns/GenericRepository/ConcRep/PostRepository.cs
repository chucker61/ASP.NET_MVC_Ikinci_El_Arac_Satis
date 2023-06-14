using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.BaseRep;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;
using Microsoft.Identity.Client;

namespace AracSatis.DesignPatterns.GenericRepository.ConcRep
{
    public class PostRepository : BaseRepository<Post> , IPostRepository
    {
        AppDbContext _db;
        public PostRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public List<Post> GetApproved()
        {
            return Where(x => x.isPublic && !x.isDeleted);
        }
        public void ChangeVisibility(Post item)
        {
            if(item.isPublic == false)
                item.isPublic = true;
            else
                item.isPublic = false;
            _db.SaveChanges();
        }
    }
}
