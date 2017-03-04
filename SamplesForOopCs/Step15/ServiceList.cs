using System.Collections.Generic;

namespace Step15
{
    public class ServiceList
    {
        // 料金計算のための基礎情報
        private static readonly int INITIAL_BASIC_CHARGE = 1000;
        private static readonly int INITIAL_CALL_UNIT_PRICE = 20;

        private List<IService> _services = new List<IService>(){ new DayService(), new FamilyService()};

        public int CalcBasicCharge()
        {
            int basicCharge = INITIAL_BASIC_CHARGE;
            foreach(var service in _services)
            {
                basicCharge = service.CalcBasicCharge(basicCharge);
            }
            return basicCharge;
        }

        public int CalcUnitPrice(Record record)
        {
            double unitPrice = INITIAL_CALL_UNIT_PRICE;
            foreach (var service in _services)
            {
                unitPrice = service.CalcUnitPrice(record, unitPrice);
            }
            return (int)unitPrice;
        }

        public void CheckService(Record record)
        {
            foreach (var service in _services)
            {
                service.CheckService(record);
            }
        }

        public void Clear()
        {
            foreach(var service in _services)
            {
                service.Clear();
            }
        }
    }
}
