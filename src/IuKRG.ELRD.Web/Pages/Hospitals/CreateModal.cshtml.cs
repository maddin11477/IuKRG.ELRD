using System.Threading.Tasks;
using IuKRG.ELRD.Hospitals;
using Microsoft.AspNetCore.Mvc;

namespace IuKRG.ELRD.Web.Pages.Hospitals
{
    public class CreateModalModel : ELRDPageModel
    {
        [BindProperty]
        public CreateUpdateHospitalDto Hospital { get; set; }

        private readonly IHospitalAppService _hospitalAppService;

        public CreateModalModel(IHospitalAppService hospitalAppService)
        {
            _hospitalAppService = hospitalAppService;
        }

        public void OnGet()
        {
            Hospital = new CreateUpdateHospitalDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _hospitalAppService.CreateAsync(Hospital);
            return NoContent();
        }
    }
}
