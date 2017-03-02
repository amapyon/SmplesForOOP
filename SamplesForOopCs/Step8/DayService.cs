namespace Step08
{
    public class DayService : IService
    {
        private static readonly int START_TIME = 8;
        private static readonly int END_TIME = 17;

        // 料金計算のための基礎情報
        private static readonly string SERVICE_CODE = "E1";
        private static readonly int BASIC_CHARGE = 200;

        // 各レコードの情報 (Record Information)
        private static readonly int RI_OF_SERVICE_CODE = 2;
        private static readonly int RI_SZ_SERVICE_CODE = 2;
        private static readonly int RI_OF_CALL_START_TIME = 13;
        private static readonly int RI_SZ_HOUR = 2;

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
                if ((hour >= START_TIME) && (hour <= END_TIME))
                {
                    return true;
                }
            }
            return false;
        }

        // 割引サービスに加入しているかを検査する
        public void CheckService(string line)
        {
            if (SERVICE_CODE == line.Substring(RI_OF_SERVICE_CODE, RI_SZ_SERVICE_CODE))
            {
                // 昼トク割引
                Joined();
            }
        }

        // 単価を計算する
        public int CalcUnitPrice(string line, int unitPrice)
        {
            var hour = int.Parse(line.Substring(RI_OF_CALL_START_TIME, RI_SZ_HOUR));
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
