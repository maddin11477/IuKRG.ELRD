using System;
using Volo.Abp.Application.Dtos;

namespace IuKRG.ELRD.Diagnoses
{
    // data transfer object (DTO) - general
    public class DiagnosisDto : FullAuditedEntityDto<Guid>
    {
        public int Category { get; set; }
        public string Injury { get; set; }
        public string Location { get; set; }
    }
}
