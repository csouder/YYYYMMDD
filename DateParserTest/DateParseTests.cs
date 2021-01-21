using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YYYYMMDD;

namespace DateParserTest
{
    [TestClass]
    public class DateParseTests
    {

        const char delimiter = '-';
        [TestMethod]
        public void DateTest()
        {
            string parseddate = "";
            var date = new DateTime(2020, 6, 1);
            parseddate = YYYYMMDD.DataParser.GetIso8601DateString(date, delimiter);
            Assert.AreEqual("2020-06-01", parseddate);
        }

        [TestMethod]
        [TestCategory("NULLs")]
        public void Datewithnulldelimiter()
        {
            string parseddate = "";
            var date = new DateTime(2021, 1, 20);
            parseddate = YYYYMMDD.DataParser.GetIso8601DateString(date);
            Assert.AreEqual("20210120", parseddate);
        }

        [TestMethod]
        [DataRow(2, 3, 4, "00020304")]
        [DataRow(2, 3, 4, "0002-03-04", '-')]
        [DataRow(12, 12, 26, "00121226")]
        [DataRow(312, 12, 26, "03121226")]
        [DataRow(2020, 3, 9, "20200309")]
        public void LessthanFullDigits(int year, int month, int day, string expected, char? delimiter = null)
        {
            var parseddate = "";
            var date = new DateTime(year, month, day);
            if (string.IsNullOrEmpty(delimiter.ToString()))
                parseddate = YYYYMMDD.DataParser.GetIso8601DateString(date);
            else
                parseddate = YYYYMMDD.DataParser.GetIso8601DateString(date, delimiter);
            Assert.AreEqual(expected, parseddate);
        }
    }
}
