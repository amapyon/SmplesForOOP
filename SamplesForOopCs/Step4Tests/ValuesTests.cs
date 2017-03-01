using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step4.Tests
{
    [TestClass()]
    public class ValuesTests
    {
        [TestMethod()]
        public void IsDayServiceTimeTest()
        {
            var values = new Values();
            values.dayServiceJoined = false;
            Assert.IsFalse(values.IsDayServiceTime(7));
            Assert.IsFalse(values.IsDayServiceTime(8));
            Assert.IsFalse(values.IsDayServiceTime(17));
            Assert.IsFalse(values.IsDayServiceTime(18));

            values.dayServiceJoined = true;
            Assert.IsFalse(values.IsDayServiceTime(7));
            Assert.IsTrue(values.IsDayServiceTime(8));
            Assert.IsTrue(values.IsDayServiceTime(17));
            Assert.IsFalse(values.IsDayServiceTime(18));
        }

        [TestMethod()]
        public void IsFamilyTelNumberTest()
        {
            var values = new Values();
            Assert.IsFalse(values.IsFamilyTelNumber("090-1234-1234"));

            values.AppendFamilyTelNumber("090-1234-1234");
            Assert.IsTrue(values.IsFamilyTelNumber("090-1234-1234"));
            Assert.IsFalse(values.IsFamilyTelNumber("090-1234-4321"));
        }
    }
}