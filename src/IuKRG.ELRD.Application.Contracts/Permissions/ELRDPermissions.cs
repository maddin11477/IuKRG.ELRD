namespace IuKRG.ELRD.Permissions
{
    public static class ELRDPermissions
    {
        public const string GroupName = "ELRD";


        //Eigene Klassen für Rechtesteuerung
        public static class Units
        {
            public const string Default = GroupName + ".Units";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Hospitals
        {
            public const string Default = GroupName + ".Hospitals";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}