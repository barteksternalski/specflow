using System.Collections.Generic;

namespace specflowPoC.TestDataObjects
{
    class GetModule26Object
    {
        public Module26GetData data { get; set; }
    }

    class PutModule26Object
    {
        public Module26PutData data { get; set; }
    }

    class Module26ResultsObject
    {
        public List<Module26Result> data { get; set; }
    }

    class Module26LoFObject
    {
        public Modul26LoFData data { get; set; }
    }

    public class Module26Input
    {
        public double waterFlowRate { get; set; }
        public double gasFlowRate { get; set; }
        public double oilFlowRate { get; set; }
        public double waterDensity { get; set; }
        public double gasDensity { get; set; }
        public double oilDensity { get; set; }
        public double gasViscosity { get; set; }
        public double speedOfSound { get; set; }
    }

    public class Module26Result
    {
        public double likelihoodOfFailure { get; set; }
        public double effectiveDensity { get; set; }
        public double effectiveVelocity { get; set; }
        public double sideBranchCriticalDiameter { get; set; }
        public double reynoldsNumber { get; set; }
        public double stroudhalNumber { get; set; }
        public double fv { get; set; }
        public double fs { get; set; }
    }

    public class Module26GetData
    {
        public double insideDiameter { get; set; }
        public double length { get; set; }
        public double mainBranchID { get; set; }
        public List<Module26Input> inputs { get; set; }
        public List<Module26Result> results { get; set; }
    }

    public class Module26PutData
    {
        public double insideDiameter { get; set; }
        public double length { get; set; }
        public double mainBranchID { get; set; }
        public List<Module26Input> inputs { get; set; }
    }

    public class Modul26LoFData
    {
        public bool hasLikelihoodOfFailure { get; set; }
        public double maximumLikelihoodOfFailure { get; set; }
        public List<double> likelihoodOfFailureData { get; set; }
    }

    public class Module26Helper
    {
        public double insideDiameter { get; set; }
        public double length { get; set; }
        public double mainBranchID { get; set; }
    }

}
