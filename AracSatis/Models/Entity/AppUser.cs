using Microsoft.AspNetCore.Identity;

namespace AracSatis.Models.Entity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Relations
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
