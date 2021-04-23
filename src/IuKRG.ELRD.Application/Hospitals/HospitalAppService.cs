using System;
using IuKRG.ELRD.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace IuKRG.ELRD.Hospitals
{
    public class HospitalAppService :
        CrudAppService<
            Hospital,                           // hospital entity
            HospitalDto,                        // data transfer object
            Guid,                               // primary key
            PagedAndSortedResultRequestDto,     // display and sort object
            CreateUpdateHospitalDto>,           // add / edit object
        IHospitalAppService
    {
        public HospitalAppService(IRepository<Hospital, Guid> repository) : base(repository)
        {
            GetPolicyName = ELRDPermissions.Basedata.Default;
            CreatePolicyName = ELRDPermissions.Basedata.HospitalCU;
            DeletePolicyName = ELRDPermissions.Basedata.HospitalD;
        }
    }
}
