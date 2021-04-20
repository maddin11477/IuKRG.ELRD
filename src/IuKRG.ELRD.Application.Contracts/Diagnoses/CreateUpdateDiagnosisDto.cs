using System.ComponentModel.DataAnnotations;

namespace IuKRG.ELRD.Diagnoses
{
    // data transfer object (DTO) - create, edit
    public class CreateUpdateDiagnosisDto
    {
        [Required]
        public int Category { get; set; }

        [Required]
        public string Injury { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
