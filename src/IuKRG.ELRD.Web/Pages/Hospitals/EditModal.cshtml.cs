using System;
using System.Threading.Tasks;
using IuKRG.ELRD.Hospitals;
using Microsoft.AspNetCore.Mvc;

namespace IuKRG.ELRD.Web.Pages.Hospitals
{
    // subpage for editing existing hospital
    public class EditModalModel : ELRDPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateHospitalDto Hospital { get; set; }

        private readonly IHospitalAppService _hospitalAppService;

        public EditModalModel(IHospitalAppService hospitalAppService)
        {
            _hospitalAppService = hospitalAppService;
        }

        public async Task OnGetAsync()
        {
            var hospitalDto = await _hospitalAppService.GetAsync(Id);
            Hospital = ObjectMapper.Map<HospitalDto, CreateUpdateHospitalDto>(hospitalDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _hospitalAppService.UpdateAsync(Id, Hospital);
            return NoContent();
        }
    }
}
