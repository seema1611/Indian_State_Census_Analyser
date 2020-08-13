/***************************************************************************
 * @purpose : Indian Census class is used for getting and setting Code file
 * @author  : Seema Balkrishna Rajpure
 * @Date    : 11/08/2020
 ***************************************************************************/

using CsvHelper.Configuration.Attributes;

namespace CensusAnalyserProblem
{

    public class IndianStateCode
    {
        [Name("SrNo")]
        public int srNo { get; set; }

        [Name("State Name")]
        public string state { get; set; }

        [Name("TIN")]
        public int TIN { get; set; }

        [Name("StateCode")]
        public string stateCode { get; set; }

        public IndianStateCode() { }
        public IndianStateCode(string state, int srNo, int tin, string stateCode)
        {
            this.state = state;
            this.srNo = srNo;
            this.TIN = tin;
            this.stateCode = stateCode;
        }
    }
}