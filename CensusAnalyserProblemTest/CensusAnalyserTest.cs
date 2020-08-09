
using CensusAnalyserProblem;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusAnalyser censusAnalyser;
        string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";

        //Indian State Data
        string csvFilePath = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        string invalidCsvFilePath = @"D:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        string nonCSVFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.cs";
        string wrongDelemeterFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectDelimeters.csv";
        string wrongHeaderFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";

        //Indian State Code
        string indianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }

        //Indian StateCode Data
        //UC-1
        //TC-1.1
        [Test]
        public void givenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            IEnumerable<string> indianCensusRecord = censusAnalyser.loadCSVFileData(indianCensusDataHeaders,csvFilePath);
            Assert.AreEqual(29, indianCensusRecord.Count());
        }

        //TC-1.2
        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, invalidCsvFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        //TC-1.3
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, nonCSVFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        //TC-1.4
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, wrongDelemeterFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        //TC-1.5
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, wrongHeaderFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, error.type);
        }

        //Indian StateCode Code
        //UC-2
        //TC-2.1
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            IEnumerable<string> indianStateCodeRecord = censusAnalyser.loadCSVFileData(indianStateCodeHeader, indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeRecord.Count());
        }
    }
}