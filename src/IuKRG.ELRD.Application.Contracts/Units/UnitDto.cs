using System;
using Volo.Abp.Application.Dtos;

namespace IuKRG.ELRD.Units
{
    // data transfer object (DTO) - general
    public class UnitDto : FullAuditedEntityDto<Guid>
    {
        public string Callsign { get; set; }
        public int CrewCount { get; set; }
        public UnitType Type { get; set; }
    }
}
