using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EntityFramework;
using Model.DAO;

namespace WebTiemThom.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private TiemThomDbContext db = new TiemThomDbContext();

        // GET: /Admin/Product/
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.category).Include(p => p.discount);
            return View(products.ToList());
        }

        // GET: /Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.categories, "id", "name");
            ViewBag.discount_id = new SelectList(db.discounts, "id", "name");
            return View();
        }

        // POST: /Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(product model)
        {
            if (ModelState.IsValid)
            {
                model.create_at = DateTime.Now;
                var dao = new ProductDAO();
                var id = dao.Insert(model);
                if (id > 0)
                {
                    TempData["SuccessMessage"] = "Product created successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Add category failed!");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            ViewBag.product_id = new SelectList(db.products, "id", "name");
            ViewBag.category_id = new SelectList(db.categories, "id", "name");
            ViewBag.discount_id = new SelectList(db.discounts, "id", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Edit(product model)
        {
            if (ModelState.IsValid)
            {
                int result = (new ProductDAO()).UpdateProduct(model);
                if (result == -1)
                {
                    ModelState.AddModelError("", "Edit product failed!");
                }
                else if (result == 1)
                {
                    TempData["SuccessMessage"] = "Product edited successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Server error!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please check the information again!");
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var dao = new CategoryDAO();
            int result = dao.DeleteCategory(id);

            if (result == 1)
            {
                TempData["SuccessMessage"] = "Product deleted successfully!";
                return RedirectToAction("Index");
            }
            else if (result == -1)
            {
                ModelState.AddModelError("", "Product not found!");
            }
            else
            {
                ModelState.AddModelError("", "Error deleting category!");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            ViewBag.product_id = new SelectList(db.products, "id", "name");
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
