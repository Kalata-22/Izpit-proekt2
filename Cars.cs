using System.Linq;
//using CRUD_Operations.Models;
using Microsoft.AspNetCore.Mvc;
namespace AdminPanelTutorial
{
    public class CarsController : Controller
        
    {
       // MyDbContext db = new MyDbContext();

        public ActionResult Index()
        {
            return View(db.Cars.ToList()); 
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCars(Cars cars)
        {
            db.Cars.Add(cars);
            db.SaveChanges();
            return RedirectToAction("Index", "Cars");
        }
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Cars cars = db.Cars.Where(s => s.Id == id).First();
                db.Cars.Remove(cars);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }
        public ActionResult Update(int id)
        {
            return View(db.Cars.Where(s => s.Id == id).First());
        }
        [HttpPost]
        public ActionResult UpdateCars(Cars cars)
        {
            Cars d = db.Cars.Where(s => s.Id == cars.Id).First();
            d.Name = cars.Name;
            d.DateOfCreation = cars.DateOfCreation;
            d.EngineType = cars.EngineType;
            d.HorsePower = cars.HorsePower;
            d.Transmission = cars.Transmission ;
            d.Category = cars.Category;
            d.Mileage = cars.Mileage;
            d.Color = cars.Color;

            db.SaveChanges();
            return RedirectToAction("Index", "Cars");
        }
    }
}