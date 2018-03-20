using System.Collections.Generic;

namespace specflowPoC.TestDataObjects
{
    class GetModule22Object
    {
        public Modul22GetData data { get; set; }
    }

    class PutModule22Object
    {
        public Modul22PutData data { get; set; }
    }

    class Module22ResultsObject
    {
        public List<Module22Result> data { get; set; }
    }

    class Module22LoFObject
    {
        public Modul22LoFData data { get; set; }
    }

    public class Module22Input
    {
        public double waterFlowRate { get; set; }
        public double gasFlowRate { get; set; }
        public double oilFlowRate { get; set; }
        public double waterDensity { get; set; }
        public double gasDensity { get; set; }
        public double oilDensity { get; set; }
        public double gasViscosity { get; set; }
    }

    public class Module22Result
    {
        public double effectiveDensity { get; set; }
        public double effectiveVelocity { get; set; }
        public string supportArrangement { get; set; }
        public double likelihoodOfFailure { get; set; }
        public string fv { get; set; }
        public double fvf { get; set; }
    }

    public class Modul22GetData
    {
        public double mainPipeOutsideDiameter { get; set; }
        public double mainPipeInsideDiameter { get; set; }
        public double mainPipeSpanLength { get; set; }
        public List<Module22Input> inputs { get; set; }
        public List<Module22Result> results { get; set; }
    }

    public class Modul22PutData
    {
        public double mainPipeOutsideDiameter { get; set; }
        public double mainPipeInsideDiameter { get; set; }
        public double mainPipeSpanLength { get; set; }
        public List<Module22Input> inputs { get; set; }
    }

    public class Modul22LoFData
    {
        public bool hasLikelihoodOfFailure { get; set; }
        public double maximumLikelihoodOfFailure { get; set; }
        public List<double> likelihoodOfFailureData { get; set; }
    }

    public class Module22Helper
    {
        public double mainPipeOutsideDiameter { get; set; }
        public double mainPipeInsideDiameter { get; set; }
        public double mainPipeSpanLength { get; set; }
    }
}
