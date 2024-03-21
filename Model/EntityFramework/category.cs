namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("category")]
    public partial class category
    {
        public category()
        {
            products = new HashSet<product>();
        }

        public int id { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        public int? parent_id { get; set; }

        public int? order { get; set; }

        public DateTime? create_at { get; set; }

        public bool? status { get; set; }

        public DateTime? modified_at { get; set; }

        public virtual ICollection<product> products { get; set; }
    }
}
