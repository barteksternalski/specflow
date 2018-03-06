namespace specflowPoC.TestDataObjects
{
    class AspectsDetailsObject
    {
        public Aspects aspects { get; set; }
    }

    public class Aspects
    {
        public double maxKineticEnergy { get; set; }
        public string maxKineticEnergyComment { get; set; }
        public bool module2_7Enabled { get; set; }
        public string module2_7Comment { get; set; }
        public bool module2_9Enabled { get; set; }
        public string module2_9Comment { get; set; }
        public bool module2_8Enabled { get; set; }
        public string module2_8Comment { get; set; }
        public bool module4Enabled { get; set; }
        public string module4Comment { get; set; }
    }

}
