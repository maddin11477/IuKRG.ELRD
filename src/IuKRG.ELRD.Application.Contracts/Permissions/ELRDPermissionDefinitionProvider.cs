using IuKRG.ELRD.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace IuKRG.ELRD.Permissions
{
    public class ELRDPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var elrdGroup = context.AddGroup(ELRDPermissions.GroupName, L("Permission:ELRD"));

            //eigene Rechte für Rechtesteuerung
            var booksPermission = elrdGroup.AddPermission(ELRDPermissions.Units.Default, L("Permission:Units"));
            booksPermission.AddChild(ELRDPermissions.Units.Create, L("Permission:Units.Create"));
            booksPermission.AddChild(ELRDPermissions.Units.Edit, L("Permission:Units.Edit"));
            booksPermission.AddChild(ELRDPermissions.Units.Delete, L("Permission:Units.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ELRDResource>(name);
        }
    }
}
