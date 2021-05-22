using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace IuKRG.ELRD.Missions
{
    public class Mission : FullAuditedAggregateRoot<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartKM { get; set; }
        public int EndKM { get; set; }
        public bool IsFinished { get; set; }
        public int MissionTaskNumber { get; set; }
        public string Location { get; set; }
        public string MissionType { get; set; }
        public string Reason { get; set; }
        public string Comment { get; set; }
        public Guid UserGuid { get; set; }
    }
}

//<attribute name="dbID" optional="YES" attributeType="Integer 32" defaultValueString="-1" usesScalarValueType="YES"/>
//**<attribute name="end" optional="YES" attributeType="Date" usesScalarValueType="NO"/>
//**<attribute name="endKm" optional="YES" attributeType="String"/>
//<attribute name="id" optional="YES" attributeType="Integer 16" defaultValueString="0" usesScalarValueType="YES"/>
//**<attribute name="isFinished" optional="YES" attributeType="Boolean" usesScalarValueType="YES"/>
//**<attribute name="location" optional="YES" attributeType="String"/>
//**<attribute name="missionTaskNumber" optional="YES" attributeType="Integer 32" defaultValueString="-1" usesScalarValueType="YES"/>
//**<attribute name="missionType" optional="YES" attributeType="String"/>
//**<attribute name="reason" optional="YES" attributeType="String"/>
//**<attribute name="start" optional="YES" attributeType="Date" usesScalarValueType="NO"/>
//**<attribute name="startKm" optional="YES" attributeType="String"/>
//<attribute name="unique" attributeType="String"/>
//<relationship name="baseMapOverlays" optional="YES" toMany="YES" deletionRule="Nullify" destinationEntity="BaseMapOverlay" inverseName="mission" inverseEntity="BaseMapOverlay"/>
//<relationship name="documentations" optional="YES" toMany="YES" deletionRule="Nullify" destinationEntity="Documentation" inverseName="mission" inverseEntity="Documentation"/>
//<relationship name="notifications" optional="YES" toMany="YES" deletionRule="Nullify" destinationEntity="Notification"/>
//<relationship name="overlays" optional="YES" toMany="YES" deletionRule="Nullify" destinationEntity="MapOverlay"/>
//<relationship name="sections" optional="YES" toMany="YES" deletionRule="Nullify" destinationEntity="Section" inverseName="mission" inverseEntity="Section"/>
//<relationship name="user" optional="YES" maxCount="1" deletionRule="Nullify" destinationEntity="User" inverseName="missions" inverseEntity="User"/>
//<relationship name="victims" optional="YES" toMany="YES" deletionRule="Nullify" destinationEntity="Victim" inverseName="mission" inverseEntity="Victim"/>

