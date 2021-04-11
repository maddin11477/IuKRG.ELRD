using AutoMapper;
using IuKRG.ELRD.Units;

namespace IuKRG.ELRD.Web
{
    public class ELRDWebAutoMapperProfile : Profile
    {
        public ELRDWebAutoMapperProfile()
        {
            CreateMap<UnitDto, CreateUpdateUnitDto>();
        }
    }
}
