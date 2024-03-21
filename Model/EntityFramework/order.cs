namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order
    {
        public order()
        {
            order_items = new HashSet<order_items>();
        }

        public int id { get; set; }

        [StringLength(250)]
        public string ship_name { get; set; }

        [Column(TypeName = "ntext")]
        public string ship_address { get; set; }

        [StringLength(250)]
        public string ship_email { get; set; }

        [StringLength(11)]
        public string ship_phone { get; set; }

        public int? user_id { get; set; }

        [StringLength(30)]
        public string payment_method { get; set; }

        [StringLength(30)]
        public string order_status { get; set; }

        public DateTime? order_date { get; set; }

        public decimal? total_cost { get; set; }

        public DateTime? create_at { get; set; }

        public virtual ICollection<order_items> order_items { get; set; }

        public virtual user user { get; set; }
    }
}
