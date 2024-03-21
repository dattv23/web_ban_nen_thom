namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class shopping_cart
    {
        public shopping_cart()
        {
            cart_items = new HashSet<cart_items>();
        }

        public int id { get; set; }

        public int? user_id { get; set; }

        public DateTime? created_at { get; set; }

        public virtual ICollection<cart_items> cart_items { get; set; }

        public virtual user user { get; set; }
    }
}
