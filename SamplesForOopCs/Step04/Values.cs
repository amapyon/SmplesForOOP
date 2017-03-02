namespace Step04
{
    public class Values
    {
        private static readonly int FAMILY_SERVICE_TEL_NUMBER = 2;
        private static readonly int DAY_SERVICE_START_TIME = 8;
        private static readonly int DAY_SERVICE_END_TIME = 17;

        // 契約者電話番号
        public string ownerTelNumber = null;

        // 通話料金
        public int callCharge = 0;

        // 昼トク割引
        public bool dayServiceJoined = false;

        // 家族割引
        public bool familyServiceJoined = false;
        public string[] familyServiceTelNumbers = new string[FAMILY_SERVICE_TEL_NUMBER];
        public int familyServiceTelNumberCount = 0;

        // 変数を初期化する
        public void Clear()
        {
            dayServiceJoined = false;
            ownerTelNumber = null;
            familyServiceJoined = false;
            familyServiceTelNumberCount = 0;
            callCharge = 0;
        }

        // 昼トク割引対象時間かどうかを判定する
        public bool IsDayServiceTime(int hour)
        {
            if (dayServiceJoined)
            {
                if ((hour >= DAY_SERVICE_START_TIME) && (hour <= DAY_SERVICE_END_TIME))
                {
                    return true;
                }
            }
            return false;
        }

        // 家族割引対象電話番号を追加する
        public void AppendFamilyTelNumber(string telNumber)
        {
            familyServiceJoined = true;
            familyServiceTelNumbers[familyServiceTelNumberCount++] = telNumber;
        }

        // 家族割引対象電話番号かどうかを判定する
        public bool IsFamilyTelNumber(string telNumber)
        {
            for (int i = 0; i < familyServiceTelNumberCount; i++)
            {
                if (familyServiceTelNumbers[i] == telNumber)
                {
                    return true;
                }
            }
            return false;
        }

        // 通話料金を加算する
        public void AddCallCharge(int callCharge)
        {
            this.callCharge += callCharge;
        }

    }
}
