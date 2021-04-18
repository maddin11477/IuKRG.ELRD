using System;
using IuKRG.ELRD.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace IuKRG.ELRD.Hospitals
{
    public class HospitalAppService :
        CrudAppService<
            Hospital,
            HospitalDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHospitalDto>,
        IHospitalAppService
    {
        public HospitalAppService(IRepository<Hospital, Guid> repository) : base(repository)
        {
            GetPolicyName = ELRDPermissions.Hospitals.Default;
            GetListPolicyName = ELRDPermissions.Hospitals.Default;
            CreatePolicyName = ELRDPermissions.Hospitals.Create;
            UpdatePolicyName = ELRDPermissions.Hospitals.Edit;
            DeletePolicyName = ELRDPermissions.Hospitals.Delete;
        }
    }
}
