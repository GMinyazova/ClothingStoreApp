namespace ClothingStoreApp.DAL.EntityFramework
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductInformation.Product")]
    public class Product
    {
        public int Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal VendorCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(200)]
        public string Material { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? DateOfCreating { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int TypeOfProductId { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual TypeOfProduct TypeOfProduct { get; set; }
    }
}
