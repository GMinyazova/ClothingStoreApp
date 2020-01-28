using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ClothingStoreApp.DAL.ADO.NET
{
    public class AdoNetProductRepository : IProductRepository
    {
        ////private string connectionString = ConfigurationManager.ConnectionStrings["StoreContext"].ConnectionString;
        private string connectionString;
        public AdoNetProductRepository(string connectionString) => this.connectionString = connectionString;

        public ProductDal Add(ProductDal product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var commandInsertProduct = new SqlCommand(
                    "Insert into ProductInformation.Product(VendorCode, Name, Price, Material, Description, TypeOfProductId, ManufacturerId) "
                    + "values (@VendorCode, @Name, @Price, @Material, @Description, @TypeOfProductId, @ManufacturerId);SET @id=SCOPE_IDENTITY()",
                    connection);

                var myType = typeof(ProductDal);
                PropertyInfo[] propertyInfo = myType.GetProperties();
                for (var i = 1; i < propertyInfo.Length; i++)
                {
                    var parameter = new SqlParameter("@" + propertyInfo[i].Name, propertyInfo[i].GetValue(product));
                    commandInsertProduct.Parameters.Add(parameter);
                }

                SqlParameter idParam = new SqlParameter
                                           {
                                               ParameterName = "@id",
                                               SqlDbType = SqlDbType.Int,
                                               Direction = ParameterDirection.Output
                                           };
                commandInsertProduct.Parameters.Add(idParam);
                commandInsertProduct.ExecuteNonQuery();
                product.Id = Convert.ToInt32(idParam.Value);
                commandInsertProduct.Dispose();
                return product;
            }
        }

        public int FindTypeId(string type)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                object typeId;
                string commandText = "SELECT Id FROM ProductInformation.TypeOfProduct WHERE Name=@type";
                using (var command = new SqlCommand(commandText, connection))
                {
                    var typeParameter = new SqlParameter("@type", type);
                    command.Parameters.Add(typeParameter);
                    typeId = command.ExecuteScalar();
                }

                if (typeId == null)
                    throw new IdNotFoundException("Product type is not found.");
                else
                    return Convert.ToInt32(typeId);
            }
        }

        public int FindManufacturerId(string manufacturer)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                object manufacturerId;
                string commandText = "SELECT Id FROM ProductInformation.Manufacturer WHERE Name=@manufacturer";
                    using (var command = new SqlCommand(commandText, connection))
                    {
                        var manufacturerParameter = new SqlParameter("@manufacturer", manufacturer);
                        command.Parameters.Add(manufacturerParameter);
                        manufacturerId = command.ExecuteScalar();
                    }

                if (manufacturerId == null)
                    throw new IdNotFoundException("Manufacturer is not found.");
                else
                    return Convert.ToInt32(manufacturerId);
            }
        }
    }
}
