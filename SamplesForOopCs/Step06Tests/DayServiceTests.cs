using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step06.Tests
{
    [TestClass()]
    public class DayServiceTests
    {
        [TestMethod()]
        public void IsServiceTimeTest()
        {
            var dayService = new DayService();

            Assert.IsFalse(dayService.IsServiceTime(7));
            Assert.IsFalse(dayService.IsServiceTime(8));
            Assert.IsFalse(dayService.IsServiceTime(17));
            Assert.IsFalse(dayService.IsServiceTime(18));

            dayService.Joined();
            Assert.IsFalse(dayService.IsServiceTime(7));
            Assert.IsTrue(dayService.IsServiceTime(8));
            Assert.IsTrue(dayService.IsServiceTime(17));
            Assert.IsFalse(dayService.IsServiceTime(18));

        }
    }
}