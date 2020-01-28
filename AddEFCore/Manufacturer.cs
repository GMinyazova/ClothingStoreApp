using System;
using System.Collections.Generic;

namespace AddEFCore
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfCreating { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
