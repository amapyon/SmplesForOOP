namespace Step9
{
    public interface IService
    {
        // 変数を初期化する
        void Clear();

        // 割引サービスに加入しているかを検査する
        void CheckService(string line);

        // 単価を計算する
        double CalcUnitPrice(string line, double unitPrice);

        // 基本料金を計算する
        int CalcBasicCharge(int basicCharge);
    }
}
