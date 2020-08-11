using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
   public class IndianCensusDAO
    {
        public int areaInSqkm;
        public String state;
        public int population;
        public int densityPerSqKm;
        public int srNo;
        public int TIN;
        public string stateCode;

        public IndianCensusDAO(){ }
        public IndianCensusDAO(IndianCensus indianCensusCSV)
        {
            state = indianCensusCSV.state;
            areaInSqkm = indianCensusCSV.totalArea;
            population = indianCensusCSV.population;
            densityPerSqKm = indianCensusCSV.populationDensity;
        }

        public IndianCensusDAO(IndianStateCode indianStateCode)
        {
            srNo = indianStateCode.srNo;
            state = indianStateCode.state;
            TIN = indianStateCode.TIN;
            stateCode = indianStateCode.stateCode;
        }

    }
}
