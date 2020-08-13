/******************************************************************************
 * @purpose : CSV Data Reader class is used to load Data and code and sorting
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 1108/2020
 ******************************************************************************/

using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CensusDataAnalyser : ICSVBuilder
    {
        public Dictionary<object, CensusDAO> ReadCSVFile<T>(string headers, string csvFilePath)
        {
            try
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
                    if (!record.Contains(","))
                        throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER); using (var readers = new StreamReader(csvFilePath, Encoding.Default))
                using (var csv = new CsvReader(readers, System.Globalization.CultureInfo.CurrentCulture))
                    return csv.GetRecords<T>().ToList().ToDictionary(x => x.GetType().GetProperty("state").GetValue(x, null), x => CensusDAO.getDAO(x));
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message);
            }
        }
    }
}