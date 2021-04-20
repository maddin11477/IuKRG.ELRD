using System.Threading.Tasks;
using IuKRG.ELRD.Diagnoses;
using Microsoft.AspNetCore.Mvc;

namespace IuKRG.ELRD.Web.Pages.Diagnoses
{
    // subpage for creating new diagnosis
    public class CreateModalModel : ELRDPageModel
    {
        [BindProperty]
        public CreateUpdateDiagnosisDto Diagnosis { get; set; }

        private readonly IDiagnosisAppService _diagnosisAppService;

        public CreateModalModel(IDiagnosisAppService diagnosisAppService)
        {
            _diagnosisAppService = diagnosisAppService;
        }

        public void OnGet()
        {
            Diagnosis = new CreateUpdateDiagnosisDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _diagnosisAppService.CreateAsync(Diagnosis);
            return NoContent();
        }
    }
}
