using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EntityFramework;

namespace WebTiemThom.Models
{
    [Serializable]
    public class CartItem
    {
        public product Product { set; get; }
        public int Quantity { set; get; }
    }
}