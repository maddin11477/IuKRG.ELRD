using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IuKRG.ELRD.Hospitals
{
    public interface IHospitalAppService :
        ICrudAppService<                        // defines CRUD methods
            HospitalDto,                        // data transfer object
            Guid,                               // primary key
            PagedAndSortedResultRequestDto,     // display and sort object
            CreateUpdateHospitalDto>            // add / edit object
    {
    }
}
