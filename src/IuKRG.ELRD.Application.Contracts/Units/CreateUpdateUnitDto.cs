using System;
using System.ComponentModel.DataAnnotations;

namespace IuKRG.ELRD.Units
{
    public class CreateUpdateUnitDto
    {
        [Required]
        [StringLength(256)]
        public string Callsign { get; set; }

        [Required]
        public int CrewCount { get; set; }

        [Required]
        public UnitType Type { get; set; }
    }
}
