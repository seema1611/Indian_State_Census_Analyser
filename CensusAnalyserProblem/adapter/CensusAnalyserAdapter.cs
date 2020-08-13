/********************************************************************
 * @purpose : Census Analyser Adapter is used for two loader classes
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 13/08/2020
 ********************************************************************/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static CensusAnalyserProblem.SortingOrder;

namespace CensusAnalyserProblem
{
    public abstract class CensusAnalyserAdapter
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        public abstract Dictionary<object, CensusDAO> LoadCensusData<T>(Country country, string headers, string csvFilePath);
        public string SortAndConvertCensusToJson(Dictionary<object, CensusDAO> dictionary, DTO dto, SortBy sortType, SortOrder sortOrder)
        {
            string sortFieldTitleCase = textInfo.ToTitleCase(sortType.ToString().ToLower()).Replace("_", string.Empty);
            string sortField = Char.ToLowerInvariant(sortFieldTitleCase[0]) + sortFieldTitleCase.Substring(1);
            var sortedList = SortingOrder.SortCensusData(dictionary.Select(x => x.Value).ToList(), sortField, sortOrder).Select(x => x.getDTO(dto, x)).ToList();
            return JsonConvert.SerializeObject(sortedList);
        }
        public string GetMostPopulousStateBetweenBoth(IndianCensus indianCensus, USCensus usCensus)
        {
            return indianCensus.populationDensity > usCensus.populationDensity ? indianCensus.state : usCensus.state;
        }
    }
}