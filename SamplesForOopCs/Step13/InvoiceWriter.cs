using System;
using System.IO;

namespace Step13
{
    public class InvoiceWriter : IDisposable
    {
        private StreamWriter _writer = null;

        public InvoiceWriter()
        {
            var fos = new FileStream("../../../invoice.dat", FileMode.Create);
            _writer = new StreamWriter(fos);
            _writer.NewLine = "\n";
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
