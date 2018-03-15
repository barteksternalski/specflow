using System.Collections.Generic;

namespace specflowPoC.TestDataObjects
{
    class CreateProjectRequestPayloadObject
    {
        public NewProject project { get; set; }
    }

    public class NewSubEquipment
    {
        public string name { get; set; }
    }

    public class NewEquipment
    {
        public string name { get; set; }
        public List<NewSubEquipment> subEquipment { get; set; }
    }

    public class NewProject
    {
        public int pvtDataId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int numberOfCases { get; set; }
        public List<NewEquipment> equipment { get; set; }
    }

    public class CreateProjectPlaceholder
    {
        public int pvtDataId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int numberOfCases { get; set; }
        public int equipments { get; set; }
        public int subEquipments { get; set; }
    }


}
