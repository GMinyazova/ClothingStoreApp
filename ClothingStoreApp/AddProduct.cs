namespace ClothingStoreApp
{
    using System;
    using ClothingStoreApp.DAL;
    using UnitOfWork;
    using AutoMapper;
    public enum DbInteractionType
    {
        EntityFramework,

        EntityFrameworkCore,

        AdoNet,

        Def
    }

    public class AddProduct
    {
        private UnitOfWorkClass unitOfWork = new UnitOfWorkClass();
        private IRepository repos;
        public void Add(DbInteractionType connectionType)
        {
            switch (connectionType)
            {
                case DbInteractionType.AdoNet:
                    repos = unitOfWork.AdoNet;
                    break;
                case DbInteractionType.EntityFramework:
                    repos = unitOfWork.EntityFramework;
                    break;
            }

            if (repos == null)
                throw new Exception("Error");
         
            ProductBLL data = new ConsoleProductReader().InputData(repos);

            var config = new MapperConfiguration(r => r.CreateMap <ProductBLL, ProductDAL> ()).CreateMapper();
            var product = config.Map<ProductBLL, ProductDAL>(data);
            repos.Add(product);
        }

        public static string FindTypeOfProduct(IRepository repos)
        {
            int typeOfProductId;
            while (true)
            {
                Console.WriteLine("Input Type:");
                string value = Console.ReadLine();
                typeOfProductId = repos.FindType(value);
                if (typeOfProductId != -1)
                    break;
                else
                    Console.WriteLine("Product type is not found. Enter another type.");
            }

            return typeOfProductId.ToString();
        }

        public static string FindTypeOfManufacturer(IRepository repos)
        {
            int manufacturerId;
            while (true)
            {
                Console.WriteLine("Input Manufacturer:");
                string value = Console.ReadLine();
                manufacturerId = repos.FindManufacturer(value);
                if (manufacturerId != -1)
                    break;
                else
                    Console.WriteLine("Manufacturer type is not found. Enter another manufacturer.");
            }

            return manufacturerId.ToString();
        }

        // public AddProduct(IReader reader) => Reader = reader;
        // public IReader Reader { get; set; }
        /*private static string[] InputData(IFunc connection)
        {
            var myType = typeof(Product);
            PropertyInfo[] propertyInfo = myType.GetProperties();
            string[] propertyValue = new string[propertyInfo.Length];
            for (var i = 1; i < propertyInfo.Length; i++)
                if (propertyInfo[i].Name == "TypeOfProductId")
                    propertyValue[i - 1] = FindTypeOfProduct(connection);
                else if (propertyInfo[i].Name == "ManufacturerId")
                    propertyValue[i - 1] = FindTypeOfManufacturer(connection);
                else
                {
                    Console.WriteLine("Input " + propertyInfo[i].Name);
                    string value = Console.ReadLine();
                    propertyValue[i - 1] = value;
                }

            return propertyValue;*/
    }
}
