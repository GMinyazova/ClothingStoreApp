using System;
using System.Collections.Generic;
using System.Reflection;
using ClothingStoreApp.BAL;

namespace StoreReader
{
    public class ConsoleProductReader : IReader
    {
        public ProductBal Read()
        {
            var myType = typeof(ProductBal);
            PropertyInfo[] propertyInfo = myType.GetProperties();
            List<string> propertyValue = new List<string>();
            for (var i = 0; i < propertyInfo.Length; i++)
            {
                Console.WriteLine("Input " + propertyInfo[i].Name);
                string value = Console.ReadLine();
                propertyValue.Add(value);
            }

            ProductBal product = new ProductBal();
            try
            {
                decimal vendorCode = Convert.ToDecimal(propertyValue[0]);
                decimal price = Convert.ToDecimal(propertyValue[2]);
                product.VendorCode = vendorCode;
                product.Price = price;
                product.Name = propertyValue[1];
                product.Material = propertyValue[3];
                product.Description = propertyValue[6];
                product.TypeOfProduct = propertyValue[4];
                product.Manufacturer = propertyValue[5];
            }
            catch (ProductPropertyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Vendor  code and price must be a number");
            }

            return product;
        }
    }
}
