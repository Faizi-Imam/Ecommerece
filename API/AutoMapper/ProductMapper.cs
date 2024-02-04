using AutoMapper;
using ecommerce.Data;

namespace ecommerce.AutoMapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Entities,EntityModel>().ReverseMap();
        }
    }
}