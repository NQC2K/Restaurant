using Restaurant.DAL;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Restaurant.Controllers
{
    public class CartController : Controller
    {
        private FoodDbContext _context;

        public CartController()
        {
            _context = new FoodDbContext();
        }
        // GET: CartItem
        public ActionResult Index()
        {
            var cart = Session[SessionValue.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem( int foodid, int quantity)
        {
            var food = _context.Foods.Find(foodid);
            var cart = Session[SessionValue.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Food.FoodID == foodid))
                {
                    foreach (var item in list)
                    {
                        if (item.Food.FoodID == foodid)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Food = food;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[SessionValue.CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Food = food;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[SessionValue.CartSession] = list;
            }
            return RedirectToAction("../Home/Index");
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[SessionValue.CartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Food.FoodID == item.Food.FoodID);
                if(jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[SessionValue.CartSession] = sessionCart;
            return Json(new { status = true });
        }
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[SessionValue.CartSession];
            sessionCart.RemoveAll(x => x.Food.FoodID == id);
            Session[SessionValue.CartSession] = sessionCart;
            return Json(new { status = true });
        }
        public ActionResult Payment()
        {
            var cart = Session[SessionValue.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string ShipName, string ShipPhoneNumber, string ShipAddress, string ShipEmail, double Total)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipName = ShipName;
            order.ShipPhoneNumber = ShipPhoneNumber; 
            order.ShipAddress = ShipAddress;
            order.ShipEmail = ShipEmail;
            order.Total = Total;
            _context.Orders.Add(order);
            _context.SaveChanges();
            var id = order.OrderID;
            try
            {
                var cart = (List<CartItem>)Session[SessionValue.CartSession];
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.FoodID = item.Food.FoodID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Food.PriceDiscount;
                    orderDetail.Quantity = item.Quantity;
                    _context.OrderDetails.Add(orderDetail);
                    _context.SaveChanges();
                }
                Session.Clear();
                return View("Success");
            }
            catch(Exception)
            {
                return View("Fail");
            }                 
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}