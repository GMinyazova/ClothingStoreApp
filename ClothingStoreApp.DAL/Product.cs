using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStoreApp.DAL
{
    public class ProductDAL
    {
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

        public Manufacturer Manufacturer { get; set; }

        public TypeOfProduct TypeOfProduct { get; set; }
    }
}
