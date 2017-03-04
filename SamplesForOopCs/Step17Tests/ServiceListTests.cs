using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step17.Tests
{
    [TestClass()]
    public class ServiceListTests
    {
        [TestMethod()]
        public void CalcBasicChargeTest()
        {
            var services = new ServiceList();

            // どのサービスにも入っていない
            services.Clear();
            Assert.AreEqual(1000, services.CalcBasicCharge(), "どのサービスにも入っていなければ1000円");

            // 家族割引に加入している
            services.Clear();
            services.CheckService(new Record("2 C1 090-1234-0002"));
            Assert.AreEqual(1100, services.CalcBasicCharge(), "家族割引に加入していれば1100円");

            // 昼トク割引に加入している
            services.Clear();
            services.CheckService(new Record("2 E1"));
            Assert.AreEqual(1200, services.CalcBasicCharge(), "昼トク割引に加入していれば1200円");

            // 家族割引と昼トク割引に加入している
            services.Clear();
            services.CheckService(new Record("2 C1 090-1234-0002"));
            services.CheckService(new Record("2 E1"));
            Assert.AreEqual(1300, services.CalcBasicCharge(), "家族割引と昼トク割引に加入していれば1300円");
        }

        [TestMethod()]
        public void CalcUnitPriceTest()
        {
            var services = new ServiceList();

            // どのサービスにも入っていない
            services.Clear();
            Assert.AreEqual(20, services.CalcUnitPrice(new Record("5 2004/06/04 03:34 003 090-1234-0002")), "どのサービスにも入っていなければ20円");

            // 家族割引に加入している
            services.Clear();
            services.CheckService(new Record("2 C1 090-1234-0002"));
            Assert.AreEqual(10, services.CalcUnitPrice(new Record("5 2004/06/04 03:34 003 090-1234-0002")), "家族割引の対象の通話先ならば10円");
            Assert.AreEqual(20, services.CalcUnitPrice(new Record("5 2004/06/04 03:34 003 090-1234-9999")), "家族割引の対象外の通話先ならば20円");

            // 昼トク割引に加入している
            services.Clear();
            services.CheckService(new Record("2 E1"));
            Assert.AreEqual(15, services.CalcUnitPrice(new Record("5 2004/06/04 08:00 003 090-1234-0002")), "昼トク割引の対象の時間帯ならば15円");
            Assert.AreEqual(20, services.CalcUnitPrice(new Record("5 2004/06/04 18:00 003 090-1234-0002")), "昼トク割引の対象外の時間帯ならば20円");

            // 家族割引と昼トク割引に加入している
            services.Clear();
            services.CheckService(new Record("2 C1 090-1234-0002"));
            services.CheckService(new Record("2 E1"));
            Assert.AreEqual(7, services.CalcUnitPrice(new Record("5 2004/06/04 08:00 003 090-1234-0002")), "昼トク割引の対象で、家族割引の対象ならば7円");
            Assert.AreEqual(15, services.CalcUnitPrice(new Record("5 2004/06/04 08:00 003 090-1234-9999")), "昼トク割引の対象で、家族割引の対象外ならば15円");
            Assert.AreEqual(10, services.CalcUnitPrice(new Record("5 2004/06/04 18:00 003 090-1234-0002")), "昼トク割引の対象外で、家族割引の対象ならば10円");
            Assert.AreEqual(20, services.CalcUnitPrice(new Record("5 2004/06/04 18:00 003 090-1234-9999")), "昼トク割引の対象外で、家族割引の対象外ならば20円");
        }

    }
}