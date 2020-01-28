using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStoreApp.DAL
{
    public class Manufacturer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DateOfCreating { get; set; }

        public string Country { get; set; }

        public ICollection<ProductDAL> Product { get; set; }
    }
}
