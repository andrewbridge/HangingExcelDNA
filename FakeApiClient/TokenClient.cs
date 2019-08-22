namespace FakeApiClient
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using global::FakeApiClient.ResponseTypes;

    using Newtonsoft.Json;

    public class TokenClient
    {
        private readonly HttpClient client;

        private readonly string identityUrl = "https://reqres.in/api/";

        private readonly string tokenEndpoint;

        private string accessToken;

        public TokenClient()
        {
            this.client = FakeApiClient.Client; /*new HttpClient();*/
            this.tokenEndpoint = new Uri(new Uri(this.identityUrl), "/api/login").ToString();
        }

        /*~TokenClient()
        {
            this.client.Dispose();
        }*/

        public async Task<string> GetAccessToken()
        {
            if (this.accessToken == null)
            {
                await this.SetAccessTokenAsync();
            }

            return this.accessToken;
        }

        private async Task SetAccessTokenAsync(bool retry = false)
        {
            var response = await this.client.PostAsync(
                               this.tokenEndpoint,
                               new StringContent("{ \"email\": \"janet.weaver@reqres.in\", \"password\": \"password\" }", Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            try
            {
                var content = JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());
                this.accessToken = content.token;
            }
            catch (Exception e)
            {
                throw new Exception("The fake response did not contain a token.");
            }
        }
    }
}