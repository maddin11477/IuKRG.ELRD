using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IuKRG.ELRD.Units
{
    public interface IUnitAppService :
        ICrudAppService<                        // defines CRUD methods
            UnitDto,                            // data transfer object
            Guid,                               // primary key
            PagedAndSortedResultRequestDto,     // display and sort object
            CreateUpdateUnitDto>                // add / edit object
    {
    }
}
