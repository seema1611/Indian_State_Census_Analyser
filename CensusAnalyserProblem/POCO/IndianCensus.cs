using CsvHelper.Configuration.Attributes;

namespace CensusAnalyserProblem
{
    public class IndianCensus
    {
        [Name("State")]
        public string state { get; set; }

        [Name("Population")]
        public int population { get; set; }

        [Name("AreaInSqKm")]
        public int totalArea { get; set; }

        [Name("DensityPerSqKm")]
        public int populationDensity { get; set; }
        
    }
}
