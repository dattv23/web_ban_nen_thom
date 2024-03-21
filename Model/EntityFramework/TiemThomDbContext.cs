namespace Model.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TiemThomDbContext : DbContext
    {
        public TiemThomDbContext()
            : base("name=TiemThomDbContext")
        {
        }

        public virtual DbSet<cart_items> cart_items { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<discount> discounts { get; set; }
        public virtual DbSet<order_items> order_items { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<shopping_cart> shopping_cart { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<user_role> user_role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithOptional(e => e.category)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<discount>()
                .HasMany(e => e.products)
                .WithOptional(e => e.discount)
                .HasForeignKey(e => e.discount_id);

            modelBuilder.Entity<order_items>()
                .Property(e => e.pricre_at_purchase)
                .HasPrecision(18, 0);

            modelBuilder.Entity<order>()
                .Property(e => e.ship_email)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.ship_phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.payment_method)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.order_status)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.total_cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_items)
                .WithOptional(e => e.order)
                .HasForeignKey(e => e.order_id);

            modelBuilder.Entity<product>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<product>()
                .HasMany(e => e.cart_items)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<product>()
                .HasMany(e => e.order_items)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<shopping_cart>()
                .HasMany(e => e.cart_items)
                .WithOptional(e => e.shopping_cart)
                .HasForeignKey(e => e.cart_id);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.telephone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.shopping_cart)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user_role>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .HasMany(e => e.users)
                .WithOptional(e => e.user_role)
                .HasForeignKey(e => e.role_id);
        }
    }
}
