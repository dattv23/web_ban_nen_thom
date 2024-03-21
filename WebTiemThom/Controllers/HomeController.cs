using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using WebTiemThom.Models;

namespace WebTiemThom.Controllers
{
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult AllCategory()
        {
            var model = (new CategoryDAO()).ListAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult ProductInfo()
        {
            ViewBag.products = (new ProductDAO()).ListAll();
            ViewBag.categorys = (new CategoryDAO()).ListAll();
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult HotItem()
        {
            ViewBag.products = (new ProductDAO()).ListAll();
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult HeaderCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }
    }
}