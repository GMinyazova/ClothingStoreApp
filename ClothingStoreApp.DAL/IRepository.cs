using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStoreApp.DAL
{
    public interface IRepository
    {
        int FindType(string type);

        int FindManufacturer(string manufacturer);

        ProductDAL Add(ProductDAL product);
    }
}
