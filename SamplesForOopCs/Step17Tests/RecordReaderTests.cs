using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Step17.Tests
{
    [TestClass()]
    public class RecordReaderTests
    {
        // テスト用のデータをヒアドキュメントで記述
        private readonly string testString =
@"1 090-1234-0001
2 C1 090-1234-0002
2 C1 090-1234-0003
5 2004/06/04 03:34 003 090-1234-0002
5 2004/06/04 13:50 010 090-1234-9999
9 *************************";

        [TestMethod()]
        public void ReadRecordTest()
        {
            var testData = new StringReader(testString);

            var reader = new RecordReader(testData);
            var r = reader.ReadRecord();
            Assert.IsTrue(r.IsOwnerRecord());
            Assert.AreEqual("090-1234-0001", r.GetOwnerTelNumber());

            r = reader.ReadRecord();
            Assert.IsTrue(r.IsServiceInfoRecord());
            Assert.AreEqual("C1", r.GetServiceCode());
            Assert.AreEqual("090-1234-0002", r.GetServiceOption());

            r = reader.ReadRecord();

            r = reader.ReadRecord();
            Assert.IsTrue(r.IsCallRecord());
            Assert.AreEqual(3, r.GetCallStartHour());
            Assert.AreEqual(3, r.GetCalingTime());
            Assert.AreEqual("090-1234-0002", r.GetCallNumber());

            r = reader.ReadRecord();

            r = reader.ReadRecord();
            Assert.IsTrue(r.IsSeparateRecord());
        }
    }
}