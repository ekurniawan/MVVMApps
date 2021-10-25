using MVVMApps.Services;
using MVVMApps.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

//[assembly: Dependency(typeof(CoffeeService))]
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

        public async Task AddCoffee(Coffee coffee)
        {
            var uri = new Uri($"{baseUrl}/api/Coffee");
            try
            {
                var json = JsonConvert.SerializeObject(coffee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Gagal menambahkan data coffee");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task EditCoffee(int id, Coffee coffee)
        {
            var uri = new Uri($"{baseUrl}/api/Coffee/{id}");
            try
            {
                var json = JsonConvert.SerializeObject(coffee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Gagal update data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Coffee> GetCofeeById(int id)
        {
            Coffee coffee = new Coffee();
            var uri = new Uri($"{baseUrl}/api/Coffee/{id}");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    coffee = JsonConvert.DeserializeObject<Coffee>(content);
                }
                return coffee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
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

        public async Task RemoveCoffee(int id)
        {
            var uri = new Uri($"{baseUrl}/api/Coffee/{id}");
            try
            {
                var response = await _client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Gagal untuk delete data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
