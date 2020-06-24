using System;
using System.IO;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Helpers
{
    public static class LogHelper
    {
        public static void Write(string message, TextWriter writer)
        {
            writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{message}");
        }
    }
}