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
}
