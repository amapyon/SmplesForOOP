using System;
using System.Collections.Generic;
using System.IO;

namespace Step08
{
    public class Program
    {
        // 料金計算のための基礎情報
        private static readonly int INITIAL_BASIC_CHARGE = 1000;
        private static readonly int INITIAL_CALL_UNIT_PRICE = 20;

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
            var services = new List<IService>() { dayService, familyService};

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

        private static void Service(List<IService> services, string line)
        {
            foreach(var service in services)
            {
                service.CheckService(line);
            }
        }

        private static void Call(Invoice invoice, List<IService> services, string line)
        {
            // 単価を計算する
            int unitPrice = INITIAL_CALL_UNIT_PRICE;
            foreach(var service in services)
            {
                unitPrice = service.CalcUnitPrice(line, unitPrice);
            }

            // 1通話あたりの通話料を計算し、全通話料に加算する
            string minutes = line.Substring(RI_OF_CALL_MINUTE, RI_SZ_CALL_MINUTE);
            invoice.AddCallCharge(unitPrice * int.Parse(minutes));
        }

        private static void Separate(StreamWriter writer, Invoice invoice, List<IService> services)
        {

            // 基本料金の計算
            int basicCharge = INITIAL_BASIC_CHARGE;
            foreach(var service in services)
            {
                basicCharge = service.CalcBasicCharge(basicCharge);
            }

            // 集計結果の出力
            writer.WriteLine("1 " + invoice.GetOwnerTelNumber());
            writer.WriteLine("5 " + basicCharge);
            writer.WriteLine("7 " + invoice.GetCallCharge());
            writer.WriteLine("9 ====================");

            // 変数の初期化
            invoice.Clear();
            foreach(var service in services)
            {
                service.Clear();
            }
        }
    }
}
