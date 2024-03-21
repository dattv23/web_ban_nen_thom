using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTiemThom.Common;
using Model.DAO;

namespace WebTiemThom.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            var userSession = (UserLogin)Session[CommonConstants.USER_SESSION];
            var dao = new userDAO();
            var user = dao.ViewDetail(userSession.UserID);
            ViewBag.NameUser = user.first_name + " " + user.last_name; 
            return View();
        }
	}
}