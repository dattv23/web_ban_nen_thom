using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;

namespace Model.DAO
{
    public class OrderDetailDAO
    {
        TiemThomDbContext db = null;
        public OrderDetailDAO()
        {
            db = new TiemThomDbContext();
        }
        public bool Insert(order_items detail)
        {
            try
            {
                db.order_items.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
