namespace ClothingStoreApp.BAL
{
    public class ProductBal
    {
        private decimal vendorCode;

        private string name;

        private decimal price;

        private string material;

        private string typeOfProduct;

        private string manufacturer;

        public decimal VendorCode
        {
            get => vendorCode;
            set
            {
                if (value < 0)
                    throw new ProductPropertyException("Vendor code should not be less than 0");
                else
                    vendorCode = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ProductPropertyException("Name should not be empty");
                else
                    name = value;
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ProductPropertyException("Price should not be less than 0");
                else
                    price = value;
            }
        }

        public string Material
        {
            get => material;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ProductPropertyException("Material should not be empty");
                else
                    material = value;
            }
        }

        public string TypeOfProduct
        {
            get => typeOfProduct;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ProductPropertyException("Type of product should not be empty");
                else
                    typeOfProduct = value;
            }
        }

        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ProductPropertyException("Manufacturer should not be empty");
                else
                    manufacturer = value;
            }
        }

        public string Description { get; set; }
    }
}
