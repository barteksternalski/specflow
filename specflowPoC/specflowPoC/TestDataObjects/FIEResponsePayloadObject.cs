namespace specflowPoC.TestDataObjects
{
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
