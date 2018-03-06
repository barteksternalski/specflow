using System.Collections.Generic;

namespace specflowPoC.TestDataObjects
{
    class CreateProjectRequestPayloadObject
    {
        public NewProject project { get; set; }
    }

    public class NewProject
    {
        public int pvtDataId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int numberOfCases { get; set; }
        public List<CreateEquipment> equipments { get; set; }
    }

    public class CreateEquipment
    {
        public string name { get; set; }
        public List<CreateSubEquipment> subEquipments { get; set; }
    }

    public class CreateSubEquipment
    {
        public string name { get; set; }
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
