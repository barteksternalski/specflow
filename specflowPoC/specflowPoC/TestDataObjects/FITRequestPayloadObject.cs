namespace specflowPoC.TestDataObjects
{
    class FITRequestPayloadObject
    {
        public FITInput input { get; set; }
    }

    public class FITInput
    {
        public int waterFlowRate { get; set; }
        public int gasFlowRate { get; set; }
        public int oilFlowRate { get; set; }
        public int mainPipeOutsideDiameter { get; set; }
        public int mainPipeInsideDiameter { get; set; }
        public int mainPipeSpanLength { get; set; }
        public int waterDensity { get; set; }
        public int gasDensity { get; set; }
        public int oilDensity { get; set; }
        public int gasViscosity { get; set; }
    }
}
