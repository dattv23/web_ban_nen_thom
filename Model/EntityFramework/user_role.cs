namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_role
    {
        public user_role()
        {
            users = new HashSet<user>();
        }

        public int id { get; set; }

        [StringLength(10)]
        public string name { get; set; }

        public virtual ICollection<user> users { get; set; }
    }
}
