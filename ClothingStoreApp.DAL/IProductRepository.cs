namespace ClothingStoreApp.DAL
{
    public interface IProductRepository
    {
        int FindTypeId(string type);

        int FindManufacturerId(string manufacturer);

        ProductDal Add(ProductDal product);
    }
}
