/**********************************************************************
 * @purpose : Indian Census Loader is used to load and convert data 
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 07/08/2020
 **********************************************************************/

using Newtonsoft.Json;
using static CensusAnalyserProblem.SortingOrder;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CensusAnalyserProblem
{
    public class IndianCensusLoader
    {
        ICSVBuilder indianCSVBuilder = CSVBuilderFactory.CreateCSVReader();

        public Dictionary<object, CensusDAO> LoadIndianCensusData<T>(string headers, string csvFilePath)
        {
            return indianCSVBuilder.ReadCSVFile<T>(headers, csvFilePath);
        }
    }
}