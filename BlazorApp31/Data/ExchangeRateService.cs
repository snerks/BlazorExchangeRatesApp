using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp31.Data
{
    public class ExchangeRateService
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        public ExchangeRateService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public IHttpClientFactory HttpClientFactory { get; }

        public async Task<ExchangeRateLatestResponse> GetLatestAsync()
        {
            //var rng = new Random();
            //return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = startDate.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //}).ToArray());

            var url = "https://api.exchangeratesapi.io/latest?base=GBP";

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            //request.Headers.Add("Accept", "application/vnd.github.v3+json");
            //request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var httpClient = HttpClientFactory.CreateClient();

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var result = 
                    JsonSerializer.Deserialize<ExchangeRateLatestResponse>(responseString, options);

                return result;
            }
            else
            {
                //GetBranchesError = true;
                return new ExchangeRateLatestResponse();
            }
        }
    }
}
