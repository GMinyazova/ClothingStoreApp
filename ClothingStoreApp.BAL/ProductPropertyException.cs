using System;

namespace ClothingStoreApp.BAL
{
    public class ProductPropertyException : Exception
    {
        public ProductPropertyException(string message)
            : base(message)
        { }
    }
}
