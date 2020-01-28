namespace ClothingStoreApp.DAL
{
    public class ProductDal
    {
        public int Id { get; set; }

        public decimal VendorCode { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Material { get; set; }

        public string Description { get; set; }

        public int TypeOfProductId { get; set; }

        public int ManufacturerId { get; set; }
    }
}
