using System.Threading.Tasks;
using IuKRG.ELRD.Units;
using Microsoft.AspNetCore.Mvc;

namespace IuKRG.ELRD.Web.Pages.Units
{
    // subpage for creating new unit
    public class CreateModalModel : ELRDPageModel
    {
        [BindProperty]
        public CreateUpdateUnitDto Unit { get; set; }

        private readonly IUnitAppService _unitAppService;

        public CreateModalModel(IUnitAppService unitAppService)
        {
            _unitAppService = unitAppService;
        }

        public void OnGet()
        {
            Unit = new CreateUpdateUnitDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _unitAppService.CreateAsync(Unit);
            return NoContent();
        }
    }
}
