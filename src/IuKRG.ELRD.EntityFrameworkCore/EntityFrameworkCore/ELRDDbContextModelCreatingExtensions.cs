using IuKRG.ELRD.Hospitals;
using IuKRG.ELRD.Units;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace IuKRG.ELRD.EntityFrameworkCore
{
    public static class ELRDDbContextModelCreatingExtensions
    {
        public static void ConfigureELRD(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //Stammdaten Fahrzeuge
            builder.Entity<Unit>(u =>
            {
                u.ToTable(ELRDConsts.DbTablePrefix + "Units",
                          ELRDConsts.DbSchema);
                u.ConfigureByConvention(); //auto configure for the base class props
                u.Property(x => x.Callsign).IsRequired().HasMaxLength(256);
            });

            //Stammdaten Kliniken
            builder.Entity<Hospital>(u =>
            {
                u.ToTable(ELRDConsts.DbTablePrefix + "Hospitals",
                          ELRDConsts.DbSchema);
                u.ConfigureByConvention(); //auto configure for the base class props
                u.Property(x => x.Name).IsRequired().HasMaxLength(256);
            });
        }
    }
}