using System.Collections.Generic;

namespace specflowPoC.TestDataObjects
{
    class PrecalcDetailsObject
    {
        public PrecalcData data { get; set; }
    }

    public class ProductionProfileData
    {
        public double pressure { get; set; }
        public double temperature { get; set; }
        public double gasRateAtStandardConditions { get; set; }
        public double oilRateAtStandardConditions { get; set; }
        public double waterRateAtStandardConditions { get; set; }
    }

    public class PrecalcData
    {
        public double standardGasDensity { get; set; }
        public double standardOilDensity { get; set; }
        public double standardWaterDensity { get; set; }
        public int numberOfCases { get; set; }
        public List<ProductionProfileData> productionProfileData { get; set; }
        public List<object> productionProfileDataTable { get; set; }
    }

    public class PrecalcDataHandling
    {
        public double standardGasDensity { get; set; }
        public double standardOilDensity { get; set; }
        public double standardWaterDensity { get; set; }
        public double pressure { get; set; }
        public double temperature { get; set; }
        public double gasRateAtStandardConditions { get; set; }
        public double oilRateAtStandardConditions { get; set; }
        public double waterRateAtStandardConditions { get; set; }
    }

}
