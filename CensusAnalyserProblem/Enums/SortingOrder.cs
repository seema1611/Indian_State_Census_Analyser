/*******************************************************
 * @purpose : Sorting Order class is used for sorting
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 11/08/2020
 *******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem
{
    public class SortingOrder
    {
        public enum SortBy
        {
            STATE, STATE_CODE, POPULATION, POPULATION_DENSITY, AREA_IN_SQ_KM
        }
        public enum SortOrder
        {
            ASCENDING, DESCENDING
        }
        public enum Country
        {
            INDIA, US
        }
        public enum DTO
        {
            INDIA_CENSUS, INDIA_STATE_CODE, US
        }
        public static List<CensusDAO> SortCensusData(List<CensusDAO> list, string sortType, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.ASCENDING ? list.OrderBy(c => c.GetType().GetField(sortType).GetValue(c)).ToList()
                  : list.OrderByDescending(c => c.GetType().GetField(sortType).GetValue(c)).ToList();
        }
    }
}
