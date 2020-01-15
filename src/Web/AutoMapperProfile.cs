using AutoMapper;
using Web.Factories.Product;
using Web.Models.Product;

namespace Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductGroup, ProductGroupModel>()
                    .ReverseMap();
        }
    }
}
