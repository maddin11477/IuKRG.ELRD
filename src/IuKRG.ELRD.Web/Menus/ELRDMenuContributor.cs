using System.Threading.Tasks;
using IuKRG.ELRD.Localization;
using IuKRG.ELRD.MultiTenancy;
using IuKRG.ELRD.Permissions;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace IuKRG.ELRD.Web.Menus
{
    public class ELRDMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<ELRDResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(ELRDMenus.Home, l["Menu:Home"], "~/"));

            var baseDataMneu = new ApplicationMenuItem(
                        "Basedata",
                        l["Menu:BaseData"],
                        icon: "fa fa-book"
            );

            context.Menu.AddItem(baseDataMneu);

            if (await context.IsGrantedAsync(ELRDPermissions.Units.Default))
            {
                baseDataMneu.AddItem(
                    new ApplicationMenuItem(
                        "Basedata.Units",
                        l["Menu:BaseUnits"],
                        url: "/Units"
                        )
                );
            }

            if (await context.IsGrantedAsync(ELRDPermissions.Hospitals.Default))
            {
                baseDataMneu.AddItem(
                    new ApplicationMenuItem(
                        "Basedata.Hospitals",
                        l["Menu:BaseHospitals"],
                        url: "/Hospitals"
                        )
                );
            }
        }
    }
}
