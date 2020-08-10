using CensusAnalyserProblem;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static CensusAnalyserProblem.CensusAnalyser;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {

        //Indian State Data
        static string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string csvFilePath = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        static string invalidCsvFilePath = @"D:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        static string nonCSVFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.cs";
        static string wrongDelemeterFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectDelimeters.csv";
        static string wrongHeaderFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";
        static string SortedindiaStateCensusData = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\SortedindiaStateCensusData.csv";

        //Indian State Code
        static string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";
        static string wrongIndianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        CSVBuilderFactory cSVBuilderFactory;
        List<string> list = new List<string>();
        Dictionary<int, string> allRecords = new Dictionary<int, string>();

        [SetUp]
        public void Setup()
        {
        }

        //Indian StateCode Data
        //UC-1
        //TC-1.1
        [Test]
        public void givenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", csvFilePath, indianCensusDataHeaders);
            CSVData count = new CSVData(counter.loadCSVFileData);
            allRecords = (Dictionary<int, string>)count();
            Assert.AreEqual(29, allRecords.Count);
        }

        //TC-1.2
        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", invalidCsvFilePath, indianCensusDataHeaders);
            CSVData count = new CSVData(counter.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, countt.type);
        }

        //TC-1.3
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", nonCSVFile, indianCensusDataHeaders);
            CSVData count = new CSVData(counter.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, countt.type);
        }

        //TC-1.4
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", wrongDelemeterFile, indianCensusDataHeaders);
            CSVData count = new CSVData(counter.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, countt.type);
        }

        //TC-1.5
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", wrongHeaderFile, indianCensusDataHeaders);
            CSVData count = new CSVData(counter.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, countt.type);
        }

        //Indian StateCode Code
        //UC-2
        //TC-2.1
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", indianStateCodeFile, indianStateCodeHeader);
            CSVData count = new CSVData(counter.loadCSVFileData);
            allRecords = (Dictionary<int, string>)count();
            Assert.AreEqual(37, allRecords.Count);
        }

        //TC-2.2
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", invalidCsvFilePath, indianStateCodeHeader);
            CSVData count = new CSVData(counter.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, countt.type);
        }

        //TC-2.3
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", nonCSVFile, indianStateCodeHeader);
            CSVData count = new CSVData(counter.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, countt.type);
        }

        //TC-2.4
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", wrongIndianStateCodeFile, indianStateCodeHeader);
            CSVData count = new CSVData(counter.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, countt.type);
        }

        //TC-2.5
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", wrongHeaderFile, indianStateCodeHeader);
            CSVData count = new CSVData(counter.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, countt.type);
        }

        //UC-3
        //TC-3.1
        [Test]
        public void givenCSVData_WhenSort_ShouldReturnSortedDataInJsonFormat()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", csvFilePath, indianCensusDataHeaders);
            censusAnalyser = new CensusAnalyser(csvFilePath, indianCensusDataHeaders);
            string sorted = censusAnalyser.sortingCSVData(csvFilePath, SortedindiaStateCensusData, 0).ToString();
            string[] sortatedData = JsonConvert.DeserializeObject<string[]>(sorted);
            Assert.AreEqual("Andhra Pradesh,49386799,162968,303", sortatedData[0]);
        }

        //UC-4
        [Test]
        public void givenCSVData_WhenSortByStateCode_ShouldReturnSortedDataInJsonFormat()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counter = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", csvFilePath, indianCensusDataHeaders);
            censusAnalyser = new CensusAnalyser(csvFilePath, indianCensusDataHeaders);
            string sorted = censusAnalyser.sortingCSVData(indianStateCodeFile, SortedindiaStateCensusData, 3).ToString();
            string[] sortatedData = JsonConvert.DeserializeObject<string[]>(sorted);
            Assert.AreEqual("3,Andhra Pradesh New,37,AD", sortatedData[0]);
        }
    }
}