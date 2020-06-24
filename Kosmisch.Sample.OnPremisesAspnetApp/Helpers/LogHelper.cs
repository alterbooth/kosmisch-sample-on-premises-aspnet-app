using System;
using System.IO;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Helpers
{
    /// <summary>
    /// ログ出力用ヘルパークラス
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// ログを書き込む
        /// </summary>
        /// <param name="path">ログファイルパス</param>
        /// <param name="message">ログメッセージ</param>
        public static void Write(string path, string message)
        {
            using (var w = File.AppendText($@"{path}\log.txt"))
            {
                w.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{message}");
            }
        }
    }
}