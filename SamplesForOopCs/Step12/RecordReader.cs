using System;
using System.IO;

namespace Step12
{
    public class RecordReader : IDisposable
    {
        // 各レコードの先頭文字 (Record Code)
        private static readonly string RC_OWNER_INFO = "1";
        private static readonly string RC_SERVICE_INFO = "2";
        private static readonly string RC_CALL_LOG = "5";
        private static readonly string RC_SEPARATOR = "9";

        // 各レコードの情報 (Record Information)
        private static readonly int RI_OF_OWNER_TEL_NUMBER = 2;
        private static readonly int RI_OF_CALL_MINUTE = 19;
        private static readonly int RI_SZ_CALL_MINUTE = 3;

        StreamReader _reader = null;

        public RecordReader()
        {
            var fis = new FileStream("../../../record.log", FileMode.Open);
            _reader = new StreamReader(fis);
        }

        public void Close()
        {
            _reader.Close(); ;
        }

        public void Dispose()
        {
            Close();
        }

        public string ReadLine()
        {
            return _reader.ReadLine();
        }

        public bool IsOwnerRecord(string line)
        {
            return line.StartsWith(RC_OWNER_INFO);
        }

        public string OwnerTelNumber(string line)
        {
            return line.Substring(RI_OF_OWNER_TEL_NUMBER);
        }

        public bool IsServiceInfoRecord(string line)
        {
            return line.StartsWith(RC_SERVICE_INFO);
        }

        public bool IsCallRecord(string line)
        {
            return line.StartsWith(RC_CALL_LOG);
        }

        public bool IsSeparateRecord(string line)
        {
            return line.StartsWith(RC_SEPARATOR);
        }

        public int CalingTime(string line)
        {
            return int.Parse(line.Substring(RI_OF_CALL_MINUTE, RI_SZ_CALL_MINUTE));
        }

    }
}
