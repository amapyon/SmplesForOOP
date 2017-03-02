namespace Step05
{
    public class Values
    {
        private static readonly int FAMILY_SERVICE_TEL_NUMBER = 2;
        private static readonly int DAY_SERVICE_START_TIME = 8;
        private static readonly int DAY_SERVICE_END_TIME = 17;

        // 契約者電話番号
        private string _ownerTelNumber = null;

        // 通話料金
        private int _callCharge = 0;

        // 昼トク割引
        public bool _dayServiceJoined = false;

        // 家族割引
        private bool _familyServiceJoined = false;
        private string[] _familyServiceTelNumbers = new string[FAMILY_SERVICE_TEL_NUMBER];
        private int _familyServiceTelNumberCount = 0;

        // 変数を初期化する
        public void Clear()
        {
            _dayServiceJoined = false;
            _ownerTelNumber = null;
            _familyServiceJoined = false;
            _familyServiceTelNumberCount = 0;
            _callCharge = 0;
        }

        // 契約者電話番号を設定する
        public void SetOwnerTelNumber(string ownerTelNumber)
        {
            _ownerTelNumber = ownerTelNumber;
        }

        // 契約者電話番号を取り出す
        public string GetOwnerTelNumber()
        {
            return _ownerTelNumber;
        }

        // 昼特割引サービスに加入
        public void DayServiceJoined()
        {
            _dayServiceJoined = true;
        }

        // 昼特割引サービスに加入しているか
        public bool IsDayServiceJoined()
        {
            return _dayServiceJoined;
        }

        // 昼トク割引対象時間かどうかを判定する
        public bool IsDayServiceTime(int hour)
        {
            if (_dayServiceJoined)
            {
                if ((hour >= DAY_SERVICE_START_TIME) && (hour <= DAY_SERVICE_END_TIME))
                {
                    return true;
                }
            }
            return false;
        }

        // 家族割引サービスに加入
        public void FamilyServiceJoined()
        {
            _familyServiceJoined = true;
        }

        // 家族割引サービスに加入しているか
        public bool IsFamilyServiceJoined()
        {
            return _familyServiceJoined;
        }

        // 家族割引対象電話番号を追加する
        public void AppendFamilyTelNumber(string telNumber)
        {
            _familyServiceJoined = true;
            _familyServiceTelNumbers[_familyServiceTelNumberCount++] = telNumber;
        }

        // 家族割引対象電話番号かどうかを判定する
        public bool IsFamilyTelNumber(string telNumber)
        {
            for (int i = 0; i < _familyServiceTelNumberCount; i++)
            {
                if (_familyServiceTelNumbers[i] == telNumber)
                {
                    return true;
                }
            }
            return false;
        }

        // 通話料金を加算する
        public void AddCallCharge(int callCharge)
        {
            _callCharge += callCharge;
        }

        // 通話料金を取り出す
        public int GetCallCharge()
        {
            return _callCharge;
        }

    }
}
