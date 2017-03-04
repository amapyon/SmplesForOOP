using System.Text;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Step17.Tests
{
    [TestClass()]
    public class InvoiceWriterTests
    {

        [TestMethod()]
        public void WriteTest()
        {
            StringBuilder buffer = new StringBuilder();
            var mock = new Mock<TextWriter>();
            mock.Setup(
                (m) => m.WriteLine(It.IsAny<string>()))
                .Callback<string>(
                (s) =>
                {
                    buffer.Append(s);
                });

            var invoiceWriter = new InvoiceWriter(mock.Object);

            var invoice = new Invoice();
            invoice.SetOwnerTelNumber("090-1234-0001");
            invoice.SetBasicCharge(1100);
            invoice.AddCallCharge(230);

            invoiceWriter.Write(invoice);

            string expected =
                "1 090-1234-0001" +
                "5 1100" +
                "7 230" +
                "9 ====================";

            Assert.AreEqual(expected, buffer.ToString());
        }
    }
}