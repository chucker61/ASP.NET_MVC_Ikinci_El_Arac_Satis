using AracSatis.DesignPatterns.GenericRepository.ConcRep;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;
using AracSatis.Models.ViewModels.ExtraTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AracSatis.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExtraTypeController : Controller
    {
        private readonly IExtraTypeRepository _repo;
        public ExtraTypeController(IExtraTypeRepository repo)
        {
            _repo = repo;
        }

        public IActionResult GetAll()
        {
            ExtraTypeVM viewModel = new ExtraTypeVM();
            viewModel.extraTypes = _repo.GetActives();
            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ExtraTypeVM viewModel)
        {
            ExtraType extraType = new ExtraType()
            {
                Name = viewModel.Name,
            };
            _repo.Add(extraType);

            return RedirectToAction("GetAll");
        }
        public IActionResult Delete(int id)
        {
            ExtraType toBeDeleted = _repo.Find(id);
            if (toBeDeleted == null)
            {
                return View("Error");
            }
            ExtraTypeVM viewModel = new ExtraTypeVM()
            {
                Id = toBeDeleted.Id,
                Name = toBeDeleted.Name
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(ExtraTypeVM viewModel)
        {
            ExtraType toBeDeleted = _repo.Find(viewModel.Id);
            _repo.Delete(toBeDeleted);
            return RedirectToAction("GetAll");
        }
        public IActionResult Update(int id)
        {
            ExtraType toBeUpdated = _repo.Find(id);
            ExtraTypeVM viewModel = new ExtraTypeVM()
            {
                Name = toBeUpdated.Name,
                Id = toBeUpdated.Id,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(ExtraTypeVM viewModel)
        {
            ExtraType toBeUpdated = _repo.Find(viewModel.Id);
            toBeUpdated.Name = viewModel.Name;
            _repo.Update(toBeUpdated);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetDeleteds()
        {
            ExtraTypeVM viewModel = new ExtraTypeVM();
            viewModel.extraTypes = _repo.GetDeleteds();
            return View(viewModel);
        }
        public IActionResult Remove(int id)
        {
            ExtraType toBeRemoved = _repo.Find(id);
            if (toBeRemoved == null)
            {
                return View("Error");
            }
            ExtraTypeVM viewModel = new ExtraTypeVM()
            {
                Id = toBeRemoved.Id,
                Name = toBeRemoved.Name,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Remove(ExtraTypeVM viewModel)
        {
            ExtraType toBeRemoved = _repo.Find(viewModel.Id);
            _repo.Destory(toBeRemoved);
            return RedirectToAction("GetDeleteds");
        }
        public IActionResult Recover(int id)
        {
            ExtraType toBeRecover = _repo.Find(id);
            if (toBeRecover == null)
            {
                return View("Error");
            }
            ExtraTypeVM viewModel = new ExtraTypeVM()
            {
                Id = toBeRecover.Id,
                Name = toBeRecover.Name
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Recover(ExtraTypeVM viewModel)
        {
            ExtraType toBeRecover = _repo.Find(viewModel.Id);
            _repo.Recover(toBeRecover);

            return RedirectToAction("GetDeleteds");
        }
    }
}
