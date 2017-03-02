using System;
using System.IO;

namespace Step09
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
            var dayService = new DayService();
            var familyService = new FamilyService();
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
                    Service(services, line);
                }
                else if (line.StartsWith(RC_CALL_LOG))
                {
                    // 通話記録
                    Call(invoice, services, line);
                }
                else if (line.StartsWith(RC_SEPARATOR))
                {
                    // 区切り
                    Separate(writer, invoice, services);
                }


                line = reader.ReadLine();
            }

            writer.Close();
            fos.Close();

            reader.Close();
            fis.Close();
        }

        private static void Service(ServiceList services, string line)
        {
            services.CheckService(line);
        }

        private static void Call(Invoice invoice, ServiceList services, string line)
        {
            // 単価を計算する
            double unitPrice = services.CalcUnitPrice(line);

            // 1通話あたりの通話料を計算し、全通話料に加算する
            string minutes = line.Substring(RI_OF_CALL_MINUTE, RI_SZ_CALL_MINUTE);
            invoice.AddCallCharge((int)unitPrice * int.Parse(minutes));
        }

        private static void Separate(StreamWriter writer, Invoice invoice, ServiceList services)
        {

            // 基本料金の計算
            int basicCharge = services.CalcBasicCharge();

            // 集計結果の出力
            writer.WriteLine("1 " + invoice.GetOwnerTelNumber());
            writer.WriteLine("5 " + basicCharge);
            writer.WriteLine("7 " + invoice.GetCallCharge());
            writer.WriteLine("9 ====================");

            // 変数の初期化
            invoice.Clear();
            services.Clear();
        }
    }
}
