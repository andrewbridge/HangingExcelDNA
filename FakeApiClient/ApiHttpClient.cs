using System;
using System.Collections.Generic;
using System.Text;

namespace FakeApiClient
{
    using System.ComponentModel;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    class ApiHttpClient
    {
        private readonly HttpClient client;

        private readonly TokenClient tokenClient;

        public ApiHttpClient()
        {
            this.client = FakeApiClient.Client; /*new HttpClient();*/
            if (this.client.BaseAddress == default)
            {
                this.client.BaseAddress = new Uri("https://reqres.in/api/");
                this.client.Timeout = TimeSpan.FromMinutes(3);
                this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ServicePointManager.DefaultConnectionLimit = 5000;
            }

            this.tokenClient = FakeApiClient.TokenClient;
        }

        /*~ApiHttpClient()
        {
            this.client.Dispose();
        }*/

        /// <summary>
        /// The post as json async.
        /// </summary>
        /// <param name="requestUri">
        /// The request uri.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="typeNameHandling">
        /// The type name handling.
        /// </param>
        /// <typeparam name="Tin">
        /// </typeparam>
        /// <typeparam name="Tout">
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Tout> PostAsJsonAsync<Tin, Tout>(string requestUri, Tin value, TypeNameHandling typeNameHandling = TypeNameHandling.Objects) where Tout : class
        {
            return await this.PostAsJsonAsync<Tin, Tout>(requestUri, value, CancellationToken.None, typeNameHandling);
        }

        /// <summary>
        /// The post as json async.
        /// </summary>
        /// <param name="requestUri">
        /// The request uri.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <param name="typeNameHandling">
        /// The type name handling.
        /// </param>
        /// <typeparam name="Tin">
        /// </typeparam>
        /// <typeparam name="Tout">
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Tout> PostAsJsonAsync<Tin, Tout>(string requestUri, Tin value, CancellationToken cancellationToken, TypeNameHandling typeNameHandling) where Tout : class
        {
            var token = await this.tokenClient.GetAccessToken();
            var json = JsonConvert.SerializeObject(value);
            var request = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await this.client.PostAsync(requestUri, request, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await ReadAsTypedAsync<Tout>(response);
        }

        /// <summary>
        /// The get async.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<T> GetAsync<T>(string path) where T : class
        {
            var token = await this.tokenClient.GetAccessToken();
            var httpResponseMessage = await this.client.GetAsync(path);
            httpResponseMessage.EnsureSuccessStatusCode();
            return await ReadAsTypedAsync<T>(httpResponseMessage);
        }

        /// <summary>
        /// The read as typed async.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private static async Task<T> ReadAsTypedAsync<T>(HttpResponseMessage message) where T : class
        {
            string json = await message.Content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }
    }
}
