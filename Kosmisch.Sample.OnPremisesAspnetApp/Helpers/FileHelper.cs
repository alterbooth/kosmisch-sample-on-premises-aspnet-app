using System;
using System.IO;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Helpers
{
    public class FileHelper
    {
        public static void WriteJson(string path, string json)
        {
            Directory.CreateDirectory(path);

            using (var w = File.AppendText($@"{path}\sample-data-{DateTime.Now.ToString("yyyyMMddHHmmss")}.json"))
            {
                w.WriteLine(json);
            }
        }
    }
}