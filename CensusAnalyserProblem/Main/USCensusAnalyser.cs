using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem.Main
{
    public class USCensusAnalyser
    {
        string[] usCensusRecords;
        public string[] loadUsCensusData(string headers, string usCSVFilePath)
        {
            if (!File.Exists(usCSVFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(usCSVFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect File Format", CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT);
            }
            usCensusRecords = File.ReadAllLines(usCSVFilePath);
            if (usCensusRecords[0] != headers)
            {
                throw new CensusAnalyserException("Incorrect Headers", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            foreach (string usRecord in usCensusRecords)
            {
                if (!usRecord.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
            }
            return usCensusRecords.Skip(1).ToArray();
        }
    }
}
