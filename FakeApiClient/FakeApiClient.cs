using System;

namespace FakeApiClient
{
    using System.Net.Http;

    internal class FakeApiClient
    {
        public static HttpClient Client = new HttpClient();

        public static TokenClient TokenClient = new TokenClient();
    }
}
