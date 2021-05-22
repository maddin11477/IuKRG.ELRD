using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IuKRG.ELRD.Missions
{
    public interface IMissionAppService :
        ICrudAppService<                        // defines CRUD methods
            MissionDto,                            // data transfer object
            Guid,                               // primary key
            PagedAndSortedResultRequestDto,     // display and sort object
            CreateUpdateMissionDto>                // add / edit object
    {
    }
}
