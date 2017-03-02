namespace Step8
{
    public class FamilyService : IService
    {
        private static readonly int TEL_NUMBER = 2;

        // 料金計算のための基礎情報
        private static readonly string SERVICE_CODE = "C1";
        private static readonly int BASIC_CHARGE = 100;

        // 各レコードの情報 (Record Information)
        private static readonly int RI_OF_SERVICE_CODE = 2;
        private static readonly int RI_SZ_SERVICE_CODE = 2;
        private static readonly int RI_OF_SERVICE_OPTION = 5;
        private static readonly int RI_OF_CALL_NUMBER = 23;

        // 家族割引
        private bool _joined = false;
        private string[] _telNumbers = new string[TEL_NUMBER];
        private int _telNumberCount = 0;

        // 変数を初期化する
        public void Clear()
        {
            _joined = false;
            _telNumberCount = 0;
        }

        // 家族割引対象電話番号を追加する
        public void AppendFamilyTelNumber(string telNumber)
        {
            _joined = true;
            _telNumbers[_telNumberCount++] = telNumber;
        }

        // 家族割引に加入しているか
        public bool IsJoined()
        {
            return _joined;
        }

        // 家族割引対象電話番号かどうかを判定する
        public bool IsFamilyTelNumber(string telNumber)
        {
            for (int i = 0; i < _telNumberCount; i++)
            {
                if (_telNumbers[i] == telNumber)
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
                // 家族割引 登録されている電話番号を一時保管
                AppendFamilyTelNumber(line.Substring(RI_OF_SERVICE_OPTION));
            }
        }

        // 単価を計算する
        public int CalcUnitPrice(string line, int unitPrice)
        {
            if (IsFamilyTelNumber(line.Substring(RI_OF_CALL_NUMBER)))
            {
                // 家族割引なら半額
                unitPrice /= 2;
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
