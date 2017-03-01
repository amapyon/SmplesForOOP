using System;

namespace Step6
{
    public class Invoice
    {
        // 契約者電話番号
        private string _ownerTelNumber = null;

        // 通話料金
        private int _callCharge = 0;

        // 変数を初期化する
        public void Clear()
        {
            _ownerTelNumber = null;
            _callCharge = 0;
        }

        // 加入者電話番号を設定する
        public void SetOwnerTelNumber(string ownerTelNumber)
        {
            _ownerTelNumber = ownerTelNumber;
        }

        // 加入者電話番号を取り出す
        public string GetOwnerTelNumber()
        {
            return _ownerTelNumber;
        }

        // 通話料金を加算する
        public void AddCallCharge(int callCharge)
        {
            _callCharge += callCharge;
        }

        // 通話料金を取り出す
        public int GetCallCharge()
        {
            return _callCharge;
        }

    }
}
