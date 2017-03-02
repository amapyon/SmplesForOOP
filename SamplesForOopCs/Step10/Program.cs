using System;
using System.IO;

namespace Step10
{
    public class Program
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

        public static void Main(string[] args)
        {
            var fis = new FileStream("../../../record.log", FileMode.Open);
            var reader = new StreamReader(fis);

            var fos = new FileStream("../../../invoice.dat", FileMode.Create);
            var writer = new StreamWriter(fos);
            writer.NewLine = "\n";

            var invoice = new Invoice();
            var services = new ServiceList();

            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);

                if (line.StartsWith(RC_OWNER_INFO))
                {
                    // 契約者情報
                    invoice.SetOwnerTelNumber(line.Substring(RI_OF_OWNER_TEL_NUMBER));
                }
                else if (line.StartsWith(RC_SERVICE_INFO))
                {
                    // 加入サービス情報
                    services.CheckService(line);
                }
                else if (line.StartsWith(RC_CALL_LOG))
                {
                    // 通話記録

                    // 単価を計算する
                    int unitPrice = services.CalcUnitPrice(line);

                    // 1通話あたりの通話料を計算する
                    int callCharge = unitPrice * int.Parse(line.Substring(RI_OF_CALL_MINUTE, RI_SZ_CALL_MINUTE));

                    // 1通話あたりの通話料を全通話料に加算する
                    invoice.AddCallCharge(callCharge);
                }
                else if (line.StartsWith(RC_SEPARATOR))
                {
                    // 区切り

                    // 基本料金の計算
                    int basicCharge = services.CalcBasicCharge();
                    invoice.SetBasicCharge(basicCharge);

                    Write(writer, invoice);

                    // 変数の初期化
                    invoice.Clear();
                    services.Clear();
                }

                line = reader.ReadLine();
            }

            writer.Close();
            fos.Close();

            reader.Close();
            fis.Close();
        }

        private static void Write(StreamWriter writer, Invoice invoice)
        {
            // 集計結果の出力
            writer.WriteLine("1 " + invoice.GetOwnerTelNumber());
            writer.WriteLine("5 " + invoice.GetBasicCharge());
            writer.WriteLine("7 " + invoice.GetCallCharge());
            writer.WriteLine("9 ====================");
        }
    }
}
