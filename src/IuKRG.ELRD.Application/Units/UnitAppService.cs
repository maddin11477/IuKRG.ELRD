using System;
using IuKRG.ELRD.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace IuKRG.ELRD.Units
{
    public class UnitAppService :
        CrudAppService<
            Unit,                               // unit entity
            UnitDto,                            // data transfer object
            Guid,                               // primary key
            PagedAndSortedResultRequestDto,     // display and sort object
            CreateUpdateUnitDto>,               // add / edit object
        IUnitAppService
    {
        public UnitAppService(IRepository<Unit, Guid> repository) : base(repository)
        {
            GetPolicyName = ELRDPermissions.Basedata.Default;
            CreatePolicyName = ELRDPermissions.Basedata.UnitCU;
            DeletePolicyName = ELRDPermissions.Basedata.UnitD;
        }
    }
}
