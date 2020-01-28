using AutoMapper;

namespace ClothingStoreApp.BAL.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            return new MapperConfiguration(r => r.AddProfile<StoreProfile>()).CreateMapper();
        }
    }
}
