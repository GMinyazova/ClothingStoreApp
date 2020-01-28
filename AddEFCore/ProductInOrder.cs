using System;
using System.Collections.Generic;

namespace AddEFCore
{
    public partial class ProductInOrder
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductCount { get; set; }
        public decimal? ProductPriceInOrder { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
