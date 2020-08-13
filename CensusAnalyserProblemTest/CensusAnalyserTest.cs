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
        public static string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public static string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        public static string usCensusDataHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";

        //Indian State Data
        public static string csvFilePath = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        public static string invalidCsvFilePath = @"D:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        public static string nonCSVFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.cs";
        public static string wrongDelemeterFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectDelimeters.csv";
        public static string wrongHeaderFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";

        //Indian State Code
        public static string indianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";
        public static string wrongIndianStateCodeFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectIndiaStateCode.csv";

        //US Census Data
        public static string usCSVFilePath = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\USCensusData.csv";
        public static string invalidUSCsvFilePath = @"D:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\USCensusData.csv";
        public static string nonUSCSVFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\USCensusData.cs";
        public static string wrongUSDelemeterFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectUSDelimeters.csv";
        public static string wrongUSHeaderFile = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectUSHeaders.csv";

        IndianCensusLoader censusAnalyser;
        UsCensusLoader usCensusAnalyser;
        CensusAnalyserAdapter censusAdapter;


        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianCensusLoader();
            usCensusAnalyser = new UsCensusLoader();
            censusAdapter = new CensusAdapter();
        }

        //Indian StateCode Data
        //<--------------------UC-1-------------------->
        //TC-1.1
        [Test]
        public void GivenIndianCensusDataCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<object, CensusDAO> indianCensusRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, csvFilePath);
            Assert.AreEqual(29, indianCensusRecord.Count);
        }

        //TC-1.2
        [Test]
        public void GivenIndianCensusDataCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, invalidCsvFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.type);
        }

        //TC-1.3
        [Test]
        public void GivenIndianCensusDataCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, nonCSVFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, customException.type);
        }

        //TC-1.4
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, wrongDelemeterFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.type);
        }

        //TC-1.5
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, wrongHeaderFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.type);
        }

        //<---------------Indian StateCode Code--------------->
        //<--------------------UC-2-------------------->
        //TC-2.1
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {

            Dictionary<object, CensusDAO> indianStateCodeList = censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeList.Count);
        }

        //TC-2.2
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, invalidCsvFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.type);
        }

        //TC-2.3
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, nonCSVFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, customException.type);
        }

        //TC-2.4
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, wrongIndianStateCodeFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.type);
        }

        //TC-2.5
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, wrongHeaderFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.type);
        }

        //<--------------------UC-3-------------------->
        //TC-3.1
        [Test]
        public void GivenIndianStateCSVData_WhenSort_ShouldReturnSortedFirstDataInJsonFormat()
        {
            Dictionary<object, CensusDAO> indianCensusRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianCensusRecord, DTO.INDIA_CENSUS, SortBy.STATE, SortOrder.ASCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Andhra Pradesh", indianCensusSortedList[0].state);
        }

        //TC-3.2
        [Test]
        public void GivenIndianStateCSVData_WhenSort_ShouldReturnSortedLastDataInJsonFormat()
        {
            Dictionary<object, CensusDAO> indianCensusRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianCensusRecord, DTO.INDIA_CENSUS, SortBy.STATE, SortOrder.ASCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("West Bengal", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }

        //<--------------------UC-4-------------------->
        //TC-4.1
        [Test]
        public void GivenIndianStateCSVData_WhenSortByStateCode_ShouldReturnSortedLastDataInJsonFormat()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, indianStateCodeFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord, DTO.INDIA_STATE_CODE, SortBy.STATE_CODE, SortOrder.ASCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("AD", indianCensusSortedList[0].stateCode);
        }

        //TC-4.2
        [Test]
        public void GivenIndianStateCodeCSVFile_Whenloaded_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, indianStateCodeFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord, DTO.INDIA_STATE_CODE, SortBy.STATE_CODE, SortOrder.ASCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("WB", indianCensusSortedList[indianCensusSortedList.Count - 1].stateCode);
        }

        //<--------------------UC-5-------------------->
        //TC-5.1
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsMostPopulousState()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord, DTO.INDIA_CENSUS, SortBy.POPULATION, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Uttar Pradesh", indianCensusSortedList[0].state);
        }

        //TC-5.2
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsLeastPopulousState()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord, DTO.INDIA_CENSUS, SortBy.POPULATION, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Sikkim", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }


        //<--------------------UC-6-------------------->
        //TC-6.1
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsMostPopulousStateBasedOnDensityPerSqm()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord, DTO.INDIA_CENSUS, SortBy.POPULATION_DENSITY, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Bihar", indianCensusSortedList[0].state);
        }

        //TC-6.2
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsLeastPopulousStateBasedOnDensityPerSqm()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord, DTO.INDIA_CENSUS, SortBy.POPULATION_DENSITY, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Arunachal Pradesh", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }

        //<--------------------UC-7-------------------->
        //TC-7.1
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsMostPopulousStateBasedOnAreaPerSqm()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord, DTO.INDIA_CENSUS, SortBy.AREA_IN_SQ_KM, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Rajasthan", indianCensusSortedList[0].state);
        }

        //TC-7.2
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenSorted_ShouldReturnsLeastPopulousStateBasedOnAreaPerSqm()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, csvFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord, DTO.INDIA_CENSUS, SortBy.AREA_IN_SQ_KM, SortOrder.DESCENDING);
            List<IndianCensus> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("Goa", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }

        //<---------------US Census Data--------------->
        //<--------------------UC-8-------------------->
        //TC-8.1
        [Test]
        public void GivenUSCensusCSVFile__WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<object, CensusDAO> indianCensusRecord = censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeaders, usCSVFilePath);
            Assert.AreEqual(51, indianCensusRecord.Count);
        }

        //TC-8.2
        [Test]
        public void GivenUSCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeaders, invalidUSCsvFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.type);
        }

        //TC-8.3
        [Test]
        public void GivenUSCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeaders, nonUSCSVFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, customException.type);
        }

        //TC-8.4
        [Test]
        public void GivenUSCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeaders, wrongUSDelemeterFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.type);
        }

        //TC-8.5
        [Test]
        public void GivenUSCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeaders, wrongUSHeaderFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.type);
        }

        //<--------------------UC-9-------------------->
        //TC-9.1
        [Test]
        public void GivenUsCensusCSVFile_Whensorted_ShouldReturnsMostPopulousState()
        {
            Dictionary<object, CensusDAO> usRecord = censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeaders, usCSVFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(usRecord, DTO.US, SortBy.POPULATION, SortOrder.DESCENDING);
            List<USCensus> usCensusSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("California", usCensusSortedList[0].state);
        }

        //TC-9.2
        [Test]
        public void GivenUsCensusCSVFile_Whensorted_ShouldReturnsLeastPopulousState()
        {
            Dictionary<object, CensusDAO> usRecord = censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeaders, usCSVFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(usRecord, DTO.US, SortBy.POPULATION, SortOrder.DESCENDING);
            List<USCensus> usCensusSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("Wyoming", usCensusSortedList[usCensusSortedList.Count - 1].state);
        }

        //<--------------------UC-10-------------------->
        //UC-10.1
        [Test]
        public void GivenUsCensusCSVFile_Whensorted_ShouldReturnsMostPopulousStateBasedOnPopulationDensity()
        {
            Dictionary<object, CensusDAO> usRecord = censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeaders, usCSVFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(usRecord, DTO.US, SortBy.POPULATION_DENSITY, SortOrder.DESCENDING);
            List<USCensus> usCensusSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("District of Columbia", usCensusSortedList[0].state);
        }

        //UC-10.2
        [Test]
        public void GivenUsCensusCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousStateBasedOnPopulationDensity()
        {
            Dictionary<object, CensusDAO> usRecord = censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeaders, usCSVFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(usRecord, DTO.US, SortBy.POPULATION_DENSITY, SortOrder.DESCENDING);
            List<USCensus> usCensusSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("Alaska", usCensusSortedList[usCensusSortedList.Count - 1].state);
        }

        //TC-10.3
        [Test]
        public void GivenUsCensusCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousStateBasedOnArea()
        {
            Dictionary<object, CensusDAO> usRecord = censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeaders, usCSVFilePath);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(usRecord, DTO.US, SortBy.AREA_IN_SQ_KM, SortOrder.DESCENDING);
            List<USCensus> usCensusSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("Alaska", usCensusSortedList[0].state);
        }
    }
}