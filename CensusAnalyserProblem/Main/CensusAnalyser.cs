using Newtonsoft.Json;
using static CensusAnalyserProblem.SortingOrder;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        ICSVBuilder cSVBuilder = CSVBuilderFactory.CreateCSVReader();
        public Dictionary<string, IndianCensusDAO> loadIndianCensusData(string headers, string csvFilePath)
        {
            return cSVBuilder.GetCSVFileData(headers, csvFilePath);
        }

        public string SortAndConvertCensusToJson(Dictionary<string, IndianCensusDAO> dictionary, SortBy sortType)
        {
            List<IndianCensusDAO> sortedList = SortingOrder.SortIndianCensusData(dictionary.Select(x => x.Value).ToList(), sortType);
            return JsonConvert.SerializeObject(sortedList);
        }
    }
}