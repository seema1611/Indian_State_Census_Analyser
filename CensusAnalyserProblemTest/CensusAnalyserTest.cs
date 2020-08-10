using CensusAnalyserProblem;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static CensusAnalyserProblem.CensusAnalyser;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {

        //Indian State Data
        string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string csvFilePath = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        string invalidCsvFilePath = @"D:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        string nonCSVFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.cs";
        string wrongDelemeterFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectDelimeters.csv";
        string wrongHeaderFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";

        //Indian State Code
        string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        string indianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";
        string wrongIndianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        CSVBuilderFactory cSVBuilderFactory;
        List<string> list = new List<string>();

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
            CensusAnalyser counte = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", csvFilePath, indianCensusDataHeaders);
            CSVData count = new CSVData(counte.loadCSVFileData);
            list = (List<string>)count();
            Assert.AreEqual(29, list.Count);
        }

        //TC-1.2
        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counte = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", invalidCsvFilePath, indianCensusDataHeaders);
            CSVData count = new CSVData(counte.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            System.Console.WriteLine(countt.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, countt.type);
        }

        //TC-1.3
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counte = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", nonCSVFile, indianCensusDataHeaders);
            CSVData count = new CSVData(counte.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, countt.type);
        }

        //TC-1.4
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counte = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", wrongDelemeterFile, indianCensusDataHeaders);
            CSVData count = new CSVData(counte.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, countt.type);
        }

        //TC-1.5
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counte = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", wrongHeaderFile, indianCensusDataHeaders);
            CSVData count = new CSVData(counte.loadCSVFileData);
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
            CensusAnalyser counte = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", indianStateCodeFile, indianStateCodeHeader);
            CSVData count = new CSVData(counte.loadCSVFileData);
            list = (List<string>)count();
            Assert.AreEqual(37, list.Count);
        }

        //TC-2.2
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counte = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", invalidCsvFilePath, indianStateCodeHeader);
            CSVData count = new CSVData(counte.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, countt.type);
        }

        //TC-2.3
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counte = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", nonCSVFile, indianStateCodeHeader);
            CSVData count = new CSVData(counte.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, countt.type);
        }

        //TC-2.4
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counte = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", wrongIndianStateCodeFile, indianStateCodeHeader);
            CSVData count = new CSVData(counte.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, countt.type);
        }

        //TC-2.5
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            cSVBuilderFactory = new CSVBuilderFactory();
            CensusAnalyser counte = (CensusAnalyser)cSVBuilderFactory.CreateObject("CensusAnalyser", wrongHeaderFile, indianStateCodeHeader);
            CSVData count = new CSVData(counte.loadCSVFileData);
            var countt = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, countt.type);
        }
    }
}