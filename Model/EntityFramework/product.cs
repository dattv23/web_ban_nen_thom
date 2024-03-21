namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        public product()
        {
            cart_items = new HashSet<cart_items>();
            order_items = new HashSet<order_items>();
        }

        public int id { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public decimal? price { get; set; }

        [StringLength(250)]
        public string image { get; set; }

        public int? category_id { get; set; }

        public int? discount_id { get; set; }

        public int? quantity { get; set; }

        public bool status { get; set; }

        public DateTime? create_at { get; set; }

        public DateTime? modified_at { get; set; }

        public virtual ICollection<cart_items> cart_items { get; set; }

        public virtual category category { get; set; }

        public virtual discount discount { get; set; }

        public virtual ICollection<order_items> order_items { get; set; }
    }
}
