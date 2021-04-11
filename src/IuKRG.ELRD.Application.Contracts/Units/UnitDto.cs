using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace IuKRG.ELRD.Units
{
    public class UnitDto : FullAuditedEntityDto<Guid>
    {
        public string Callsign { get; set; }
        public int CrewCount { get; set; }
        public UnitType Type { get; set; }
    }
}
