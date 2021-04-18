using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IuKRG.ELRD.Hospitals
{
    public interface IHospitalAppService :
        ICrudAppService<
            HospitalDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHospitalDto>
    {
    }
}
