using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Data
{
    public class TicketService : ITicketService
    {
        private HttpClient client;

        public TicketService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<string> Create(HelpTicket ticket)
        {
            var respone = await client.PostAsJsonAsync("/api/ticket", ticket);
            return await respone.Content.ReadAsStringAsync();
        }

        public async Task<List<HelpTicket>> GetAll()
        {
            return await client.GetFromJsonAsync<List<HelpTicket>>("/api/tickets");
        }
    }
}
