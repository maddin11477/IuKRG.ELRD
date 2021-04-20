using AutoMapper;
using IuKRG.ELRD.Units;
using IuKRG.ELRD.Hospitals;
using IuKRG.ELRD.Diagnoses;

namespace IuKRG.ELRD.Web
{
    public class ELRDWebAutoMapperProfile : Profile
    {
        public ELRDWebAutoMapperProfile()
        {
            CreateMap<UnitDto, CreateUpdateUnitDto>();
            CreateMap<HospitalDto, CreateUpdateHospitalDto>();
            CreateMap<DiagnosisDto, CreateUpdateDiagnosisDto>();
        }
    }
}
