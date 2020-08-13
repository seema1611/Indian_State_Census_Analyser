/*********************************************************
 * @purpose : CensusDAO is used to access object
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 11/08/2020
 ********************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CensusDAO
    {
        public float areaInSqKm;
        public dynamic state;
        public int population;
        public float populationDensity;
        public int srNo;
        public int TIN;
        public string stateCode;
        public float housingDensity;
        public float landArea;
        public float waterArea;
        public int housingUnits;

        public CensusDAO() { }
        public static CensusDAO getDAO(dynamic objType)
        {
            Type type = objType.GetType();
            if (type == new IndianCensus().GetType())
                return new CensusDAO((IndianCensus)objType);
            if (type == new USCensus().GetType())
                return new CensusDAO((USCensus)objType);
            return new CensusDAO((IndianStateCode)objType);
        }
        public CensusDAO(IndianCensus indianCensusCSV)
        {
            state = indianCensusCSV.state;
            areaInSqKm = indianCensusCSV.totalArea;
            population = indianCensusCSV.population;
            populationDensity = indianCensusCSV.populationDensity;
        }
        public CensusDAO(USCensus usCensus)
        {
            stateCode = usCensus.stateId;
            state = usCensus.state;
            population = usCensus.population;
            areaInSqKm = usCensus.totalArea;
            populationDensity = usCensus.populationDensity;
            housingDensity = usCensus.housingDensity;
            landArea = usCensus.landArea;
            waterArea = usCensus.waterArea;
            housingUnits = usCensus.housingUnits;
        }
        public CensusDAO(IndianStateCode indianStateCode)
        {
            srNo = indianStateCode.srNo;
            state = indianStateCode.state;
            TIN = indianStateCode.TIN;
            stateCode = indianStateCode.stateCode;
        }
        public object getDTO(SortingOrder.DTO dtoFormat, CensusDAO censusDAO)
        {
            if (dtoFormat.Equals(SortingOrder.DTO.INDIA_CENSUS))
                return new IndianCensus(censusDAO.state, censusDAO.population, censusDAO.areaInSqKm, censusDAO.populationDensity);
            if (dtoFormat.Equals(SortingOrder.DTO.INDIA_STATE_CODE))
                return new IndianStateCode(censusDAO.state, censusDAO.srNo, censusDAO.TIN, censusDAO.stateCode);
            return new USCensus(censusDAO.state, censusDAO.stateCode, censusDAO.population, censusDAO.waterArea, censusDAO.housingUnits, censusDAO.housingDensity, censusDAO.landArea, censusDAO.areaInSqKm);
        }
    }
}
