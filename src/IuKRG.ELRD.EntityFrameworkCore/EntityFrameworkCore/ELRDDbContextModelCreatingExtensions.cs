using IuKRG.ELRD.Units;
using IuKRG.ELRD.Hospitals;
using IuKRG.ELRD.Diagnoses;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using IuKRG.ELRD.Missions;

namespace IuKRG.ELRD.EntityFrameworkCore
{
    public static class ELRDDbContextModelCreatingExtensions
    {
        public static void ConfigureELRD(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            // basedata units
            builder.Entity<Unit>(u =>
            {
                u.ToTable(ELRDConsts.DbTablePrefix + "Units",
                          ELRDConsts.DbSchema);
                u.ConfigureByConvention(); // auto configure for the base class props
                u.Property(x => x.Callsign).IsRequired().HasMaxLength(256);
            });

            // basedata hospitals
            builder.Entity<Hospital>(u =>
            {
                u.ToTable(ELRDConsts.DbTablePrefix + "Hospitals",
                          ELRDConsts.DbSchema);
                u.ConfigureByConvention(); // auto configure for the base class props
                u.Property(x => x.Name).IsRequired().HasMaxLength(256);
            });

            // basedata diagnoses
            builder.Entity<Diagnosis>(u =>
            {
                u.ToTable(ELRDConsts.DbTablePrefix + "Diagnoses",
                          ELRDConsts.DbSchema);
                u.ConfigureByConvention(); // auto configure for the base class props
            });

            //Mission builder
            builder.Entity<Mission>(u =>
            {
                u.ToTable(ELRDConsts.DbTablePrefix + "Missions",
                          ELRDConsts.DbSchema);
                u.ConfigureByConvention();

            });
        }
    }
}