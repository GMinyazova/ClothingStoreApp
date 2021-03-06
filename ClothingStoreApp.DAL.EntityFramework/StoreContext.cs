namespace ClothingStoreApp.DAL.EntityFramework
{
    using System.Data.Entity;

    public class StoreContext : DbContext
    {
        public StoreContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<TypeOfProduct> TypesOfProduct { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.VendorCode)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(7, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Material)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TypeOfProduct>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TypeOfProduct>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.TypeOfProduct)
                .WillCascadeOnDelete(false);
        }
    }
}
