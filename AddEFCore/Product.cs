using System;
using System.Collections.Generic;

namespace AddEFCore
{
    public partial class Product
    {
        public Product()
        {
            ProductInOrder = new HashSet<ProductInOrder>();
            SizeOfProduct = new HashSet<SizeOfProduct>();
        }

        public int Id { get; set; }
        public decimal VendorCode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfCreating { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int TypeOfProductId { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual TypeOfProduct TypeOfProduct { get; set; }
        public virtual ICollection<ProductInOrder> ProductInOrder { get; set; }
        public virtual ICollection<SizeOfProduct> SizeOfProduct { get; set; }
    }
}
