using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace IuKRG.ELRD.Units
{
    public class Unit : FullAuditedAggregateRoot<Guid>
    {
        public string Callsign { get; set; }
        public int CrewCount { get; set; }
        public UnitType Type { get; set; }
    }
}
