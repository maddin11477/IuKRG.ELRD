using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace IuKRG.ELRD.Hospitals
{
    public class Hospital : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
    }
}
