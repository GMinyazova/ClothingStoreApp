namespace ClothingStoreApp.BAL
{
    using ClothingStoreApp.BAL.AutoMapper;
    using ClothingStoreApp.BAL.StoreLogger;
    using ClothingStoreApp.DAL;

    public sealed class ProductManager
    {
        private IProductRepository repos;
        private ILogger logger;

        public ProductManager()
        {
        }

        public ProductManager(IProductRepository repos, ILogger logger)
        {
            this.repos = repos;
            this.logger = logger;
        }

        public void Add(ProductBal product)
        {
            var productDal = AutoMapperConfiguration.Configure().Map<ProductDal>(product);
            productDal.TypeOfProductId = repos.FindTypeId(product.TypeOfProduct);
            productDal.ManufacturerId = repos.FindManufacturerId(product.Manufacturer);
            var addedProduct = repos.Add(productDal);
            logger.LogInfo($"Product with Id = {addedProduct.Id} added to table");
        }
    }
}
