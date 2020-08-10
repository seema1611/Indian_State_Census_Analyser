using CensusAnalyserProblem;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static CensusAnalyserProblem.CensusAnalyser;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusAnalyser censusAnalyser;

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
            censusAnalyser = new CensusAnalyser(csvFilePath, indianCensusDataHeaders);
            CSVData count = new CSVData(censusAnalyser.loadCSVFileData);
            int c = (int)count();
            Assert.AreEqual(c, 29);
        }

        //TC-1.2
        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            censusAnalyser = new CensusAnalyser(invalidCsvFilePath, indianCensusDataHeaders);
            CSVData countt = new CSVData(censusAnalyser.loadCSVFileData);
            var count = Assert.Throws<CensusAnalyserException>(() => countt());
            System.Console.WriteLine(count.type);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, count.type);

            //var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, invalidCsvFilePath));
            //Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        //TC-1.3
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            censusAnalyser = new CensusAnalyser(nonCSVFile, indianCensusDataHeaders);
            CSVData countt = new CSVData(censusAnalyser.loadCSVFileData);
            var count = Assert.Throws<CensusAnalyserException>(() => countt());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, count.type);

            //var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, nonCSVFile));
            //Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        //TC-1.4
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            censusAnalyser = new CensusAnalyser(wrongDelemeterFile, indianCensusDataHeaders);
            CSVData countt = new CSVData(censusAnalyser.loadCSVFileData);
            var count = Assert.Throws<CensusAnalyserException>(() => countt());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, count.type);

            //var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, wrongDelemeterFile));
            //Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        //TC-1.5
        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            censusAnalyser = new CensusAnalyser(wrongHeaderFile, indianCensusDataHeaders);
            CSVData countt = new CSVData(censusAnalyser.loadCSVFileData);
            var count = Assert.Throws<CensusAnalyserException>(() => countt());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, count.type);

            //var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, wrongHeaderFile));
            //Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, error.type);
        }

        //Indian StateCode Code
        //UC-2
        //TC-2.1
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            censusAnalyser = new CensusAnalyser(indianStateCodeFile, indianStateCodeHeader);
            int count = censusAnalyser.loadCSVFileData();
            Assert.AreEqual(37, count);

            //IEnumerable<string> indianStateCodeRecord = censusAnalyser.loadCSVFileData(indianStateCodeHeader, indianStateCodeFile);
            //Assert.AreEqual(37, indianStateCodeRecord.Count());
        }

        //TC-2.2
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            censusAnalyser = new CensusAnalyser(invalidCsvFilePath, indianStateCodeHeader);
            CSVData countt = new CSVData(censusAnalyser.loadCSVFileData);
            var count = Assert.Throws<CensusAnalyserException>(() => countt());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, count.type);

            //var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianStateCodeHeader, invalidCsvFilePath));
            //Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        //TC-2.3
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            censusAnalyser = new CensusAnalyser(nonCSVFile, indianStateCodeHeader);
            CSVData countt = new CSVData(censusAnalyser.loadCSVFileData);
            var count = Assert.Throws<CensusAnalyserException>(() => countt());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, count.type);

            //var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianStateCodeHeader, nonCSVFile));
            //Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        //TC-2.4
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            censusAnalyser = new CensusAnalyser(wrongIndianStateCodeFile, indianStateCodeHeader);
            CSVData countt = new CSVData(censusAnalyser.loadCSVFileData);
            var count = Assert.Throws<CensusAnalyserException>(() => countt());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, count.type);

            //var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianStateCodeHeader, wrongIndianStateCodeFile));
            //Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        //TC-2.5
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            censusAnalyser = new CensusAnalyser(wrongHeaderFile, indianStateCodeHeader);
            CSVData countt = new CSVData(censusAnalyser.loadCSVFileData);
            var count = Assert.Throws<CensusAnalyserException>(() => countt());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, count.type);

            //var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianStateCodeHeader, wrongHeaderFile));
            //Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, error.type);
        }
    }
}