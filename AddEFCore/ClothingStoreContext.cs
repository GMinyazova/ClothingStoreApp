using Microsoft.EntityFrameworkCore;

namespace AddEFCore
{
    public partial class ClothingStoreContext : DbContext
    {
        public ClothingStoreContext()
        {
        }

        public ClothingStoreContext(DbContextOptions<ClothingStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductInOrder> ProductInOrder { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<SizeOfProduct> SizeOfProduct { get; set; }
        public virtual DbSet<TypeOfProduct> TypesOfProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=W-MINYAZOVAGS\\SQLEXPRESS;Database=ClothingStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "InformationAboutOrder");

                entity.HasIndex(e => new { e.Surname, e.Name });

                entity.Property(e => e.DateOfCreating)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer", "ProductInformation");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfCreating)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "InformationAboutOrder");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderAcceptanceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentAmount).HasColumnType("numeric(7, 0)");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StatusChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalCost).HasColumnType("numeric(7, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "ProductInformation");

                entity.HasIndex(e => e.Material);

                entity.HasIndex(e => e.Price);

                entity.HasIndex(e => e.VendorCode)
                    .HasName("UQ_Product_VendorCode")
                    .IsUnique();

                entity.HasIndex(e => new { e.TypeOfProductId, e.ManufacturerId })
                    .HasName("IX_Product_TypeOfProductIdManufacturerId");

                entity.Property(e => e.DateOfCreating)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Material)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("numeric(7, 0)");

                entity.Property(e => e.VendorCode).HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TypeOfProduct)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.TypeOfProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductInOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_ProductInOrder_OrderId_ProductId");

                entity.ToTable("ProductInOrder", "InformationAboutOrder");

                entity.Property(e => e.ProductCount).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.ProductPriceInOrder).HasColumnType("numeric(7, 0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductInOrder)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInOrder)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size", "ProductInformation");

                entity.Property(e => e.DateOfCreating)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Size1)
                    .IsRequired()
                    .HasColumnName("Size")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SizeOfProduct>(entity =>
            {
                entity.HasKey(e => new { e.SizeId, e.ProductId })
                    .HasName("PK_SizeOfProduct_SizeId_ProductId");

                entity.ToTable("SizeOfProduct", "ProductInformation");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SizeOfProduct)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.SizeOfProduct)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_SizeOfProduct_SizeId_StatusIdSizeId");
            });

            modelBuilder.Entity<TypeOfProduct>(entity =>
            {
                entity.ToTable("TypeOfProduct", "ProductInformation");

                entity.Property(e => e.DateOfCreating)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
