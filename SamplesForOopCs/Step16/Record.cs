namespace Step16
{
    public class Record
    {
        // 各レコードの先頭文字 (Record Code)
        private static readonly string RC_OWNER_INFO = "1";
        private static readonly string RC_SERVICE_INFO = "2";
        private static readonly string RC_CALL_LOG = "5";
        private static readonly string RC_SEPARATOR = "9";

        // 各レコードの情報 (Record Information)
        private static readonly int RI_OF_OWNER_TEL_NUMBER = 2;
        private static readonly int RI_OF_SERVICE_CODE = 2;
        private static readonly int RI_SZ_SERVICE_CODE = 2;
        private static readonly int RI_OF_SERVICE_OPTION = 5;

        private static readonly int RI_OF_CALL_START_TIME = 13;
        private static readonly int RI_SZ_HOUR = 2;
        private static readonly int RI_OF_CALL_MINUTE = 19;
        private static readonly int RI_SZ_CALL_MINUTE = 3;
        private static readonly int RI_OF_CALL_NUMBER = 23;


        private string _line;

        public Record(string line)
        {
            _line = line;
        }

        public override string ToString()
        {
            return _line;
        }

        internal bool EOR()
        {
            return _line == null;
        }

        public bool IsOwnerRecord()
        {
            return _line.StartsWith(RC_OWNER_INFO);
        }

        public string GetOwnerTelNumber()
        {
            return _line.Substring(RI_OF_OWNER_TEL_NUMBER);
        }

        public bool IsServiceInfoRecord()
        {
            return _line.StartsWith(RC_SERVICE_INFO);
        }

        public string GetServiceCode()
        {
            return _line.Substring(RI_OF_SERVICE_CODE, RI_SZ_SERVICE_CODE);
        }

        public string GetServiceOption()
        {
            return _line.Substring(RI_OF_SERVICE_OPTION);
        }

        public bool IsCallRecord()
        {
            return _line.StartsWith(RC_CALL_LOG);
        }

        public int GetCallStartHour()
        {
            return int.Parse(_line.Substring(RI_OF_CALL_START_TIME, RI_SZ_HOUR));
        }

        public string GetCallNumber()
        {
            return _line.Substring(RI_OF_CALL_NUMBER);
        }

        public bool IsSeparateRecord()
        {
            return _line.StartsWith(RC_SEPARATOR);
        }

        public int GetCalingTime()
        {
            return int.Parse(_line.Substring(RI_OF_CALL_MINUTE, RI_SZ_CALL_MINUTE));
        }

    }
}