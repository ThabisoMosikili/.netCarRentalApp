using CarRental.Data;
using Microsoft.AspNetCore.Mvc;
using CarRental.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using System.Reflection;
using CarRental.Data.DataAccess;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {

        private readonly IRepositoryWrapper _repositoryWrapper;
        public CarController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public IActionResult Cars(string sortBy = "name" )
        {
            IEnumerable<Car> cars;
            Expression<Func<Car, Object>> orderBy;
            string orderByDirection;

            ViewData["NameSortParam"] = sortBy == "Name" ? "Name_desc" : "Name";
            ViewData["CarTypeSortParam"] = sortBy == "Price" ? "Price_desc" : "Price";

            if (sortBy.EndsWith("_desc"))
            {
                sortBy = sortBy.Substring(0, sortBy.Length - 5);
                orderByDirection = "desc";
            }
            else
            {
                orderByDirection = "asc";
            }

            orderBy = p => EF.Property<object>(p, sortBy);
            cars = _repositoryWrapper.Car.GetCarsWithCarTypeQueryOptions(new CarQueryOptions<Car>
            {
                OrderBy = orderBy,
                OrderByDirection = orderByDirection
            });

           
            return View(cars);
        }
        public IActionResult Details(int id)
        {
            var Car = _repositoryWrapper.Car.GetById(id);
            if (Car != null)
            {
                return View(Car);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult Add()
        {
            PopulateCarTypeDLL();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Car car)
        {
            car.PickUpDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _repositoryWrapper.Car.Add(car);
                TempData["Message"] = $"{car.Name} information has been added";
                _repositoryWrapper.Save();
                return RedirectToAction("Cars");
            }
            else
            {
                PopulateCarTypeDLL();
                return View(car);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var car = _repositoryWrapper.Car.GetById(id);
            PopulateCarTypeDLL(car.CarTypeId);
            return View(car);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repositoryWrapper.Car.Update(car);
                    TempData["Message"] = $"{car.Name} information has been updated";
                    _repositoryWrapper.Save();
                    return RedirectToAction("Cars");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            PopulateCarTypeDLL(car.CarTypeId);
            return View(car);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_repositoryWrapper.Car.GetById(id));
        }
        [HttpPost]
        public IActionResult Delete(Car car)
        {
            if (car != null)
            {
                try
                {
                    _repositoryWrapper.Car.Delete(car);
                    TempData["Message"] = $"Car information has been removed";
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to delete movie. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                _repositoryWrapper.Save();
                return RedirectToAction("Cars");
            }
            else
            {
                return View(car);
            }
        }
        private void PopulateCarTypeDLL(object selectedCarType = null)
        {
            ViewBag.CarType = new SelectList(_repositoryWrapper.CarType.FindAll()
                .OrderBy(g => g.CarTypeName),
                "CarTypeId", "CarTypeName", selectedCarType);
        }
    }
}
