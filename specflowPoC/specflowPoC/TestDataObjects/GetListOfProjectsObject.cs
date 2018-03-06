using System;
using System.Collections.Generic;

namespace specflowPoC.TestDataObjects
{
    class GetListOfProjectsObject
    {
        public List<ProjectListing> projects { get; set; }
    }

    public class ProjectListing
    {
        public Int64 id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime lastModifiedOn { get; set; }
        public string lastModifiedBy { get; set; }
    }

}
