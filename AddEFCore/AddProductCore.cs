using System;
using System.Linq;
using ClothingStoreApp.DAL;

namespace AddEFCore
{
    class AddProductCore : IRepository
    {
        public ProductDAL Add(ProductDAL product)
        {
            using (var db = new ClothingStoreContext())
            {
                Product prod = new Product
                {
                    VendorCode = product.VendorCode,
                    Name = product.Name,
                    Price = product.Price,
                    Material = product.Material,
                    Description = product.Description,
                    TypeOfProductId = product.TypeOfProductId,
                    ManufacturerId = product.ManufacturerId
                };
                db.Products.Add(prod);
                db.SaveChanges();
                Console.WriteLine("Item added to table.");
                return product;
            }
        }

        public int FindType(string type)
        {
            using (var db = new ClothingStoreContext())
            {
                var typeOfProduct = db.TypesOfProduct.FirstOrDefault(x => x.Name == type);
                if (typeOfProduct == null)
                    return -1;
                else
                    return typeOfProduct.Id;
            }
        }

        public int FindManufacturer(string manufacturer)
        {
            using (var db = new ClothingStoreContext())
            {
                var productManufacturer = db.Manufacturers.FirstOrDefault(x => x.Name == manufacturer);
                if (productManufacturer == null)
                    return -1;
                else
                    return productManufacturer.Id;
            }
        }
    }
}
