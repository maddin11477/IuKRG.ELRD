using IuKRG.ELRD.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace IuKRG.ELRD.Missions
{
    public class MissionAppService :
        CrudAppService<
            Mission,                               // unit entity
            MissionDto,                            // data transfer object
            Guid,                               // primary key
            PagedAndSortedResultRequestDto,     // display and sort object
            CreateUpdateMissionDto>,               // add / edit object
        IMissionAppService
    {
        public MissionAppService(IRepository<Mission, Guid> repository) : base(repository)
        {
            GetPolicyName = ELRDPermissions.Basedata.Default;
            CreatePolicyName = ELRDPermissions.Basedata.UnitCU;
            DeletePolicyName = ELRDPermissions.Basedata.UnitD;
        }
    }
}
