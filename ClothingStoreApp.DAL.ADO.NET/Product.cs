using System.ComponentModel.DataAnnotations;

namespace ClothingStoreApp.DAL.ADO.NET
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Input vendor code")]

        public decimal VendorCode { get; set; }

        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Material { get; set; }

        public string Description { get; set; }

        public int TypeOfProductId { get; set; }

        public int ManufacturerId { get; set; }
    }
}
