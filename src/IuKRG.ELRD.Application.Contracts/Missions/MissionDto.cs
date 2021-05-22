using System;
using Volo.Abp.Application.Dtos;

namespace IuKRG.ELRD.Missions
{
    public class MissionDto : FullAuditedEntityDto<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartKM { get; set; }
        public int EndKM { get; set; }
        public bool IsFinished { get; set; }
        public int MissionTaskNumber { get; set; }
        public string Location { get; set; }
        public string MissionType { get; set; }
        public string Reason { get; set; }
        public string Comment { get; set; }
        public Guid UserGuid { get; set; }
    }
}
