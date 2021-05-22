using System;
using System.Threading.Tasks;
using IuKRG.ELRD.Missions;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Users;

namespace IuKRG.ELRD.Web.Pages.Missions
{
    // subpage for creating new mission
    public class CreateModalModel : ELRDPageModel
    {

        [BindProperty]
        public CreateUpdateMissionDto Mission { get; set; }

        private readonly IMissionAppService _missionAppService;
        private readonly ICurrentUser _currentUser;

        public CreateModalModel(IMissionAppService missionAppService, ICurrentUser currentUser)
        {
            _missionAppService = missionAppService;
            _currentUser = currentUser;
        }

        public void OnGet()
        {
            Mission = new CreateUpdateMissionDto();
            Mission.UserGuid = (System.Guid)_currentUser.Id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _missionAppService.CreateAsync(Mission);
            return NoContent();
        }
    }
}
