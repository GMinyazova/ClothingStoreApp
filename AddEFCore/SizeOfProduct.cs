using System;
using System.Collections.Generic;

namespace AddEFCore
{
    public partial class SizeOfProduct
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
