using System.Collections.Generic;

namespace specflowPoC.TestDataObjects
{
    class GetSingleProjecDetailsObject
    {
        public Project project { get; set; }
    }

    public class Project
    {
        public long id { get; set; }
        public long pvtDataId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int numberOfCases { get; set; }
        public List<Equipment> equipment { get; set; }
    }

    public class SubEquipment
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Equipment
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<SubEquipment> subEquipment { get; set; }
    }

}
