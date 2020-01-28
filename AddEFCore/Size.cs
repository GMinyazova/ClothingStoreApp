using System;
using System.Collections.Generic;

namespace AddEFCore
{
    public partial class Size
    {
        public Size()
        {
            SizeOfProduct = new HashSet<SizeOfProduct>();
        }

        public int Id { get; set; }
        public string Size1 { get; set; }
        public DateTime? DateOfCreating { get; set; }

        public virtual ICollection<SizeOfProduct> SizeOfProduct { get; set; }
    }
}
