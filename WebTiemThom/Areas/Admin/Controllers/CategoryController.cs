using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EntityFramework;

namespace WebTiemThom.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        //
        // GET: /Admin/Category/
        public ActionResult Index()
        {
            var model = (new CategoryDAO()).ListAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(category model)
        {
            if (ModelState.IsValid)
            {
                model.create_at = DateTime.Now;
                var id = new CategoryDAO().Insert(model);
                if (id > 0)
                {
                    TempData["SuccessMessage"] = "Category created successfully!";
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
        public ActionResult Update()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Update(category model)
        {
            if (ModelState.IsValid)
            {
                int result = (new CategoryDAO()).UpdateCategory(model);
                if (result == -1)
                {
                    ModelState.AddModelError("", "Update category failed!");
                }
                else if (result == 1)
                {
                    TempData["SuccessMessage"] = "Category updated successfully!";
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

            SetViewBag(model.id);
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
                TempData["SuccessMessage"] = "Category deleted successfully!";
                return RedirectToAction("Index");
            }
            else if (result == -1)
            {
                ModelState.AddModelError("", "Category not found!");
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
            SetViewBag();
            return View();
        }

        public void SetViewBag(int? selectedId = null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "id", "name", selectedId);
        }
    }
}