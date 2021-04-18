using System.ComponentModel.DataAnnotations;

namespace IuKRG.ELRD.Hospitals
{
    public class CreateUpdateHospitalDto
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public double Long { get; set; }

        [Required]
        public double Lat { get; set; }
    }
}
