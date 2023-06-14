using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;
using AracSatis.Models.ViewModels.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AracSatis.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PostController : Controller
    {
        IPostRepository _postRepo;
        public PostController(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }
        public IActionResult All()
        {
            PostVM viewModel = new PostVM();
            viewModel.Posts = _postRepo.GetActives();
            return View(viewModel);
        }
        public IActionResult ChangeVisibility(int id)
        {
            Post toBePublic = _postRepo.Find(id);
            if (toBePublic == null)
            {
                return NotFound();
            }
            _postRepo.ChangeVisibility(toBePublic);
            return RedirectToAction("All");
        }
    }
}
