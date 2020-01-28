using System;
using System.Linq;

namespace ClothingStoreApp.DAL.EntityFramework
{
    public sealed class EntityFrameworkProductRepository : IProductRepository
    {
        private string connectionString;
        public EntityFrameworkProductRepository(string connectionString) => this.connectionString = connectionString;

        public ProductDal Add(ProductDal product)
        {
            using (var db = new StoreContext(connectionString))
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
                product.Id = prod.Id;
                return product;
            }
        }

        public int FindTypeId(string type)
        {
            using (var db = new StoreContext(connectionString))
            {
                var typeOfProduct = db.TypesOfProduct.FirstOrDefault(x => x.Name == type);
                if (typeOfProduct == null)
                    throw new Exception("Product type is not found.");
                else
                    return typeOfProduct.Id;
            }
        }

        public int FindManufacturerId(string manufacturer)
        {
            using (var db = new StoreContext(connectionString))
            {
                var productManufacturer = db.Manufacturers.FirstOrDefault(x => x.Name == manufacturer);
                if (productManufacturer == null)
                    throw new Exception("Manufacturer is not found.");
                else
                    return productManufacturer.Id;
            }
        }
    }
}
