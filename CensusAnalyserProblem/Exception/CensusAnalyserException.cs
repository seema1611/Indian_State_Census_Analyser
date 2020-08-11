/***************************************************************************
 * @purpose : Census Analyzer Exception is used to handle custom exception
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 08/08/2020
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CensusAnalyserException:Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INCORRECT_FILE_FORMAT, INCORRECT_DELIMITER, INCORRECT_HEADER
        }
        public ExceptionType type;

        public CensusAnalyserException(String message, ExceptionType type) : base(String.Format(message))
        {
            this.type = type;
        }
    }
}
