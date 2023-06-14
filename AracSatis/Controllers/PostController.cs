using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.Models.Entity;
using AracSatis.Models.ViewModels.Categories;
using AracSatis.Models.ViewModels.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using System.Linq;
using System.Reflection;

namespace AracSatis.Controllers
{
    public class PostController : Controller
    {
        AppDbContext _db;
        IPostRepository _postRepo;
        ICarRepository _carRepo;
        ICategoryRepository _categoryRepo;
        IExtraRepository _extraRepo;
        ITransmissionTypeRepository _transmissionRepo;
        IFuelTypeRepository _fuelRepo;
        IImageRepository _imageRepo;
        ICarExtraRepository _carExtraRepo;
        UserManager<AppUser> _userManager;

        public PostController(AppDbContext db, IPostRepository postRepo, ICarRepository carRepo,ICategoryRepository categoryRepo, IExtraRepository extraRepo, ITransmissionTypeRepository transmissionRepo, IFuelTypeRepository fuelRepo, IImageRepository imageRepo, ICarExtraRepository carExtraRepo, UserManager<AppUser> userManager)
        {
            _db = db;
            _postRepo = postRepo;
            _carRepo = carRepo;
            _categoryRepo = categoryRepo;
            _extraRepo = extraRepo;
            _transmissionRepo = transmissionRepo;
            _fuelRepo = fuelRepo;
            _imageRepo = imageRepo;
            _carExtraRepo = carExtraRepo;
            _userManager = userManager;
        }
        public IActionResult GetAll()
        {
            PostVM viewModel = new PostVM();
            viewModel.Posts = _postRepo.GetApproved();

            return View(viewModel);
        }
        [Authorize]
        public IActionResult Create()
        {
            CreatePostVM viewModel = new CreatePostVM();
            viewModel.Categories = _categoryRepo.GetActives();
            viewModel.TransmissionTypes = _transmissionRepo.GetActives();
            viewModel.FuelTypes = _fuelRepo.GetActives();
            viewModel.Extras = _extraRepo.GetActives();
            viewModel.ExtraTypes = _db.ExtraTypes.Where(x => x.isDeleted==false).ToList();

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(CreatePostVM viewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                string uniqueFileName = "";

                Car car = new Car
                {
                    Make = viewModel.Make,
                    Model = viewModel.Model,
                    Year = viewModel.Year,
                    Kilometer = viewModel.Kilometer,
                    HorsePower = viewModel.HorsePower,
                    LocationCountry = viewModel.LocationCountry,
                    LocationCity = viewModel.LocationCity,
                    CategoryId = viewModel.CategoryId,
                    FuelTypeId = viewModel.FuelTypeId,
                    TransmissionTypeId = viewModel.TransmissionTypeId
                };

                if (viewModel.SelectedImages != null && viewModel.SelectedImages.Count > 0)
                {
                    foreach (var file in viewModel.SelectedImages)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var fileExtension = Path.GetExtension(fileName);
                        uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        car.Images.Add(new Image()
                        {
                            Path = "/images/" + uniqueFileName,
                            Car = car,
                        });
                    }

                }

                if (viewModel.SelectedExtras != null && viewModel.SelectedExtras.Count > 0)
                {
                    foreach (var extraId in viewModel.SelectedExtras)
                    {
                        var extra = _extraRepo.FirstOrDefault(x => x.Id == extraId);
                        car.CarExtras.Add(new CarExtra()
                        {
                            Extra = extra,
                            Car = car
                        });
                    }
                }

                Post post = new Post()
                {
                    Car = car,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Price = viewModel.Price,
                    CoverImage = "/images/" + uniqueFileName,
                    CreatorId = userId,
                };

                _postRepo.Add(post);
                return RedirectToAction("GetMine");
            }

            viewModel.Categories = _categoryRepo.GetActives();
            viewModel.FuelTypes = _fuelRepo.GetActives();
            viewModel.TransmissionTypes = _transmissionRepo.GetActives();
            viewModel.ExtraTypes = _db.ExtraTypes.Where(x => x.isDeleted == false).ToList();
            viewModel.Extras = _extraRepo.GetActives();

            return View(viewModel);
        }

        [Authorize]
        public IActionResult GetMine()
        {
            string userId = _userManager.GetUserId(User);
            PostVM viewModel = new PostVM();
            viewModel.Posts = _postRepo.Where(x => x.CreatorId == userId && x.isDeleted==false);
            return View(viewModel);
        }
        [Authorize]
        public IActionResult Update(int id)
        {
            Post toBeUpdatedPost = _postRepo.Find(id);
            if (_userManager.GetUserId(User) != toBeUpdatedPost.CreatorId && !User.IsInRole("Admin"))
            {
                return Unauthorized();
            }

            Car toBeUpdatedCar = _db.Cars.Find(toBeUpdatedPost.CarId);

            if (toBeUpdatedPost == null || toBeUpdatedCar == null)
            {
                return View("Error");
            }
            UpdatePostVM viewModel = new UpdatePostVM()
            {
                Id = toBeUpdatedPost.Id,
                Title = toBeUpdatedPost.Title,
                Description = toBeUpdatedPost.Description,
                Price = toBeUpdatedPost.Price,
                Make = toBeUpdatedCar.Make,
                Model = toBeUpdatedCar.Model,
                Year = toBeUpdatedCar.Year,
                Kilometer = toBeUpdatedCar.Kilometer,
                HorsePower = toBeUpdatedCar.HorsePower,
                LocationCountry = toBeUpdatedCar.LocationCountry,
                LocationCity = toBeUpdatedCar.LocationCity,
                Categories = _categoryRepo.GetActives(),
                TransmissionTypes = _transmissionRepo.GetActives(),
                FuelTypes = _fuelRepo.GetActives(),
            };

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Update(UpdatePostVM viewModel)
        {
            if (ModelState.IsValid)
            {
                Post toBeUpdatedPost = _postRepo.Find(viewModel.Id);
                Car toBeUpdatedCar = _db.Cars.Find(toBeUpdatedPost.CarId);

                toBeUpdatedPost.Title = viewModel.Title;
                toBeUpdatedPost.Description = viewModel.Description;
                toBeUpdatedPost.Price = viewModel.Price;
                toBeUpdatedPost.isPublic = false;
                toBeUpdatedCar.Make = viewModel.Make;
                toBeUpdatedCar.Model = viewModel.Model;
                toBeUpdatedCar.Year = viewModel.Year;
                toBeUpdatedCar.Kilometer = viewModel.Kilometer;
                toBeUpdatedCar.HorsePower = viewModel.HorsePower;
                toBeUpdatedCar.LocationCountry = viewModel.LocationCountry;
                toBeUpdatedCar.LocationCity = viewModel.LocationCity;
                toBeUpdatedCar.CategoryId = viewModel.CategoryId;
                toBeUpdatedCar.TransmissionTypeId = viewModel.TransmissionTypeId;
                toBeUpdatedCar.FuelTypeId = viewModel.FuelTypeId;

                _postRepo.Update(toBeUpdatedPost);

                return RedirectToAction("GetMine");
            }
            viewModel.Categories = _categoryRepo.GetActives();
            viewModel.FuelTypes = _fuelRepo.GetActives();
            viewModel.TransmissionTypes = _transmissionRepo.GetActives();

            return View(viewModel);
            
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            Post tobeDeleted = _postRepo.Find(id);
            if (tobeDeleted.CreatorId != _userManager.GetUserId(User) && !User.IsInRole("Admin"))
            {
                return Unauthorized();
            }
            if (tobeDeleted == null)
            {
                return View("Error");
            }
            DeletePostVM viewModel = new DeletePostVM()
            {
                Id = tobeDeleted.Id,
                Title = tobeDeleted.Title,
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(DeletePostVM viewModel)
        {
            Post toBeDeleted = _postRepo.Find(viewModel.Id);
            _postRepo.Delete(toBeDeleted);
            return RedirectToAction("GetMine");
        }

        public IActionResult Offer(int id)
        {
            Post post = _postRepo.Find(id);
            Car car = _carRepo.Find(post.CarId);
            Category category = _categoryRepo.Find(car.CategoryId);
            FuelType fuelType = _fuelRepo.Find(car.FuelTypeId);
            TransmissionType transmissionType = _transmissionRepo.Find(car.TransmissionTypeId);
            List<Image> images = _imageRepo.Where(x => x.CarId == car.Id).ToList();
            List<CarExtra> carExtras = _carExtraRepo.Where(x => x.CarId == car.Id).ToList();
            List<Extra> extras = new List<Extra>();
            foreach (var item in carExtras)
            {
                Extra extra = _extraRepo.Find(item.ExtraId);
                extras.Add(extra);
            }

            List<ExtraType> extraTypes = _db.ExtraTypes.Where(x => !x.isDeleted).ToList();
            
            OfferPostVM viewModel = new OfferPostVM()
            {
                Post = post,
                Car = car,
                Category = category,
                FuelType = fuelType,
                TransmissionType = transmissionType,
                Images = images,
                Extras = extras,
                ExtraTypes = extraTypes
            };
            return View(viewModel);
        }
       
        public IActionResult Search()
        {
            SearchPostVM viewModel = new SearchPostVM();
            viewModel.Categories = _categoryRepo.GetActives();
            viewModel.TransmissionTypes = _transmissionRepo.GetActives();
            viewModel.FuelTypes = _fuelRepo.GetActives();

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SearchResult(SearchPostVM viewModel)
        {

            var postsQuery = _postRepo.Where(x => x.isPublic && !x.isDeleted).AsQueryable();

            if (viewModel.minPrice > 0)
            {
                postsQuery.Where(x=>x.Price >= viewModel.minPrice);
            }
            
            if (viewModel.maxPrice > 0)
            {
                postsQuery.Where(x=>x.Price <= viewModel.maxPrice);
            }

            if (!string.IsNullOrWhiteSpace(viewModel.SearchTerm))
            {
                postsQuery = postsQuery.Where(x=>(x.Car.Make + " " + x.Car.Model).ToLower().Contains(viewModel.SearchTerm.ToLower()));
            }

            if(viewModel.minYear > 0)
            {
                postsQuery = postsQuery.Where(x =>x.Car.Year >= viewModel.minYear);
                
            }

            if (viewModel.maxYear > 0)
            {
                postsQuery = postsQuery.Where(x=>x.Car.Year <= viewModel.maxYear);
            }

            if (viewModel.minKilometer > 0)
            {
                postsQuery.Where(x=>x.Car.Kilometer == viewModel.minKilometer);
                int count = postsQuery.Count();
            }
            
            if(viewModel.maxKilometer > 0)
            {
                postsQuery.Where(x=>x.Car.Kilometer <= viewModel.maxKilometer);
            }


            List<Post> posts = postsQuery.ToList();

            return View(posts);
        }
        public IActionResult Compare (int postId1, int postId2)
        {
            Post post1 = _postRepo.Find(postId1);
            Post post2 = _postRepo.Find(postId2);
            Car car1 = _carRepo.Find(post1.CarId);
            Car car2 = _carRepo.Find(post2.CarId);
            if (post1 == null || post2 == null || car1 == null || car2 == null)
            {
                return View("Error");
            }
            ComparePostVM viewModel = new ComparePostVM()
            {
                Car1 = car1,
                Car2 = car2,
                Post1 = post1,
                Post2 = post2,
            };

            return View(viewModel);
        }
    }
 
}