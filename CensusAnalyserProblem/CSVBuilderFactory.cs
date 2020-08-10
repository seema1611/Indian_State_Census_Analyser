using CensusAnalyzerProblem;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
   public class CSVBuilderFactory
    {
        public ICSVBuilder CreateObject(string ClassName,string csvFilePath, string headers)
        {
          //  string path, header;
            if (ClassName== "CensusAnalyser")
            {
                return new CensusAnalyser(csvFilePath, headers);
            }
            return null;
        }

    }
 
}
