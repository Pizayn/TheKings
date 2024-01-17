using TheKings.API.Entities;
using Newtonsoft.Json;
using System.Net.Http;

namespace TheKings.API.Data
{
    public class MonarchContextSeed
    {
        public static async Task SeedAsync(MonarchContext monarchContext, ILogger<MonarchContextSeed> logger)
        {
            if (!monarchContext.Monarches.Any())
            {
                var monarchs = await FetchMonarchsAsync();
                monarchContext.Monarches.AddRange(monarchs);
                await monarchContext.SaveChangesAsync();
                logger.LogInformation("Seeded database associated with context {DbContextName}", typeof(MonarchContext).Name);
            }
        }

        private static async Task<List<Monarch>> FetchMonarchsAsync()
        {
            string url = "https://gist.githubusercontent.com/christianpanton/10d65ccef9f29de3acd49d97ed423736/raw/b09563bc0c4b318132c7a738e679d4f984ef0048/kings";
            using HttpClient client = new HttpClient();
            string jsonData = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Monarch>>(jsonData);
        }
    }
}
