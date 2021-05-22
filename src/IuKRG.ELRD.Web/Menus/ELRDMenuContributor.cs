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

            var baseDataMenu = new ApplicationMenuItem(
                        "Basedata",
                        l["Menu:BaseData"],
                        icon: "fa fa-book"
            );

            context.Menu.AddItem(baseDataMenu);

            if (await context.IsGrantedAsync(ELRDPermissions.Basedata.Default))
            {
                baseDataMenu.AddItem(
                    new ApplicationMenuItem(
                        "Basedata.Units",
                        l["Menu:BaseUnits"],
                        url: "/Units"
                        )
                );
            }

            if (await context.IsGrantedAsync(ELRDPermissions.Basedata.Default))
            {
                baseDataMenu.AddItem(
                    new ApplicationMenuItem(
                        "Basedata.Hospitals",
                        l["Menu:BaseHospitals"],
                        url: "/Hospitals"
                        )
                );
            }

            if (await context.IsGrantedAsync(ELRDPermissions.Basedata.Default))
            {
                baseDataMenu.AddItem(
                    new ApplicationMenuItem(
                        "Basedata.Diagnoses",
                        l["Menu:BaseDiagnoses"],
                        url: "/Diagnoses"
                        )
                );
            }


            //Mission Menu Generation

            var MissionMenu = new ApplicationMenuItem(
                            "Mission",
                            l["Menu:Mission"],
                            icon: "fa fa-ambulance",
                            url: "/Missions"
            );

            if (await context.IsGrantedAsync(ELRDPermissions.Mission.Default))
            {
                context.Menu.AddItem(MissionMenu);
            }
        }
    }
}
