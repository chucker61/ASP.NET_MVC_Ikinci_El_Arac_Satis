using AracSatis.Models.Entity;
using AracSatis.Models.ViewModels.Posts;

namespace AracSatis.DesignPatterns.GenericRepository.IntRep
{
    public interface IPostRepository : IRepository<Post>
    {
        List<Post> GetApproved();
        void ChangeVisibility(Post item);
    }
}
