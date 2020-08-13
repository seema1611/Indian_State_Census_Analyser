/*********************************************************
 * @purpose : US Census loader is used to load US data
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 07/08/2020
 *********************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem.Main
{
    public class UsCensusLoader
    {
        ICSVBuilder usCSVBuilder = CSVBuilderFactory.CreateCSVReader();

        public Dictionary<object, CensusDAO> LoadUsCensusData<T>(string headers, string csvFilePath)
        {
            return usCSVBuilder.ReadCSVFile<T>(headers, csvFilePath);
        }
    }
}