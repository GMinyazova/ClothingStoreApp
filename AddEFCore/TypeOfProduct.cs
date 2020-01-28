using System;
using System.Collections.Generic;

namespace AddEFCore
{
    public partial class TypeOfProduct
    {
        public TypeOfProduct()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfCreating { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
