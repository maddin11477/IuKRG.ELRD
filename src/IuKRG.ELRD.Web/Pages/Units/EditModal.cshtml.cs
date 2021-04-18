using System;
using System.Threading.Tasks;
using IuKRG.ELRD.Units;
using Microsoft.AspNetCore.Mvc;

namespace IuKRG.ELRD.Web.Pages.Units
{
    // subpage for editing existing unit
    public class EditModalModel : ELRDPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateUnitDto Unit { get; set; }

        private readonly IUnitAppService _unitAppService;

        public EditModalModel(IUnitAppService unitAppService)
        {
            _unitAppService = unitAppService;
        }

        public async Task OnGetAsync()
        {
            var unitDto = await _unitAppService.GetAsync(Id);
            Unit = ObjectMapper.Map<UnitDto, CreateUpdateUnitDto>(unitDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _unitAppService.UpdateAsync(Id, Unit);
            return NoContent();
        }
    }
}
