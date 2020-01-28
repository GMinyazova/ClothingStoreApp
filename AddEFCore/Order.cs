using System;
using System.Collections.Generic;

namespace AddEFCore
{
    public partial class Order
    {
        public Order()
        {
            ProductInOrder = new HashSet<ProductInOrder>();
        }

        public int Id { get; set; }
        public DateTime? OrderAcceptanceDate { get; set; }
        public decimal TotalCost { get; set; }
        public string PaymentType { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime? StatusChangeDate { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ProductInOrder> ProductInOrder { get; set; }
    }
}
