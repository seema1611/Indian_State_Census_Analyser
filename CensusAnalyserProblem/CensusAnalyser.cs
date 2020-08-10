using CensusAnalyzerProblem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser : ICSVBuilder
    {
        public delegate object CSVData();
        //string[] csvFileData;
        string csvFilePath;
        string headers;
        int count = 0;
        Dictionary<int, string> dataDictionary = new Dictionary<int, string>();

        public CensusAnalyser(string csvFilePath, string headers)
        {
            this.csvFilePath = csvFilePath;
            this.headers = headers;
        }

        public object loadCSVFileData()
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
            List<string> list = csvFileData.ToList();

            if (csvFileData[0] != headers)
            {
                throw new CensusAnalyserException("Incorrect Headers", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            foreach (string record in list)
            {
                count++;
                dataDictionary.Add(count, record);
                if (!record.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
            }
            return dataDictionary.Skip(1).ToDictionary(d => d.Key, d => d.Value);
        }

        public string sortingCSVData(string csvFilePath, string newPath, int number)
        {
            string[] csvFileData = File.ReadAllLines(csvFilePath);
            var details = csvFileData.Skip(1);
            IEnumerable<string> query =
            from line in details
            let x = line.Split(',')
            orderby x[number]
            select line;
            File.WriteAllLines(newPath, csvFileData.Take(1).Concat(query.ToArray()));
            List<string> sorted = query.ToList<string>();
            return JsonConvert.SerializeObject(sorted);
        }
    }
}