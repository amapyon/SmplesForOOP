namespace Step06
{
    public class DayService
    {
        private static readonly int START_TIME = 8;
        private static readonly int END_TIME = 17;

        // 昼トク割引
        private bool _joined = false;

        // 変数を初期化する
        public void Clear()
        {
            _joined = false;
        }

        // 昼トク割引に加入済み
        public void Joined()
        {
            _joined = true;
        }

        // 昼トク割引に加入しているか
        public bool IsJoined()
        {
            return _joined;
        }

        // 昼トク割引対象時間かどうかを判定する
        public bool IsServiceTime(int hour)
        {
            if (_joined)
            {
                if ((hour >= START_TIME) && (hour <= END_TIME))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
