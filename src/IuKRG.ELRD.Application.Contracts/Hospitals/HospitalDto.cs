using System;
using Volo.Abp.Application.Dtos;

namespace IuKRG.ELRD.Hospitals
{
    // data transfer object (DTO) - general
    public class HospitalDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
    }
}
