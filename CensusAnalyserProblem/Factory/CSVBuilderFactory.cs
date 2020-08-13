/************************************************************************************
 * @purpose : CSVBuilder Factory is used to create object without exposing the logic
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 10/08/2020
 ************************************************************************************/

using CensusAnalyserProblem;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
   public class CSVBuilderFactory
    {
        public static ICSVBuilder CreateCSVReader()
        {
            return new CensusDataAnalyser();
        }
    } 
}
