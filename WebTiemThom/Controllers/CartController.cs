using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTiemThom.Models;
using Model.EntityFramework;
using Model.DAO;
using System.Web.Script.Serialization;
using System.Configuration;
using WebTiemThom.Common;

namespace WebTiemThom.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int productId, int quantity)
        {
            var product = new ProductDAO().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.id == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.id == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.id == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.id == item.Product.id);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult Checkout()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Checkout(string shipName, string mobile, string address, string email)
        {
            var order = new order();
            order.create_at = DateTime.Now;
            order.ship_address = address;
            order.ship_phone = mobile;
            order.ship_name = shipName;
            order.ship_email = email;

            try
            {
                var id = new OrderDAO().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new Model.DAO.OrderDetailDAO();
                long total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new order_items();
                    orderDetail.product_id = item.Product.id;
                    orderDetail.order_id = id;
                    orderDetail.pricre_at_purchase = item.Product.price;
                    orderDetail.quantity = item.Quantity;
                    detailDao.Insert(orderDetail);

                    total += ((int)item.Product.price.GetValueOrDefault(0) * item.Quantity);
                }

                var res = new OrderDAO().UpdateTotalCost(id, total);
                string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Address}}", address);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                //new MailHelper().SendMail(email, "New order from OnlineShop", content);
                //new MailHelper().SendMail(toEmail, "New order from OnlineShop", content);
            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("/error");
            }
            return Redirect("/successed");
        }
        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
	}
}