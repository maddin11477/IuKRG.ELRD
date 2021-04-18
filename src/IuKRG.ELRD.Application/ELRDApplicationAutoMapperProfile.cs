using AutoMapper;
using IuKRG.ELRD.Hospitals;
using IuKRG.ELRD.Units;

namespace IuKRG.ELRD
{
    // automapper between database and dto's
    public class ELRDApplicationAutoMapperProfile : Profile
    {
        // master data
        public ELRDApplicationAutoMapperProfile()
        {
            // units
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateUpdateUnitDto, Unit>();

            // hospitals
            CreateMap<Hospital, HospitalDto>();
            CreateMap<CreateUpdateHospitalDto, Hospital>();
        }
    }
}
