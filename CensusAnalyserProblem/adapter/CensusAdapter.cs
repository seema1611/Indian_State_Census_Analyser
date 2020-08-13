/******************************************************
 * @purpose : Census Adapter is used for two classes
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 13/08/2020
 ******************************************************/

using Newtonsoft.Json;
using static CensusAnalyserProblem.SortingOrder;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System;
using CensusAnalyserProblem.Main;

namespace CensusAnalyserProblem
{
    public class CensusAdapter : CensusAnalyserAdapter
    {
        public override Dictionary<object, CensusDAO> LoadCensusData<T>(Country country, string headers, string csvFilePath)
        {
            if (country == Country.INDIA)
                return new IndianCensusLoader().LoadIndianCensusData<T>(headers, csvFilePath);
            return new UsCensusLoader().LoadUsCensusData<T>(headers, csvFilePath);
        }
    }
}