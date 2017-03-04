using System.Collections.Generic;
using System.Linq;

namespace Step17
{
    public class ServiceList
    {
        // 料金計算のための基礎情報
        private static readonly int INITIAL_BASIC_CHARGE = 1000;
        private static readonly int INITIAL_CALL_UNIT_PRICE = 20;

        private List<IService> _services = new List<IService>(){ new DayService(), new FamilyService()};

        public int CalcBasicCharge()
        {
            return _services.Aggregate(
                INITIAL_BASIC_CHARGE, (basicCharge, service) => 
                {
                    return service.CalcBasicCharge(basicCharge);
                });
        }

        public int CalcUnitPrice(Record record)
        {
            return (int)_services.Aggregate(
                (double)INITIAL_CALL_UNIT_PRICE, (unitPrice, service) =>
                {
                    return service.CalcUnitPrice(record, unitPrice);
                });
        }

        public void CheckService(Record record)
        {
            _services.ForEach((s) => { s.CheckService(record); });
        }

        public void Clear()
        {
            _services.ForEach((s) => { s.Clear(); });
        }
    }
}
