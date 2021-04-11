using AutoMapper;
using IuKRG.ELRD.Units;

namespace IuKRG.ELRD
{
    public class ELRDApplicationAutoMapperProfile : Profile
    {
        public ELRDApplicationAutoMapperProfile()
        {
            //Automapper zwischen Datenbank und DTOs
            //Für Stammdaten
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateUpdateUnitDto, Unit>();
        }
    }
}
