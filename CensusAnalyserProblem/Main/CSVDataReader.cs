/******************************************************************************
 * @purpose : Census Analyzer class is used to load Data and code and sorting
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 07/08/2020
 ******************************************************************************/

using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CSVDataReader : ICSVBuilder
    {
        public Dictionary<string, IndianCensusDAO> GetCSVFileData(string headers, string csvFilePath)
        {
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect File Format", CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT);
            }
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            string[] csvFileData = File.ReadAllLines(csvFilePath);
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
            try
            {
                using (var readers = new StreamReader(csvFilePath, Encoding.Default))
                using (var csv = new CsvReader(readers, System.Globalization.CultureInfo.CurrentCulture))
                {
                    if (headers.Contains("State,Population,AreaInSqKm,DensityPerSqKm"))
                    {
                        IndianCensus[] indianCensus = csv.GetRecords<IndianCensus>().ToArray();
                        return indianCensus.ToDictionary(x => x.state, x => new IndianCensusDAO(x));
                    }
                    IndianStateCode[] indianStateCodes = csv.GetRecords<IndianStateCode>().ToArray();
                    return indianStateCodes.ToDictionary(x => x.state, x => new IndianCensusDAO(x));
                }

            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
