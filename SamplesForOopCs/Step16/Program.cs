using System;

namespace Step16
{
    public class Program
    {

        public static void Main(string[] args)
        {
            using (var reader = new RecordReader())
            using (var writer = new InvoiceWriter())
            {
                var invoice = new Invoice();
                var services = new ServiceList();

                for (Record record = reader.ReadRecord(); !record.EOR(); record = reader.ReadRecord())
                {
                    Console.WriteLine(record);

                    if (record.IsOwnerRecord())
                    {
                        // 契約者情報
                        invoice.SetOwnerTelNumber(record.GetOwnerTelNumber());
                    }
                    else if (record.IsServiceInfoRecord())
                    {
                        // 加入サービス情報
                        services.CheckService(record);
                    }
                    else if (record.IsCallRecord())
                    {
                        // 通話記録

                        // 単価を計算する
                        int unitPrice = services.CalcUnitPrice(record);

                        // 1通話あたりの通話料を計算する
                        int callCharge = unitPrice * record.GetCalingTime();

                        // 1通話あたりの通話料を全通話料に加算する
                        invoice.AddCallCharge(callCharge);
                    }
                    else if (record.IsSeparateRecord())
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
                }
            }
        }

    }
}
