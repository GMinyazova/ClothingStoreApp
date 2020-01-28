namespace ClothingStoreApp.DAL.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductInformation.TypeOfProduct")]
    public class TypeOfProduct
    {
        ////public TypeOfProduct() => Products = new HashSet<Product>();

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? DateOfCreating { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
