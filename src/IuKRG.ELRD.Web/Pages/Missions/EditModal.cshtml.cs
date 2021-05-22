using System;
using System.Threading.Tasks;
using IuKRG.ELRD.Missions;
using Microsoft.AspNetCore.Mvc;

namespace IuKRG.ELRD.Web.Pages.Missions
{
    // subpage for editing existing mission
    public class EditModalModel : ELRDPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateMissionDto Mission { get; set; }

        private readonly IMissionAppService _missionAppService;

        public EditModalModel(IMissionAppService missionAppService)
        {
            _missionAppService = missionAppService;
        }

        public async Task OnGetAsync()
        {
            var missionDto = await _missionAppService.GetAsync(Id);
            Mission = ObjectMapper.Map<MissionDto, CreateUpdateMissionDto>(missionDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _missionAppService.UpdateAsync(Id, Mission);
            return NoContent();
        }
    }
}
