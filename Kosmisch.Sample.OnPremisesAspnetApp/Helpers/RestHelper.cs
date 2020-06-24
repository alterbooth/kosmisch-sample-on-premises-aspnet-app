using System.Net.Http;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Helpers
{
    public static class RestHelper
    {
        static readonly HttpClient client = new HttpClient();

        public static string Get()
        {
            var response = client.GetAsync("http://kosmischsample.net/").ConfigureAwait(false).GetAwaiter().GetResult();
            var responseBody = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return responseBody;
        }
    }
}