using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IuKRG.ELRD.Diagnoses
{
    public interface IDiagnosisAppService :
        ICrudAppService<                        // defines CRUD methods
            DiagnosisDto,                       // data transfer object
            Guid,                               // primary key
            PagedAndSortedResultRequestDto,     // display and sort object
            CreateUpdateDiagnosisDto>           // add / edit object
    {
    }
}
