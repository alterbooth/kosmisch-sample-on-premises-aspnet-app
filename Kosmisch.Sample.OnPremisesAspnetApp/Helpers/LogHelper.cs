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
        /// <param name="message">ログメッセージ</param>
        /// <param name="writer"><see cref="TextWriter"/></param>
        public static void Write(string message, TextWriter writer)
        {
            writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{message}");
        }
    }
}