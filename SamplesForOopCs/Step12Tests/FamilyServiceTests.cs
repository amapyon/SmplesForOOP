using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step12.Tests
{
    [TestClass()]
    public class FamilyServiceTests
    {
        [TestMethod()]
        public void IsFamilyTelNumberTest()
        {
            var familyService = new FamilyService();

            Assert.IsFalse(familyService.IsFamilyTelNumber("090-1234-1234"));

            familyService.AppendFamilyTelNumber("090-1234-1234");
            Assert.IsTrue(familyService.IsFamilyTelNumber("090-1234-1234"));
            Assert.IsFalse(familyService.IsFamilyTelNumber("090-1234-4321"));
        }

        [TestMethod()]
        public void CheckServiceTest()
        {
            var familyService = new FamilyService();

            familyService.CheckService("2 E1");
            Assert.IsFalse(familyService.IsJoined());

            familyService.CheckService("2 C1 090-1234-0001");
            Assert.IsTrue(familyService.IsJoined());
            Assert.IsTrue(familyService.IsFamilyTelNumber("090-1234-0001"));
        }

        [TestMethod()]
        public void CalcUnitPriceTest()
        {
            var familyService = new FamilyService();

            familyService.CheckService("2 C1 090-1234-0001");
            int unitPrice = (int)familyService.CalcUnitPrice("5 2004/06/05 17:50 010 090-1234-0002", 20);
            Assert.AreEqual(20, unitPrice);
            unitPrice = (int)familyService.CalcUnitPrice("5 2004/06/05 17:50 010 090-1234-0001", 20);
            Assert.AreEqual(10, unitPrice);
        }

        [TestMethod()]
        public void CalcBasicChargeTest()
        {
            var familyService = new FamilyService();

            familyService.CheckService("2 C1 090-1234-0001");
            int basicCharge = familyService.CalcBasicCharge(1000);
            Assert.AreEqual(1100, basicCharge);
        }
    }
}