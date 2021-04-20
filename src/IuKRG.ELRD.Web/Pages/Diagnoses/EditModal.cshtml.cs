using System;
using System.Threading.Tasks;
using IuKRG.ELRD.Diagnoses;
using Microsoft.AspNetCore.Mvc;

namespace IuKRG.ELRD.Web.Pages.Diagnoses
{
    // subpage for editing existing diagnosis
    public class EditModalModel : ELRDPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateDiagnosisDto Diagnosis { get; set; }

        private readonly IDiagnosisAppService _diagnosisAppService;

        public EditModalModel(IDiagnosisAppService diagnosisAppService)
        {
            _diagnosisAppService = diagnosisAppService;
        }

        public async Task OnGetAsync()
        {
            var diagnosisDto = await _diagnosisAppService.GetAsync(Id);
            Diagnosis = ObjectMapper.Map<DiagnosisDto, CreateUpdateDiagnosisDto>(diagnosisDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _diagnosisAppService.UpdateAsync(Id, Diagnosis);
            return NoContent();
        }
    }
}
