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

            // basedata
            var basDataPermission = elrdGroup.AddPermission(ELRDPermissions.Basedata.Default, L("Permission:Basedata"));
            basDataPermission.AddChild(ELRDPermissions.Basedata.UnitCU, L("Permission:Basedata.UnitCU"));
            basDataPermission.AddChild(ELRDPermissions.Basedata.UnitD, L("Permission:Basedata.UnitD"));
            basDataPermission.AddChild(ELRDPermissions.Basedata.HospitalCU, L("Permission:Basedata.HospitalCU"));
            basDataPermission.AddChild(ELRDPermissions.Basedata.HospitalD, L("Permission:Basedata.HospitalD"));
            basDataPermission.AddChild(ELRDPermissions.Basedata.DiagnosisCU, L("Permission:Basedata.DiagnosisCU"));
            basDataPermission.AddChild(ELRDPermissions.Basedata.DiagnosisD, L("Permission:Basedata.DiagnosisD"));

            // Mission
            var missionPermission = elrdGroup.AddPermission(ELRDPermissions.Mission.Default, L("Permission:Mission"));
            missionPermission.AddChild(ELRDPermissions.Mission.CreateUpdate, L("Permission:Mission.CreateUpdate"));
            missionPermission.AddChild(ELRDPermissions.Mission.Delete, L("Permission:Mission.Delete"));
            missionPermission.AddChild(ELRDPermissions.Mission.Read, L("Permission:Mission.Read"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ELRDResource>(name);
        }
    }
}
