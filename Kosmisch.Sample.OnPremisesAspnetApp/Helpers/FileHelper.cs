using System;
using System.IO;
using System.Web;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Helpers
{
    /// <summary>
    /// ファイル操作用ヘルパークラス
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// ファイルをローカルに保存する
        /// </summary>
        /// <param name="path">保存先フォルダパス</param>
        /// <param name="file"><see cref="HttpPostedFileBase"/></param>
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
                LogHelper.Write(path, e.Message);
            }
            finally
            {
                outputFile.Close();
                m.Close();
            }
        }
    }
}