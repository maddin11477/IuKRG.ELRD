using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace IuKRG.ELRD.Diagnoses
{
    public class Diagnosis : FullAuditedAggregateRoot<Guid>
    {
        public int Category { get; set; }
        public string Injury { get; set; }
        public string Location { get; set; }
    }
}
