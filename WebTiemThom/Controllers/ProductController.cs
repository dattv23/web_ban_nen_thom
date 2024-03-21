using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace WebTiemThom.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            ViewBag.categories = (new CategoryDAO()).ListAll();
            ViewBag.products = (new ProductDAO()).ListAll();
            return View();
        }

        public ActionResult Category(int id)
        {
            ViewBag.categories = (new CategoryDAO()).ListAll();
            ViewBag.products = (new ProductDAO()).ListOfCategory(id);
            return View("Index");
        }
	}
}