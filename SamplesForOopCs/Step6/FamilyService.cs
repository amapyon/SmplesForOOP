namespace Step6
{
    public class FamilyService
    {
        private static readonly int TEL_NUMBER = 2;

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
    }

}
