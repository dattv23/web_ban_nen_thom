using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;

namespace Model.DAO
{
    public class OrderDAO
    {
        TiemThomDbContext db = null;
        public OrderDAO()
        {
            db = new TiemThomDbContext();
        }
        public int Insert(order order)
        {
            db.orders.Add(order);
            db.SaveChanges();
            return order.id;
        }
        public bool UpdateTotalCost(int id, long price)
        {
            var order = db.orders.Find(id);
            order.total_cost = price;
            db.SaveChanges();
            return true;
        }
    }
}
