namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        public user()
        {
            orders = new HashSet<order>();
            shopping_cart = new HashSet<shopping_cart>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string first_name { get; set; }

        [StringLength(50)]
        public string last_name { get; set; }

        [StringLength(350)]
        public string address { get; set; }

        [StringLength(150)]
        public string email { get; set; }

        [StringLength(11)]
        public string telephone { get; set; }

        public bool status { get; set; }

        public int? role_id { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? modified_at { get; set; }

        public virtual ICollection<order> orders { get; set; }

        public virtual ICollection<shopping_cart> shopping_cart { get; set; }

        public virtual user_role user_role { get; set; }
    }
}
