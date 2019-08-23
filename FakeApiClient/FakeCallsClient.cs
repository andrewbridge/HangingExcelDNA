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
            return await GetColoursWithDelayAsync(request, 0);
        }

        public async Task<ColoursResponse> GetColoursSlowlyAsync(DetailsRequest request)
        {
            return await GetColoursWithDelayAsync(request, 5);
        }

        public async Task<ColoursResponse> GetColoursVerySlowlyAsync(DetailsRequest request)
        {
            return await GetColoursWithDelayAsync(request, 9);
        }

        public async Task<ColoursResponse> GetColoursTooSlowlyAsync(DetailsRequest request)
        {
            return await GetColoursWithDelayAsync(request, 15);
        }

        public async Task<ColoursResponse> GetColoursWithDelayAsync(DetailsRequest request, int delay)
        {
            // return await this.httpClient.PostAsJsonAsync<DetailsRequest, ColoursResponse>("unknown" + (delay == 0 ? "" : $"?delay={delay}"), request);
            // return await this.httpClient.PostAsJsonAsync<DetailsRequest, ColoursResponse>("unknown" + (delay == 0 ? "" : $"?delay={delay}"), request);
            await Task.Delay(TimeSpan.FromSeconds(delay));
            return new ColoursResponse { };
        }
    }
}
