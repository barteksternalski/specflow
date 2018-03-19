using System.Collections.Generic;

namespace specflowPoC.TestDataObjects
{
    class GetModule22Object
    {
        public GetData data { get; set; }
    }

    public class GetInput
    {
        public string waterFlowRate { get; set; }
        public string gasFlowRate { get; set; }
        public string oilFlowRate { get; set; }
        public int waterDensity { get; set; }
        public int gasDensity { get; set; }
        public int oilDensity { get; set; }
        public int gasViscosity { get; set; }
    }

    public class GetResult
    {
        public string effectiveDensity { get; set; }
        public string effectiveVelocity { get; set; }
        public string supportArrangement { get; set; }
        public string likelihoodOfFailure { get; set; }
        public string fv { get; set; }
        public int fvf { get; set; }
    }

    public class GetData
    {
        public int mainPipeOutsideDiameter { get; set; }
        public int mainPipeInsideDiameter { get; set; }
        public int mainPipeSpanLength { get; set; }
        public List<GetInput> inputs { get; set; }
        public List<GetResult> results { get; set; }
    }

}
