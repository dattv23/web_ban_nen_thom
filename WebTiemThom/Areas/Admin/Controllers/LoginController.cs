using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTiemThom.Areas.Admin.Models;
using Model.DAO;
using WebTiemThom.Common;

namespace WebTiemThom.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDAO();
                var result = dao.Login(model.UserName, model.Password, true);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.username;
                    userSession.UserID = user.id;
                    if (user.role_id == 1)
                    {
                        userSession.Role = "admin";
                    }
                    else if (user.role_id == 2)
                    {
                        userSession.Role = "customer";
                    }
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Account does not exist.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Account is locked.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Incorrect password.");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Your account does not have login permissions.");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login.");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null; // Clear user session
            return RedirectToAction("Index", "Login");
        }
    }
}