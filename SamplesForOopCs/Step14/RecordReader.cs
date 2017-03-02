using System;
using System.IO;

namespace Step14
{
    public class RecordReader : IDisposable
    {

        StreamReader _reader = null;

        public RecordReader()
        {
            var fis = new FileStream("../../../record.log", FileMode.Open);
            _reader = new StreamReader(fis);
        }

        public Record ReadRecord()
        {
            return new Record(_reader.ReadLine());
        }

        public void Close()
        {
            _reader.Close(); ;
        }

        public void Dispose()
        {
            Close();
        }

    }
}
