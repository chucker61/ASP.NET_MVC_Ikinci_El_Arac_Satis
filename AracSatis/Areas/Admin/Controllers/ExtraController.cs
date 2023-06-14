using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;
using AracSatis.Models.ViewModels.Extras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AracSatis.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExtraController : Controller
    {
        private readonly IExtraRepository _extraRepo;
        private readonly IExtraTypeRepository _typeRepo;
        public ExtraController(IExtraRepository extraRepo, IExtraTypeRepository typeRepo)
        {
            _extraRepo = extraRepo;
            _typeRepo = typeRepo;
        }
        public IActionResult GetAll()
        {
            ExtraVM viewModel = new ExtraVM();
            viewModel.Extras = _extraRepo.GetActives();
            viewModel.ExtraTypes = _typeRepo.GetAll();
            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ExtraVM viewModel)
        {
            Extra extra = new Extra()
            {
                Name = viewModel.Name,
                ExtraTypeId = viewModel.TypeId
            };
            _extraRepo.Add(extra);
            return RedirectToAction("GetAll");
        }
        public ActionResult Delete(int id)
        {
            Extra toBeDeleted = _extraRepo.Find(id);
            if (toBeDeleted == null)
            {
                return View("Error");
            }
            ExtraVM viewModel = new ExtraVM()
            {
                Id = toBeDeleted.Id,
                Name = toBeDeleted.Name,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(ExtraVM viewModel)
        {
            Extra toBeDeleted = _extraRepo.Find(viewModel.Id);
            _extraRepo.Delete(toBeDeleted);
            return RedirectToAction("GetAll");
        }
        public IActionResult Update(int id)
        {
            Extra toBeUpdated = _extraRepo.Find(id);
            if (toBeUpdated == null)
            {
                return View("Error");
            }
            ExtraVM viewModel = new ExtraVM()
            {
                Name = toBeUpdated.Name,
                Id = toBeUpdated.Id
            };
            viewModel.ExtraTypes = _typeRepo.GetActives();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(ExtraVM viewModel)
        {
            Extra toBeUpdated = _extraRepo.Find(viewModel.Id);
            toBeUpdated.Name = viewModel.Name;
            toBeUpdated.ExtraTypeId = viewModel.TypeId;
            _extraRepo.Update(toBeUpdated);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetDeleteds()
        {
            ExtraVM viewModel = new ExtraVM();
            viewModel.Extras = _extraRepo.GetDeleteds();
            return View(viewModel);
        }
        public IActionResult Remove(int id)
        {
            Extra toBeRemove = _extraRepo.Find(id);
            if (toBeRemove == null)
            {
                return View("Error");
            }
            ExtraVM viewModel = new ExtraVM()
            {
                Id = toBeRemove.Id,
                Name = toBeRemove.Name,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Remove(ExtraVM viewModel)
        {
            Extra toBeRemove = _extraRepo.Find(viewModel.Id);
            _extraRepo.Destory(toBeRemove);
            return RedirectToAction("GetDeleteds");
        }
        public IActionResult Recover(int id)
        {
            Extra toBeRecover = _extraRepo.Find(id);
            if (toBeRecover == null)
            {
                return View("Error");
            }
            ExtraVM viewModel = new ExtraVM()
            {
                Name = toBeRecover.Name,
                Id = toBeRecover.Id,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Recover(Extra viewModel)
        {
            Extra toBeRecover = _extraRepo.Find(viewModel.Id);
            _extraRepo.Recover(toBeRecover);
            return RedirectToAction("GetDeleteds");
        }
    }
}
