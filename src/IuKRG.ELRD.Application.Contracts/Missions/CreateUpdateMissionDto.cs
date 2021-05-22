using System;
using System.ComponentModel.DataAnnotations;

namespace IuKRG.ELRD.Missions
{
    public class CreateUpdateMissionDto
    {
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartKM { get; set; }
        public int EndKM { get; set; }
        public bool IsFinished { get; set; }
        public int MissionTaskNumber { get; set; }

        [Required]
        [StringLength(256)]
        public string Location { get; set; }

        [Required]
        [StringLength(256)]
        public string MissionType { get; set; }

        [Required]
        [StringLength(256)]
        public string Reason { get; set; }

        [StringLength(256)]
        public string Comment { get; set; }

        [Required]
        public Guid? UserGuid { get; set; }
    }
}
