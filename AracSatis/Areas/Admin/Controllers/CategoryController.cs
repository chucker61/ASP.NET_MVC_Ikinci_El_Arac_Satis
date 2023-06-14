using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;
using AracSatis.Models.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AracSatis.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public IActionResult GetAll()
        {
            CategoryVM viewModel = new CategoryVM();
            viewModel.Categories = _repo.GetActives();
            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryVM viewModel)
        {
            Category category = new Category()
            {
                Name = viewModel.Name
            };
            _repo.Add(category);
            return RedirectToAction("GetAll");
        }
        public IActionResult Update(int id)
        {
            Category toBeUpdated = _repo.Find(id);
            if (toBeUpdated == null)
            {
                return View("Error");
            }
            CategoryVM viewModel = new CategoryVM()
            {
                Id = toBeUpdated.Id,
                Name = toBeUpdated.Name
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(CategoryVM viewModel)
        {
            Category toBeUpdated = _repo.Find(viewModel.Id);
            toBeUpdated.Name = viewModel.Name;
            _repo.Update(toBeUpdated);
            return RedirectToAction("GetAll");
        }
        public IActionResult Delete(int id)
        {
            Category toBeDeleted = _repo.Find(id);
            if (toBeDeleted == null)
            {
                return View("Error");
            }
            CategoryVM viewModel = new CategoryVM()
            {
                Id = toBeDeleted.Id,
                Name = toBeDeleted.Name
            };

            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Delete(CategoryVM viewModel)
        {
            Category toBeDeleted = _repo.Find(viewModel.Id);
            _repo.Delete(toBeDeleted);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetDeleteds()
        {
            CategoryVM viewModel = new CategoryVM();
            viewModel.Categories = _repo.GetDeleteds();
            return View(viewModel);
        }
        public IActionResult Remove(int id)
        {
            Category toBeRemoved = _repo.Find(id);
            if (toBeRemoved == null)
            {
                return View("Error");
            }
            CategoryVM viewModel = new CategoryVM()
            {
                Id = toBeRemoved.Id,
                Name = toBeRemoved.Name
            };

            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Remove(CategoryVM viewModel)
        {
            Category toBeRemoved = _repo.Find(viewModel.Id);
            _repo.Destory(toBeRemoved);
            return RedirectToAction("GetDeleteds");
        }

        public IActionResult Recover(int id)
        {
            Category toBeRecover = _repo.Find(id);
            if (toBeRecover == null)
            {
                return View("Error");
            }
            CategoryVM viewModel = new CategoryVM()
            {
                Id = toBeRecover.Id,
                Name = toBeRecover.Name
            };

            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Recover(CategoryVM viewModel)
        {
            Category toBeRecover = _repo.Find(viewModel.Id);
            _repo.Recover(toBeRecover);
            return RedirectToAction("GetDeleteds");
        }


    }
}
