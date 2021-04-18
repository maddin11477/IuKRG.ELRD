using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace IuKRG.ELRD.Units
{
    public class UnitDataSeederContributor : IDataSeedContributor, ITransientDependency
    {

        private readonly IRepository<Unit, Guid> _unitRepository;

        public UnitDataSeederContributor(IRepository<Unit, Guid> unitRepository)
        {
            _unitRepository = unitRepository;
        }


        //Hier können Daten bei dem ersten Start hinzugefügt werden
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _unitRepository.GetCountAsync() <= 0)
            {
                //RTWs befüllen
                string[] rtws = { "RK BISHM 71/1", "RK BISHM 71/70", "RK BKOHN 71/1", "RK BKOHN 71/70", "RK BNEST 71/1", "RK BNEST 71/2", "RK BNEST 71/3", "RK BNEST 71/70", "RK LALEI 71/1", "RK MELST 71/70", "RK NHM 71/1" };
                foreach (string x in rtws)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.RTW,
                            CrewCount = 2
                        },
                        autoSave: true
                    );
                }

                //KTWs befüllen
                string[] ktws = { "RK BNEST 72/1", "RK BNEST 72/2", "RK BKOHN 72/70", "JO MELST 72/1", "JO MELST 72/2", "JO MELST 72/3" };
                foreach (string x in ktws)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.KTW,
                            CrewCount = 2
                        },
                        autoSave: true
                    );
                }

                //NEFs befüllen
                string[] nefs = { "RK BISHM 76/1", "RK BKOHN 76/1", "RK BNEST 76/1", "RK MELST 76/1" };
                foreach (string x in nefs)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.NEF,
                            CrewCount = 1
                        },
                        autoSave: true
                    );
                }

                //RTHs befüllen
                string[] rths = { "Christoph 18", "Christoph 28", "Christoph 60", "Christoph 2", "Christoph 20", "Christoph Nürnberg", "Christoph Thüringen", "Christoph Mittelhessen", "Christoph Gießen" };
                foreach (string x in rths)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.RTH,
                            CrewCount = 3
                        },
                        autoSave: true
                    );
                }

                //KRADs befüllen
                string[] krads = { "RK NES 17/1", "RK NES 17/2" };
                foreach (string x in krads)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.Krad,
                            CrewCount = 1
                        },
                        autoSave: true
                    );
                }

                //KDOWs befüllen
                string[] kdows = { "RK BNEST 10/1", "RK BNEST 10/2", "RK BNEST 10/3" };
                foreach (string x in kdows)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.Kdow,
                            CrewCount = 2
                        },
                        autoSave: true
                    );
                }

                //Sonsigte befüllen
                string[] divers = { "RK BNEST 74/1", "RK BNEST 59/1" };
                foreach (string x in divers)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.Divers,
                            CrewCount = 2
                        },
                        autoSave: true
                    );
                }

                //MTWs befüllen
                string[] mtws = { "RK BISHM 14/1", "RK BNEST 11/2", "RK BNEST 14/1", "RK BNEST 14/10" };
                foreach (string x in mtws)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.MTW,
                            CrewCount = 9
                        },
                        autoSave: true
                    );
                }

                //LKWs befüllen
                string[] lkws = { "RK BNEST 54/1", "RK BISHM 56/1" };
                foreach (string x in lkws)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.LKW,
                            CrewCount = 2
                        },
                        autoSave: true
                    );
                }

                //KTWSKATS befüllen
                string[] kats = { "RK BNEST 73/1", "RK MELST 73/10" };
                foreach (string x in kats)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.KTWKATS,
                            CrewCount = 2
                        },
                        autoSave: true
                    );
                }

                //Wasserwacht befüllen
                string[] wasserwacht = { "WW BNEST 91/1", "WW WÜHSN 94/1" };
                foreach (string x in wasserwacht)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.Wasserwacht,
                            CrewCount = 9
                        },
                        autoSave: true
                    );
                }

                //ELWs befüllen
                string[] elws = { "KAT NES 13/2" };
                foreach (string x in elws)
                {
                    await _unitRepository.InsertAsync(
                        new Unit
                        {
                            Callsign = x,
                            Type = UnitType.ELW,
                            CrewCount = 4
                        },
                        autoSave: true
                    );
                }
            }
        }
    }
}