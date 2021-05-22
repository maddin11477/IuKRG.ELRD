using AutoMapper;
using IuKRG.ELRD.Units;
using IuKRG.ELRD.Hospitals;
using IuKRG.ELRD.Diagnoses;
using IuKRG.ELRD.Missions;

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

            // diagnoses
            CreateMap<Diagnosis, DiagnosisDto>();
            CreateMap<CreateUpdateDiagnosisDto, Diagnosis>();

            //missions
            CreateMap<Mission, MissionDto>();
            CreateMap<CreateUpdateMissionDto, Mission>();
        }
    }
}
