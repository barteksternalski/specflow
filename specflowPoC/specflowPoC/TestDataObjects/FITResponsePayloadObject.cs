namespace specflowPoC.TestDataObjects
{
    class FITResponsePayloadObject
    {
        public FITResult result { get; set; }
    }

    public class FITResult
    {
        public double effectiveDensity { get; set; }
        public double effectiveVelocity { get; set; }
        public string supportArrangement { get; set; }
        public string likelihoodOfFailure { get; set; }
        public double fv { get; set; }
        public double fvf { get; set; }
    }

}
