using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        string[] csvFileData;

        public string[] loadCSVFileData(string headers,string csvFilePath)
        {
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect File Format", CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT);
            }
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            csvFileData = File.ReadAllLines(csvFilePath);
            if (csvFileData[0] != headers)
            {
                throw new CensusAnalyserException("Incorrect Headers", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            foreach (string record in csvFileData.Skip(1))
            {
                if (!record.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
            }
            return csvFileData.Skip(1).ToArray();
        }
    }
}
