using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        string baseUrl = "https://localhost:7185/api/v1/monarch";

        // Making requests to each endpoint
        string totalMonarchs = await GetApiDataAsync($"{baseUrl}/stats/total");
        string longestRulingMonarch = await GetApiDataAsync($"{baseUrl}/stats/longestRulingMonarch");
        string mostCommonFirstName = await GetApiDataAsync($"{baseUrl}/stats/mostCommonFirstName");
        string longestRulingHouse = await GetApiDataAsync($"{baseUrl}/stats/longestRulingHouse");

        // Output the results
        Console.WriteLine($"Total Monarchs: {totalMonarchs}");
        Console.WriteLine($"Longest Ruling Monarch: {longestRulingMonarch}");
        Console.WriteLine($"Most Common First Name: {mostCommonFirstName}");
        Console.WriteLine($"Longest Ruling House: {longestRulingHouse}");
    }

    static async Task<string> GetApiDataAsync(string url)
    {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        // Since your API returns direct string values or integers, no complex deserialization is needed
        return responseBody;
    }
}
