using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text;
using System.Text.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory clientFactory;

        public List<SurveyItem> SurveyResults { get; set; }
        public IDictionary<string, string> OrderStats { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            IHttpClientFactory factory)
        {
            _logger = logger;
            this.clientFactory = factory;
        }

        public async Task<IActionResult> OnGet()
        {
            var client = clientFactory.CreateClient();

            var response = await client
                .GetAsync("https://wiredbraincoffeeadmin.azurewebsites.net/api/orderstats");

            var responseData = await response.Content.ReadAsStringAsync();
            
            OrderStats = JsonSerializer
                .Deserialize<IDictionary<string, string>>(responseData);

            var rawJson = System.IO.File
                .ReadAllText("wwwroot/sampledata/survey.json");

            SurveyResults = JsonSerializer.Deserialize<List<SurveyItem>>(rawJson);

            return Page();
        }
    }
}