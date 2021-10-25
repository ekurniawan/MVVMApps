using MVVMApps.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApps.Services
{
    public class CoffeeService : ICoffee
    {
        string baseUrl = "http://20.198.234.1/BackendAPI";
        private HttpClient _client;
        public CoffeeService()
        {
            _client = new HttpClient();
        }

        public Task AddCoffee(Coffee coffee)
        {
            throw new NotImplementedException();
        }

        public Task EditCoffee(int id, Coffee coffee)
        {
            throw new NotImplementedException();
        }

        public Task<Coffee> GetCofeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Coffee>> GetCoffee()
        {
            List<Coffee> lstCoffee = new List<Coffee>();
            var uri = new Uri($"{baseUrl}/api/Coffee");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lstCoffee = JsonConvert.DeserializeObject<List<Coffee>>(content);
                }
                return lstCoffee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public Task RemoveCoffee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
