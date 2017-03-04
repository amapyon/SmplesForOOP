using System;
using System.IO;

namespace Step17
{
    public class RecordReader : IDisposable
    {

        TextReader _reader = null;

        public RecordReader()
        {
            var fis = new FileStream("../../../record.log", FileMode.Open);
            _reader = new StreamReader(fis);
        }

        public RecordReader(TextReader reader)
        {
            _reader = reader;
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
