using System;
using System.Configuration;
using ClothingStoreApp.BAL;
using ClothingStoreApp.BAL.StoreLogger;
using ClothingStoreApp.DAL.ADO.NET;
using ClothingStoreApp.DAL.EntityFramework;
using StoreReader;

namespace ClothingStoreApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ProductManager productManager = null;

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. ADO.NET \t 2. Entity famework  \t 3. Entity famework core  \t 4. Выход");
                try
                {
                    int connectionMethod = Convert.ToInt32(Console.ReadLine());
                    switch (connectionMethod)
                    {
                        case 1:
                            productManager = new ProductManager(new AdoNetProductRepository(ConfigurationManager.ConnectionStrings["StoreContext"].ConnectionString), new MyLogger());
                            break;
                        case 2:
                            productManager = new ProductManager(new EntityFrameworkProductRepository(ConfigurationManager.ConnectionStrings["StoreContext"].ConnectionString), new MyLogger());
                            break;
                        case 3:
                            ////technology = DbInteractionType.EntityFrameworkCore;
                            break;
                        case 4:
                            flag = false;
                            continue;
                    }

                    if (productManager != null)
                        productManager.Add(new ConsoleProductReader().Read());
                    else
                        Console.WriteLine("Choose connection method");
                }
                catch (Exception ex)
                {
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.TargetSite);
                    Console.ForegroundColor = color;
                }
            }
        }
    }
}
