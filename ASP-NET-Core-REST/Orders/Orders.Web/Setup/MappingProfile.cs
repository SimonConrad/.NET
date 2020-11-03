using AutoMapper;
using Orders.Dal.Dbos;
using Orders.Web.RequestModels;

namespace Orders.Web.Setup
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductReqModel, ProductDbo>();
            CreateMap<ProductDbo, ProductReqModel>();
        }
    }
}