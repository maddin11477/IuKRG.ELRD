using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace IuKRG.ELRD.Missions
{
    public class MissionDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Mission, Guid> _missionRepository;

        public MissionDataSeederContributor(IRepository<Mission, Guid> missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _missionRepository.GetCountAsync() <= 0)
            {
                //Add one example Mission
                await _missionRepository.InsertAsync(
                        new Mission
                        {
                            Comment = "Das ist ein Beispiel Einsatz und kann im Produktiveinsatz gelöscht werden",
                            EndDate = DateTime.Now.AddDays(-10),
                            StartDate = DateTime.Now.AddDays(-10),
                            StartKM = 1023,
                            EndKM = 1043,
                            Location = "Campus Bad Neustadt",
                            Reason = "BMA",
                            IsFinished = true,
                            MissionTaskNumber = 1234
                        },
                        autoSave: true
                    );
            }
        }
    }
}
