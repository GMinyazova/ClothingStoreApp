using System;

namespace ClothingStoreApp.DAL
{
    public class IdNotFoundException : Exception
    {
        public IdNotFoundException(string message)
            : base(message)
        { }
    }
}
