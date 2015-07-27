using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telegram.API.Client.Bot.Helpers;

namespace Telegram.API.Client.Bot.Tests
{
    [TestClass]
    public class UnixTimeConversionTests
    {
        [TestMethod]
        public void ToUnixTime()
        {
            double date_as_timestamp = 1437001573;
            DateTime date_as_object = new DateTime(2015, 07, 15, 23, 6, 13, DateTimeKind.Utc);

            var result = DateTimeHelpers.ToUnixTimestamp(date_as_object);

            Assert.AreEqual(date_as_timestamp, result);
        }
        
        [TestMethod]
        public void FromUnixTime()
        {
            double date_as_timestamp = 1437001573;
            DateTime date_as_object = new DateTime(2015, 07, 15, 23, 6, 13, DateTimeKind.Utc);

            var result = DateTimeHelpers.FromUnixTimestamp(date_as_timestamp);

            Assert.AreEqual(date_as_object.ToLocalTime(), result);
        }
    }
}
