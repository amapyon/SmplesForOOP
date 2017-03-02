namespace Step14
{
    public class DayService : IService
    {
        private static readonly int START_HOUR = 8;
        private static readonly int END_HOUR = 17;

        // 料金計算のための基礎情報
        private static readonly string SERVICE_CODE = "E1";
        private static readonly int BASIC_CHARGE = 200;

        // 昼トク割引
        private bool _joined = false;

        // 変数を初期化する
        public void Clear()
        {
            _joined = false;
        }

        // 昼トク割引に加入済み
        public void Joined()
        {
            _joined = true;
        }

        // 昼トク割引に加入しているか
        public bool IsJoined()
        {
            return _joined;
        }

        // 昼トク割引対象時間かどうかを判定する
        public bool IsServiceTime(int hour)
        {
            if (_joined)
            {
                if ((hour >= START_HOUR) && (hour <= END_HOUR))
                {
                    return true;
                }
            }
            return false;
        }

        // 割引サービスに加入しているかを検査する
        public void CheckService(Record record)
        {
            if (SERVICE_CODE == record.GetServiceCode())
            {
                // 昼トク割引
                Joined();
            }
        }


        // 単価を計算する
        public double CalcUnitPrice(Record record, double unitPrice)
        {
            var hour = record.GetCallStartHour();
            if (IsServiceTime(hour))
            {
                // 昼トク割引なら5円引き
                unitPrice -= 5;
            }
            return unitPrice;
        }


        // 基本料金を計算する
        public int CalcBasicCharge(int basicCharge)
        {
            if (IsJoined())
            {
                basicCharge += BASIC_CHARGE;
            }
            return basicCharge;
        }

    }

}
