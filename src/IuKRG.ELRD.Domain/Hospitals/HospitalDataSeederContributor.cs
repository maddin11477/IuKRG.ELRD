using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace IuKRG.ELRD.Hospitals
{
    public class HospitalDataSeederContributor : IDataSeedContributor, ITransientDependency
    {

        private readonly IRepository<Hospital, Guid> _hospitalRepository;

        public HospitalDataSeederContributor(IRepository<Hospital, Guid> hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }


        //Hier können Daten bei dem ersten Start hinzugefügt werden
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _hospitalRepository.GetCountAsync() <= 0)
            {
                //Kliniken befüllen
                string[] names = { "Campus Rhön", "St. Elisabeth", "Klinikum Meiningen", "Leopoldina", "St. Josef", "Franz von Prümmer Klinik", "KHS Hammelburg", "KHS Hassfurt", "KHS Ebern", "Klinikum Fulda", "Klinikum Suhl", "Uni Würzburg", "Zentralklinik Bad Berka", "Klinikum Coburg", "BGU Klinik" };
                string[] cities = { "Bad Neustadt", "Bad Kissingen", "Meiningen", "Schweinfurt", "Schweinfurt", "Bad Brückenau", "Hammelburg", "Hassfurt", "Ebern", "Fulda", "Suhl", "Würzburg", "Bad Berka", "Coburg", "Frankfurt" };
                double[] longs = { 50.323636, 50.189797, 50.557849, 50.051994, 50.051994, 50.307681, 50.119965, 50.040304, 50.097157, 50.548481, 50.60252, 49.806359, 50.889507, 50.246963, 50.144988 };
                double[] lats = { 10.23298, 10.083099, 10.397545, 10.24366, 10.24366, 9.785157, 9.898004, 10.514484, 10.798534, 9.706519, 10.70957, 9.95758, 11.266051, 10.973357, 8.709632 };

                int i = 1;
                foreach (string x in names)
                {
                    await _hospitalRepository.InsertAsync(
                        new Hospital
                        {
                            Name = names[i],
                            City = cities[i],
                            Long = longs[i],
                            Lat = lats[i]
                        },
                        autoSave: true
                    );

                    i++;
                }
            }
        }
    }
}