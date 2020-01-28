using AutoMapper;
using ClothingStoreApp.DAL;

namespace ClothingStoreApp.BAL.AutoMapper
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<ProductBal, ProductDal>();
        }
    }
}
