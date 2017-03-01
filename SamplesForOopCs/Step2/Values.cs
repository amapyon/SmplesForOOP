namespace Step2
{
    class Values
    {
        private static readonly int FAMILY_SERVICE_TEL_NUMBER = 2;

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
    }
}
