using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private List<Food> foods = new List<Food>()
        {
            new Food
            {
                FoodID = 1,
                FoodName = "Mandu",
                CateId = 1,
                Description = "Updating...",
                Price = 30000,
                Image = "food-1.png"
            },
            new Food
                {
                FoodID = 2,
                FoodName = "Hamburger",
                CateId = 2,
                Description = "Updating...",
                Price = 30000,
                Image = "food-2.png"    
                },
            new Food
            {
                FoodID = 3,
                FoodName = "Pizza",
                CateId = 3,
                Description = "Updating...",
                Price = 30000,
                Image = "food-3.png"
            },
            new Food
            {
                FoodID = 4,
                FoodName = "Hamburger",
                CateId = 2,
                Description = "Updating...",
                Price = 30000,
                Image = "food-4.png"
            },
            new Food
            {
                FoodID = 5,
                FoodName = "Pizza",
                CateId = 3,
                Description = "Updating...",
                Price = 30000,
                Image = "food-5.png"
            },
            new Food
            {
                FoodID = 6,
                FoodName = "Hamburger",
                CateId = 2,
                Description = "Updating...",
                Price = 30000,
                Image = "food-7.png"
            },
            new Food
            {
                FoodID = 7,
                FoodName = "Hamburger",
                CateId = 2,
                Description = "Updating...",
                Price = 30000,
                Image = "food-2.png"
            },
            new Food
            {
                FoodID = 8,
                FoodName = "Pizza",
                CateId = 3,
                Description = "Updating...",
                Price = 30000,
                Image = "food-6.png"
            },
            new Food
            {
                FoodID = 9,
                FoodName = "Pizza",
                CateId = 3,
                Description = "Updating...",
                Price = 30000,
                Image = "food-8.png"
            },
            new Food
            {
                FoodID = 10,
                FoodName = "Mandu",
                CateId = 1,
                Description = "Updating...",
                Price = 30000,
                Image = "food-1.png"
            }
        };

        public ActionResult Index()
        {
            //FoodViewModel model = new FoodViewModel();
            //List<Food> Foods = new List<Food>();
            //Foods = GetFoods();
            return View(foods);
        }

        public ActionResult FoodDetails(int? id)
        {
            if (id != null)
            {
                Food f = foods.Where(p => p.FoodID == id).First();
                return View(f);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult FoodCate()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetFood(/*int cateid,*/ int page, int pageSize = 2)
        {
            //ViewBag.cateid = cateid;
            //List<Food> f = new List<Food>();
            //if (cateid != 0)
            //{
            //    f = foods.OrderBy(p => p.FoodID).Where(p => p.CateId == cateid).ToList();
            //}
            //else
            //{

            //f = foods.OrderBy(p => p.FoodID).ToList();
            //}
            var model = foods.OrderBy(p => p.FoodID).Skip((page - 1) * pageSize).Take(pageSize);
            int totalRow = foods.Count();
            return Json(new { data = model, total = totalRow, status = true }, JsonRequestBehavior.AllowGet);
            //return View(foods);
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
        }

        //private List<Food> GetFoods()
        //{
        //    return foods;
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}