using Restaurant.DAL;
using Restaurant.Models;
using System.Linq;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private FoodDbContext _context;

        public HomeController()
        {
            _context = new FoodDbContext();
        }

        public ActionResult Index()
        {
            //FoodViewModel model = new FoodViewModel();
            //List<Food> Foods = new List<Food>();
            //Foods = GetFoods();
            var model = _context.Foods;
            return View(model);
        }

        public ActionResult FoodDetails(int id)
        {
            var model = _context.Foods.Where(p => p.FoodID == id).First();
            return View(model);
        }

        public ActionResult FoodCate()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetFood(/*int cateid,*/ string searchname, int page, int pageSize = 2)
        {
            //ViewBag.cateid = cateid;
            //List<Food> f = new List<Food>();
            IQueryable<Food> model = _context.Foods;
            /*if (cateid != 0)
            {
                model = model.OrderBy(p => p.FoodID).Where(p => p.CateId == cateid);
            }
            else
            {
                model = model.OrderBy(p => p.FoodID);
            }*/
            if (!string.IsNullOrEmpty(searchname))
                model = model.Where(x => x.FoodName.Contains(searchname));
            int totalRow = model.Count();
            if (totalRow > 0)
            {
                model = model.OrderBy(x => x.FoodID).Skip((page - 1) * pageSize).Take(pageSize);
                return Json(new { data = model, total = totalRow, status = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = model, total = totalRow, status = false }, JsonRequestBehavior.AllowGet);
            }
        }

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