namespace IuKRG.ELRD.Permissions
{
    public static class ELRDPermissions
    {
        public const string GroupName = "ELRD";


        // own classes for permissions
        public static class Basedata
        {
            public const string Default = GroupName + ".Basedata";
            public const string UnitCU = Default + ".UnitCU";
            public const string UnitD = Default + ".UnitD";
            public const string HospitalCU = Default + ".HospitalCU";
            public const string HospitalD = Default + ".HospitalD";
            public const string DiagnosisCU = Default + ".DiagnosisCU";
            public const string DiagnosisD = Default + ".DiagnosisD";
        }
    }
}