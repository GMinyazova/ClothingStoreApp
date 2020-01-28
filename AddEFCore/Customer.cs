using System;
using System.Collections.Generic;

namespace AddEFCore
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public decimal PhoneNumber { get; set; }
        public DateTime? DateOfCreating { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
