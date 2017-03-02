using System;

namespace Step12
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var reader = new RecordReader();
            var writer = new InvoiceWriter();

            var invoice = new Invoice();
            var services = new ServiceList();

            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);

                if (reader.IsOwnerRecord(line))
                {
                    // 契約者情報
                    invoice.SetOwnerTelNumber(reader.OwnerTelNumber(line));
                }
                else if (reader.IsServiceInfoRecord(line))
                {
                    // 加入サービス情報
                    services.CheckService(line);
                }
                else if (reader.IsCallRecord(line))
                {
                    // 通話記録

                    // 単価を計算する
                    int unitPrice = services.CalcUnitPrice(line);

                    // 1通話あたりの通話料を計算する
                    int callCharge = unitPrice * reader.CalingTime(line);

                    // 1通話あたりの通話料を全通話料に加算する
                    invoice.AddCallCharge(callCharge);
                }
                else if (reader.IsSeparateRecord(line))
                {
                    // 区切り

                    // 基本料金の計算
                    int basicCharge = services.CalcBasicCharge();
                    invoice.SetBasicCharge(basicCharge);

                    writer.Write(invoice);

                    // 変数の初期化
                    invoice.Clear();
                    services.Clear();
                }

                line = reader.ReadLine();
            }

            writer.Close();
            reader.Close();
        }

    }
}
