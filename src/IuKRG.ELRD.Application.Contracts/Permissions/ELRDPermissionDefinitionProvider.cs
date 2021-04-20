using IuKRG.ELRD.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace IuKRG.ELRD.Permissions
{
    public class ELRDPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        // own rights for permissions
        public override void Define(IPermissionDefinitionContext context)
        {
            var elrdGroup = context.AddGroup(ELRDPermissions.GroupName, L("Permission:ELRD"));

            // units
            var unitsPermission = elrdGroup.AddPermission(ELRDPermissions.Units.Default, L("Permission:Units"));
            unitsPermission.AddChild(ELRDPermissions.Units.Create, L("Permission:Units.Create"));
            unitsPermission.AddChild(ELRDPermissions.Units.Edit, L("Permission:Units.Edit"));
            unitsPermission.AddChild(ELRDPermissions.Units.Delete, L("Permission:Units.Delete"));

            // hospitals
            var hospitalsPermission = elrdGroup.AddPermission(ELRDPermissions.Hospitals.Default, L("Permission:Hospitals"));
            hospitalsPermission.AddChild(ELRDPermissions.Hospitals.Create, L("Permission:Hospitals.Create"));
            hospitalsPermission.AddChild(ELRDPermissions.Hospitals.Edit, L("Permission:Hospitals.Edit"));
            hospitalsPermission.AddChild(ELRDPermissions.Hospitals.Delete, L("Permission:Hospitals.Delete"));

            // diagnoses
            var diagnosesPermission = elrdGroup.AddPermission(ELRDPermissions.Diagnoses.Default, L("Permission:Diagnoses"));
            diagnosesPermission.AddChild(ELRDPermissions.Diagnoses.Create, L("Permission:Diagnoses.Create"));
            diagnosesPermission.AddChild(ELRDPermissions.Diagnoses.Edit, L("Permission:Diagnoses.Edit"));
            diagnosesPermission.AddChild(ELRDPermissions.Diagnoses.Delete, L("Permission:Diagnoses.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ELRDResource>(name);
        }
    }
}
