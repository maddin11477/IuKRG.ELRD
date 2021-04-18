using System;
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

        }
    }
}
