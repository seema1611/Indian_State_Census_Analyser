using CensusAnalyserProblem;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using static CensusAnalyserProblem.SortingOrder;
using CensusAnalyserProblem.Main;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        //Headers
        static string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        static string usCensusDataHeaders = "StateId,State,Population,HousingUnits,TotalArea,WaterArea,LandArea,PopulationDensity,HousingDensity";

        //Indian State Data
        static string csvFilePath = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        static string invalidCsvFilePath = @"D:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        static string nonCSVFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.cs";
        static string wrongDelemeterFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectDelimeters.csv";
        static string wrongHeaderFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";

        //Indian State Code
        static string indianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";
        static string wrongIndianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectIndiaStateCode.csv";

        //US Census Data
        static string usCSVFilePath = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\USCensusData.csv";
        static string invalidUSCsvFilePath = @"D:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\USCensusData.csv";
        static string nonUSCSVFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\USCensusData.cs";
        static string wrongUSDelemeterFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectUSDelimeters.csv";
        static string wrongUSHeaderFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectUSHeaders.csv";

        CensusAnalyser censusAnalyser = new CensusAnalyser();
        USCensusAnalyser usCensusAnalyser = new USCensusAnalyser();


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
        public void GivenIndianStateCSVData_WhenSort_ShouldReturnSortedFirstDataInJsonFormat()
        {
            Dictionary<string, IndianCensusDAO> indianCensusRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianCensusRecord, SortingOrder.SortBy.STATE_ASCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Andhra Pradesh", indianCensusSortedList[0].state);
        }

        //TC-3.2
        [Test]
        public void GivenIndianStateCSVData_WhenSort_ShouldReturnSortedLastDataInJsonFormat()
        {
            Dictionary<string, IndianCensusDAO> indianCensusRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianCensusRecord, SortingOrder.SortBy.STATE_ASCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("West Bengal", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }

        //<--------------------UC-4-------------------->
        //TC-4.1
        [Test]
        public void GivenIndianStateCSVData_WhenSortByStateCode_ShouldReturnSortedLastDataInJsonFormat()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianStateCodeHeader, indianStateCodeFile);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortingOrder.SortBy.STATE_CODE_ASCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("AD", indianCensusSortedList[0].stateCode);
        }

        //TC-4.2
        [Test]
        public void GivenIndianDataCodeCSVFile_Whenloaded_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianStateCodeHeader, indianStateCodeFile);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortingOrder.SortBy.STATE_CODE_ASCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("WB", indianCensusSortedList[indianCensusSortedList.Count - 1].stateCode);
        }

        //<--------------------UC-5-------------------->
        //TC-5.1
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsMostPopulousState()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortingOrder.SortBy.POPULATION_DESCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Uttar Pradesh", indianCensusSortedList[0].state);
        }

        //TC-5.2
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsLeastPopulousState()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortingOrder.SortBy.POPULATION_DESCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Sikkim", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }


        //<--------------------UC-6-------------------->
        //TC-6.1
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsMostPopulousStateBasedOnDensityPerSqm()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortingOrder.SortBy.POPULATION_DENSITY_DESCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Bihar", indianCensusSortedList[0].state);
        }

        //TC-6.2
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsLeastPopulousStateBasedOnDensityPerSqm()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortingOrder.SortBy.POPULATION_DENSITY_DESCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Arunachal Pradesh", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }

        //<--------------------UC-7-------------------->
        //TC-7.1
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsMostPopulousStateBasedOnAreaPerSqm()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortingOrder.SortBy.AREA_PER_SQM_DESCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Rajasthan", indianCensusSortedList[0].state);
        }

        //TC-7.2
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsLeastPopulousStateBasedOnAreaPerSqm()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortingOrder.SortBy.AREA_PER_SQM_DESCENDING);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Goa", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }

        //<---------------US Census Data--------------->
        //<--------------------UC-8-------------------->
        //TC-8.1
        [Test]
        public void GivenUSCensusCSVFile__WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            string[] totalUSRecord = usCensusAnalyser.loadUsCensusData(usCensusDataHeaders, usCSVFilePath);
            Assert.AreEqual(51, totalUSRecord.Length);
        }

        //TC-8.2
        [Test]
        public void GivenUSCensusDataCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => usCensusAnalyser.loadUsCensusData(usCensusDataHeaders, invalidUSCsvFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.type);
        }

        //TC-8.3
        [Test]
        public void GivenUSCensusDataCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => usCensusAnalyser.loadUsCensusData(usCensusDataHeaders, nonUSCSVFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, customException.type);
        }

        //TC-8.4
        [Test]
        public void GivenUSCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => usCensusAnalyser.loadUsCensusData(usCensusDataHeaders, wrongUSDelemeterFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.type);
        }

        //TC-8.5
        [Test]
        public void GivenUSCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => usCensusAnalyser.loadUsCensusData(usCensusDataHeaders, wrongUSHeaderFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.type);
        }
    }
}