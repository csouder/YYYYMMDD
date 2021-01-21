using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YYYYMMDD
{
    public class DataParser
    {
        private const short DAY = 1;
        private const short MONTH = 2;
        private const short YEAR = 3;

        /// <summary>
        /// Returns leading zeros to date as necessary to make true YYYYMMDD format
        /// </summary>
        /// <example>
        /// LeadingZeros(timenum, timetype) -> "000"
        /// </example>
        /// <param name="timenum">Value of the date component.</param>
        /// <param name="timetype">Represents date component. 1=DAY, 2=MONTH, 3=YEAR</param>
        /// <returns>The appropirate amount of leading zeros.</returns>
        private static string LeadingZeros(int timenum, short timetype)
        {
            string zeros = "";
            switch (timetype)
            {
                case DAY:
                case MONTH:
                    if (timenum < 10)
                        zeros = "0";
                    break;
                case YEAR:
                    if (timenum < 10)
                        zeros += "000";
                    else if (timenum < 100)
                        zeros += "00";
                    else if (timenum < 1000)
                        zeros += "0";
                    break;
            }
            return zeros;
        }

        /// <summary>
        /// Returns an ISO 8601 date string using the specified delimiter.
        /// </summary>
        /// <example>
        /// GetIso8601DateString(date) -> "YYYYMMDD"
        /// GetIso8601DateString(date, '-') -> "YYYY-MM-DD"
        /// </example>
        /// <param name="date">The date to format.</param>
        /// <param name="delimiter">The delimiter character or null if no
        /// delimiter should be used.</param>
        /// <returns>The formatted date.</returns>
        public static string GetIso8601DateString(DateTime date, char? delimiter = null)
        {
            if(date == null)
            {
                throw new ArgumentNullException("date");
            }
            string formatteddate = "";
            if (string.IsNullOrEmpty(delimiter.ToString()))
            {
                formatteddate = LeadingZeros(date.Year, YEAR)
                    + date.Year.ToString()
                    + LeadingZeros(date.Month, MONTH)
                    + date.Month.ToString()
                    + LeadingZeros(date.Day, DAY)
                    + date.Day;
            }
            else
            {
                formatteddate = LeadingZeros(date.Year, YEAR)
                    + date.Year.ToString() + delimiter
                    + LeadingZeros(date.Month, MONTH)
                    + date.Month.ToString() + delimiter
                    + LeadingZeros(date.Day, DAY)
                    + date.Day;
            }
            return formatteddate;
        }
    }
}
