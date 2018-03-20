namespace specflowPoC.TestDataObjects
{
    public class FIERequestPayloadObject
    {
        public FIEInput input { get; set; }
    }

    public class FIEInput
    {
        public double insideDiameter { get; set; }
        public double length { get; set; }
        public double waterFlowRate { get; set; }
        public double gasFlowRate { get; set; }
        public double oilFlowRate { get; set; }
        public double waterDensity { get; set; }
        public double gasDensity { get; set; }
        public double oilDensity { get; set; }
        public double mainBranchID { get; set; }
        public double gasViscosity { get; set; }
        public double speedOfSound { get; set; }
    }

    class FIEResponsePayloadObject
    {
        public FIEResult result { get; set; }
    }

    public class FIEResult
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
}
