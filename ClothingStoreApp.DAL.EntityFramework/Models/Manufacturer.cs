namespace ClothingStoreApp.DAL.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductInformation.Manufacturer")]
    public class Manufacturer
    {
        ////public Manufacturer() => Products = new HashSet<Product>();

        public int Id { get; set; }

        /*[Required]
        [StringLength(100)]*/
        public string Name { get; set; }

        public DateTime? DateOfCreating { get; set; }

        /*[Required]
        [StringLength(50)]*/
        public string Country { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
