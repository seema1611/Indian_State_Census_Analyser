using CensusAnalyserProblem;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using static CensusAnalyserProblem.SortType;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        //Indian State Data
        static string csvFilePath = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        static string invalidCsvFilePath = @"D:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        static string nonCSVFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.cs";
        static string wrongDelemeterFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectDelimeters.csv";
        static string wrongHeaderFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";
        static string SortedindiaStateCensusData = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\SortedindiaStateCensusData.csv";

        //Indian State Code
        static string indianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";
        static string wrongIndianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectIndiaStateCode.csv";
        static string SortedindiaStateCensusCode = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\SortedindiaStateCensusCode.csv";

        //Headers
        static string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";


        CensusAnalyser censusAnalyser = new CensusAnalyser();

        [SetUp]
        public void Setup()
        {
        }

        //Indian StateCode Data
        //<--------------------UC-1-------------------->
        //TC-1.1
        [Test]
        public void GivenIndianCensusDataCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<string, IndianCensusDAO> indianCensusRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            Assert.AreEqual(29, indianCensusRecord.Count);
        }

        //TC-1.2
        [Test]
        public void GivenIndianCensusDataCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, invalidCsvFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.type);
        }

        //TC-1.3
        [Test]
        public void GivenIndianCensusDataCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, nonCSVFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, customException.type);
        }

        //TC-1.4
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, wrongDelemeterFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.type);
        }

        //TC-1.5
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, wrongHeaderFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.type);
        }

        //<---------------Indian StateCode Code--------------->
        //<--------------------UC-2-------------------->
        //TC-2.1
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<string, IndianCensusDAO> indianStateCodeList = censusAnalyser.loadIndianCensusData(indianStateCodeHeader, indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeList.Count);
        }

        //TC-2.2
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadIndianCensusData(indianStateCodeHeader, invalidCsvFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.type);
        }

        //TC-2.3
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadIndianCensusData(indianStateCodeHeader, nonCSVFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, customException.type);
        }

        //TC-2.4
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadIndianCensusData(indianStateCodeHeader, wrongIndianStateCodeFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.type);
        }

        //TC-2.5
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadIndianCensusData(indianStateCodeHeader, wrongHeaderFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.type);
        }

        //<--------------------UC-3-------------------->
        //TC-3.1
        [Test]
        public void givenCSVData_WhenSort_ShouldReturnSortedFirstDataInJsonFormat()
        {
            Dictionary<string, IndianCensusDAO> indianCensusRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianCensusRecord, SortType.SortBy.STATE_ASCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Andhra Pradesh", indianCensusSortedList[0].state);
        }

        //TC-3.2
        [Test]
        public void givenCSVData_WhenSort_ShouldReturnSortedLastDataInJsonFormat()
        {
            Dictionary<string, IndianCensusDAO> indianCensusRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianCensusRecord, SortType.SortBy.STATE_ASCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("West Bengal", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }

        //<--------------------UC-4-------------------->
        //TC-4.1
        [Test]
        public void givenCSVData_WhenSortByStateCode_ShouldReturnSortedLastDataInJsonFormat()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianStateCodeHeader, indianStateCodeFile);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.STATE_CODE_ASCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("AD", indianCensusSortedList[0].stateCode);
        }

        //TC-4.2
        [Test]
        public void givenIndianDataCodeCSVFile_Whenloaded_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianStateCodeHeader, indianStateCodeFile);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.STATE_CODE_ASCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("WB", indianCensusSortedList[indianCensusSortedList.Count - 1].stateCode);
        }

        //<--------------------UC-5-------------------->
        //TC-5.1
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousState()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.POPULATION_DESCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Uttar Pradesh", indianCensusSortedList[0].state);
        }

    }
}