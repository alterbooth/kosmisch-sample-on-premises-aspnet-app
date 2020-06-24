using System.Net.Http;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Helpers
{
    /// <summary>
    /// REST API実行用ヘルパークラス
    /// </summary>
    public static class RestHelper
    {
        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// GETリクエストを実行
        /// </summary>
        /// <returns>レスポンスbody</returns>
        public static string Get()
        {
            var response = client.GetAsync("http://kosmischsample.net/").ConfigureAwait(false).GetAwaiter().GetResult();
            var responseBody = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return responseBody;
        }
    }
}