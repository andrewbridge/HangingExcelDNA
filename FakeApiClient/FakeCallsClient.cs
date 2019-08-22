using System;
using System.Collections.Generic;
using System.Text;

namespace FakeApiClient
{
    using System.Threading.Tasks;

    using global::FakeApiClient.ResponseTypes;

    public class FakeCallsClient
    {
        private readonly ApiHttpClient httpClient;

        public FakeCallsClient()
        {
            this.httpClient = new ApiHttpClient();
        }

        public async Task<ColoursResponse> GetColoursAsync(DetailsRequest request)
        {
            return await this.httpClient.PostAsJsonAsync<DetailsRequest, ColoursResponse>("unknown", request);
        }

        public async Task<ColoursResponse> GetColoursSlowlyAsync(DetailsRequest request)
        {
            return await this.httpClient.PostAsJsonAsync<DetailsRequest, ColoursResponse>("unknown?delay=5", request);
        }

        public async Task<ColoursResponse> GetColoursVerySlowlyAsync(DetailsRequest request)
        {
            return await this.httpClient.PostAsJsonAsync<DetailsRequest, ColoursResponse>("unknown?delay=9", request);
        }

        public async Task<ColoursResponse> GetColoursTooSlowlyAsync(DetailsRequest request)
        {
            return await this.httpClient.PostAsJsonAsync<DetailsRequest, ColoursResponse>("unknown?delay=15", request);
        }
    }
}
