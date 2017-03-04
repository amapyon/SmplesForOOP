namespace Step17
{
    public interface IService
    {
        // 変数を初期化する
        void Clear();

        // 割引サービスに加入しているかを検査する
        void CheckService(Record record);

        // 単価を計算する
        double CalcUnitPrice(Record record, double unitPrice);

        // 基本料金を計算する
        int CalcBasicCharge(int basicCharge);
    }
}
