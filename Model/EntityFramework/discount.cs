namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("discount")]
    public partial class discount
    {
        public discount()
        {
            products = new HashSet<product>();
        }

        public int id { get; set; }

        [StringLength(150)]
        public string name { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public int? discount_percent { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? modified_at { get; set; }

        public virtual ICollection<product> products { get; set; }
    }
}
