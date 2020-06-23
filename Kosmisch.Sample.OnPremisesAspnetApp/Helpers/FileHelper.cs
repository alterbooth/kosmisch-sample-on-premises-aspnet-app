using System;
using System.IO;
using System.Web;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Helpers
{
    public static class FileHelper
    {
        public static void Create(string path, HttpPostedFileBase file)
        {
            Directory.CreateDirectory(path);

            var outputFile = File.Create($@"{path}\{file.FileName}");
            var m = new MemoryStream();
            try
            {
                file.InputStream.CopyTo(m);
                var fileBytes = m.ToArray();
                outputFile.Write(fileBytes, 0, fileBytes.Length);
            }
            catch (Exception e)
            {
            }
            finally
            {
                outputFile.Close();
                m.Close();
            }
        }
    }
}