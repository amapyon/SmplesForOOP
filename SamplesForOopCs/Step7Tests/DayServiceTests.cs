using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step7.Tests
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

        [TestMethod()]
        public void CheckServiceTest()
        {
            var dayService = new DayService();

            dayService.CheckService("2 C1 090-1234-0001");
            Assert.IsFalse(dayService.IsJoined());

            dayService.CheckService("2 E1");
            Assert.IsTrue(dayService.IsJoined());
        }

        [TestMethod()]
        public void CalcUnitPriceTest()
        {
            var dayService = new DayService();

            dayService.CheckService("2 E1");
            int unitPrice = dayService.CalcUnitPrice("5 2004/06/05 18:00 010 090-1234-0002", 20);
            Assert.AreEqual(20, unitPrice);
            unitPrice = dayService.CalcUnitPrice("5 2004/06/05 17:59 010 090-1234-0002", 20);
            Assert.AreEqual(15, unitPrice);
        }

        [TestMethod()]
        public void CalcBasicChargeTest()
        {
            var dayService = new DayService();

            dayService.CheckService("2 E1");
            int basicCharge = dayService.CalcBasicCharge(1000);
            Assert.AreEqual(1200, basicCharge);
        }
    }
}