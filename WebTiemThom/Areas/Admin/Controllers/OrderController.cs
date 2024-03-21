using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EntityFramework;

namespace WebTiemThom.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private TiemThomDbContext db = new TiemThomDbContext();
        //
        // GET: /Admin/Order/
        public ActionResult Index()
        {
            var orders = db.orders.ToList();
            return View(orders);
        }
	}
}