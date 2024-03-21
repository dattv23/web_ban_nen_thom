namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cart_items
    {
        public int id { get; set; }

        public int? cart_id { get; set; }

        public int? product_id { get; set; }

        public int? quantity { get; set; }

        public virtual product product { get; set; }

        public virtual shopping_cart shopping_cart { get; set; }
    }
}
