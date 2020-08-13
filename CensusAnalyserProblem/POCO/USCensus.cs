/***************************************************************************
 * @purpose : US Census class is used for getting and setting Code file
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 12/08/2020
 ***************************************************************************/

using CsvHelper.Configuration.Attributes;

namespace CensusAnalyserProblem
{
    public class USCensus
    {
        [Name("State Id")]
        public string stateId { get; set; }

        [Name("State")]
        public string state { get; set; }

        [Name("Population")]
        public int population { get; set; }

        [Name("Housing units")]
        public int housingUnits { get; set; }

        [Name("Total area")]
        public float totalArea { get; set; }

        [Name("Water area")]
        public float waterArea { get; set; }

        [Name("Land area")]
        public float landArea { get; set; }

        [Name("Population Density")]
        public float populationDensity { get; set; }

        [Name("Housing Density")]
        public float housingDensity { get; set; }
       
    }
}
