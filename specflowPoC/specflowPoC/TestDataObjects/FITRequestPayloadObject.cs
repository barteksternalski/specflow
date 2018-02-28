namespace specflowPoC.TestDataObjects
{
    class FITRequestPayloadObject
    {
        public FITInput input { get; set; }
    }

    public class FITInput
    {
        public double waterFlowRate { get; set; }
        public double gasFlowRate { get; set; }
        public double oilFlowRate { get; set; }
        public double mainPipeOutsideDiameter { get; set; }
        public double mainPipeInsideDiameter { get; set; }
        public double mainPipeSpanLength { get; set; }
        public double waterDensity { get; set; }
        public double gasDensity { get; set; }
        public double oilDensity { get; set; }
        public double gasViscosity { get; set; }
    }
}
