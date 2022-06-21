using Restaurant.Areas.Admin.Infrastructure;
using Restaurant.DAL;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Restaurant.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private FoodDbContext _context;

        public DashboardController()
        {
            _context = new FoodDbContext();
        }
        [CustomAuthorize("SuperAdmin", "Admin")]
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthorize("SuperAdmin", "Admin")]
        public ActionResult Food()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetFood(string searchname, int page, int pageSize = 2)
        {
            IQueryable<Food> model = _context.Foods;
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
        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var food = _context.Foods.Find(id);
            return Json(new { data = food, status = true }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveData(string str/*, HttpPostedFileBase file*/)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Food food = serializer.Deserialize<Food>(str);
            bool status = false;
            string message = string.Empty;
            //add new if id = 0
            if (food.FoodID == 0)
            {
                //string pic = null;
                //string path = null;
                //if (file != null)
                //{
                //    pic = System.IO.Path.GetFileName(file.FileName);
                //    path = System.IO.Path.Combine(Server.MapPath("~/Images/FoodImg/"), pic);
                //    file.SaveAs(path);
                //}
                //food.Image = pic;
                _context.Foods.Add(food);
                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            }
            //update existing DB
            else
            {
                var entity = _context.Foods.Find(food.FoodID);
                entity.FoodName = food.FoodName;
                entity.CateId = food.CateId;
                entity.Description = food.Description;
                entity.Price = food.Price;
                entity.PriceDiscount = food.PriceDiscount;
                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            }
            return Json(new { status = status, message = message });
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var food = _context.Foods.Find(id);
            _context.Foods.Remove(food);
            try
            {
                _context.SaveChanges();
                return Json(new { status = true });
            }
            catch (Exception e)
            {
                return Json(new { status = false, message = e.Message });
            }
        }
        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "Un Authorized Page!";

            return View();
        }
        [ChildActionOnly]
        public PartialViewResult PartialNavbar()
        {    
            return PartialView("_PartialNavbar");
        }
        [ChildActionOnly]
        public PartialViewResult PartialSideNavbar()
        {
            return PartialView("_PartialSideNavbar");
        }
        [ChildActionOnly]
        public PartialViewResult PartialFooter()
        {
            return PartialView("_PartialFooter");
        }
    }
}