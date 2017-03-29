namespace Data
{
    using Migrations;
    using Models;
    using System.Data.Entity;

    public class ProductsShopContext : DbContext
    {
        public ProductsShopContext()
            : base("name=ProductsShopContext")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasMany(u => u.Friends)
              .WithMany()
              .Map(m =>
              {
                  m.ToTable("UserFriends");
                  m.MapLeftKey("UserId");
                  m.MapRightKey("FriendId");
              });

        }
    }
}