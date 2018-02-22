namespace specflowPoC.TestDataObjects
{
    public class FIERequestPayloadObject
    {
        public FIEInput input { get; set; }
    }

    public class FIEInput
    {
        public int insideDiameter { get; set; }
        public int length { get; set; }
        public int waterFlowRate { get; set; }
        public int gasFlowRate { get; set; }
        public int oilFlowRate { get; set; }
        public int waterDensity { get; set; }
        public int gasDensity { get; set; }
        public int oilDensity { get; set; }
        public int mainBranchID { get; set; }
        public int gasViscosity { get; set; }
        public int speedOfSound { get; set; }
    }
}
