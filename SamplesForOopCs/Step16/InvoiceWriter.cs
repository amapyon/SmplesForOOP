using System;
using System.IO;

namespace Step16
{
    public class InvoiceWriter : IDisposable
    {
        private TextWriter _writer = null;

        public InvoiceWriter()
        {
            var fos = new FileStream("../../../invoice.dat", FileMode.Create);
            _writer = new StreamWriter(fos);
            _writer.NewLine = "\n";
        }

        public InvoiceWriter(TextWriter writer)
        {
            _writer = writer;
        }

        public void Write(Invoice invoice)
        {
            _writer.WriteLine("1 " + invoice.GetOwnerTelNumber());
            _writer.WriteLine("5 " + invoice.GetBasicCharge());
            _writer.WriteLine("7 " + invoice.GetCallCharge());
            _writer.WriteLine("9 ====================");
        }

        public void Close()
        {
            _writer.Close();
        }

        public void Dispose()
        {
            Close();
        }
    }
}
