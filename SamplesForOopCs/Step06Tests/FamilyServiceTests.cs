using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step06.Tests
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
    }
}