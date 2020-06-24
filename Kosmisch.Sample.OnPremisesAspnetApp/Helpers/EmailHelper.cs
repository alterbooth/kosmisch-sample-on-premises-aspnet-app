using System.Net.Mail;
using System.Text;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Helpers
{
    /// <summary>
    /// メール送信用ヘルパークラス
    /// </summary>
    public static class EmailHelper
    {
        /// <summary>
        /// メールを送信する
        /// </summary>
        /// <param name="body">bodyテキスト</param>
        public static void Send(string body)
        {
            var client = new SmtpClient("smtp.kosmischsample.net");
            var from = new MailAddress("from@kosmischsample.net", "Kosmisch", Encoding.UTF8);
            var to = new MailAddress("to@kosmischsample.net");
            var message = new MailMessage(from, to);
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = "Kosmisch Sample";
            message.SubjectEncoding = Encoding.UTF8;
            client.Send(message);

            message.Dispose();
        }
    }
}