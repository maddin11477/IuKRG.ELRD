using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace IuKRG.ELRD.Diagnoses
{
    public class DiagnosisDataSeederContributor : IDataSeedContributor, ITransientDependency
    {

        private readonly IRepository<Diagnosis, Guid> _diagnosisRepository;

        public DiagnosisDataSeederContributor(IRepository<Diagnosis, Guid> diagnosisRepository)
        {
            _diagnosisRepository = diagnosisRepository;
        }


        // fill database with entries at first startup
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _diagnosisRepository.GetCountAsync() <= 0)
            {
                // fill diagnosis
                string[] DIAGarm = { "Oberarm#", "Oberarm# offen", "Oberarm Amputation", "Schulterluxation", "Ellenbogenluxation" };
                string[] DIAGthigh = { "Oberschenkel#", "Oberschenkel# offen", "Oberschenkel Amputation", "Becken#", "Becken# offen" };
                string[] DIAGlowerLeg = { "Unterschenkel#", "Unterschenkel# offen", "Unterschenkel Amputation", "Patella#", "Patellaluxation", "OSG#", "OSG# offen", "Fuß Amputation" };
                string[] DIAGhand = { "Handgelenk#", "Handgelenk# offen", "Hand#", "Hand# offen", "Hand Amputation" };
                string[] DIAGabdomen = { "stumpfes Abdominaltrauma", "Abdominaltrauma offen", "penetrierendes Abdominaltrauma", "Abwehrspannung Abdomen", "Prellmarke Abdomen" };
                string[] DIAGthorax = { "stumpfes Thoraxtrauma", "penetrierendes Thoraxtrauma", "Thoraxtrauma offen", "Sternumprellung", "Sternum#", "Rippen#", "Rippenserien#", "Pneumothorax", "Spannungspneumothorax", "Spannungspneumothorax entlastet", "Hämatothorax" };
                string[] DIAGhead = { "Comotio", "SHT I", "SHT I offen", "SHT II", "SHT II offen", "SHT III", "SHT III offen", "Mittelgesichts#", "wach ansprechbar", "Bewusstlos", "spontanatmend", "intubiert beatmet" };
                string[] DIAGspine = { "HWS Distorsion", "HWS Trauma", "HWS Trauma mit Sensibilitätsstörungen", "BWS Trauma", "BWS Trauma mit Sensibilitätsstörungen", "LWS Trauma", "LWS Trauma mit Sensibilitätsstörungen", "Querschnittsymptomatik" };

                // fill arm
                int i = 0;
                foreach (string x in DIAGarm)
                {
                    await _diagnosisRepository.InsertAsync(
                        new Diagnosis
                        {
                            Category = 0,
                            Injury = DIAGarm[i],
                            Location = "Arm"
                        },
                        autoSave: true
                    );
                    
                    i++;
                }

                // fill thigh
                i = 0;
                foreach (string x in DIAGthigh)
                {
                    await _diagnosisRepository.InsertAsync(
                        new Diagnosis
                        {
                            Category = 1,
                            Injury = DIAGthigh[i],
                            Location = "Oberschenkel"
                        },
                        autoSave: true
                    );

                    i++;
                }

                // fill lower leg
                i = 0;
                foreach (string x in DIAGlowerLeg)
                {
                    await _diagnosisRepository.InsertAsync(
                        new Diagnosis
                        {
                            Category = 2,
                            Injury = DIAGlowerLeg[i],
                            Location = "Unterschenkel"
                        },
                        autoSave: true
                    );

                    i++;
                }

                // fill hand
                i = 0;
                foreach (string x in DIAGhand)
                {
                    await _diagnosisRepository.InsertAsync(
                        new Diagnosis
                        {
                            Category = 3,
                            Injury = DIAGhand[i],
                            Location = "Hand"
                        },
                        autoSave: true
                    );

                    i++;
                }

                // fill abdomen
                i = 0;
                foreach (string x in DIAGabdomen)
                {
                    await _diagnosisRepository.InsertAsync(
                        new Diagnosis
                        {
                            Category = 4,
                            Injury = DIAGabdomen[i],
                            Location = "Abdomen"
                        },
                        autoSave: true
                    );

                    i++;
                }

                // fill thorax
                i = 0;
                foreach (string x in DIAGthorax)
                {
                    await _diagnosisRepository.InsertAsync(
                        new Diagnosis
                        {
                            Category = 5,
                            Injury = DIAGthorax[i],
                            Location = "Thorax"
                        },
                        autoSave: true
                    );

                    i++;
                }

                // fill head
                i = 0;
                foreach (string x in DIAGhead)
                {
                    await _diagnosisRepository.InsertAsync(
                        new Diagnosis
                        {
                            Category = 6,
                            Injury = DIAGhead[i],
                            Location = "Kopf"
                        },
                        autoSave: true
                    );

                    i++;
                }

                // fill spine
                i = 0;
                foreach (string x in DIAGspine)
                {
                    await _diagnosisRepository.InsertAsync(
                        new Diagnosis
                        {
                            Category = 7,
                            Injury = DIAGspine[i],
                            Location = "Wirbelsäule"
                        },
                        autoSave: true
                    );

                    i++;
                }
            }
        }
    }
}