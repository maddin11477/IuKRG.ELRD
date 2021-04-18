using AutoMapper;
using IuKRG.ELRD.Hospitals;
using IuKRG.ELRD.Units;

namespace IuKRG.ELRD
{
    public class ELRDApplicationAutoMapperProfile : Profile
    {
        public ELRDApplicationAutoMapperProfile()
        {
            //Automapper zwischen Datenbank und DTOs
            //Für Stammdaten
            //Einheiten
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateUpdateUnitDto, Unit>();

            //Kliniken
            CreateMap<Hospital, HospitalDto>();
            CreateMap<CreateUpdateHospitalDto, Hospital>();
        }
    }
}
