/******************************************************************
 * @purpose : Interface CSVBuilder is used to defined the methods
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 10/08/2020
 ******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
   public interface ICSVBuilder
    {
        public Dictionary<string, IndianCensusDAO> GetCSVFileData(string headers, string csvFilePath);
    }
}
