using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem
{
    public class SortType
    {
        public enum SortBy
        {
            STATE_ASCENDING, STATE_CODE_ASCENDING, POPULATION_DESCENDING, POPULATION_DENSITY_DESCENDING
        }
        public static List<IndianCensusDAO> SortIndianCensusData(List<IndianCensusDAO> list, SortBy sortType)
        {
            switch (sortType)
            {
                case SortBy.STATE_ASCENDING: return list.OrderBy(c => c.state).ToList();
                case SortBy.STATE_CODE_ASCENDING: return list.OrderBy(c => c.stateCode).ToList();
                case SortBy.POPULATION_DESCENDING: return list.OrderByDescending(c => c.population).ToList();
                case SortBy.POPULATION_DENSITY_DESCENDING: return list.OrderByDescending(c => c.densityPerSqKm).ToList();
                default : return list;
            }
        }
    }
}
