using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceTest.Services
{
    public class TriviaService
    {
        private HttpClient Client;
        private JsonSerializerOptions options;
        const string URL = @"https://zr8z94hw-44376.euw.devtunnels.ms/AmericanQuestions";
        public TriviaService()
        {
            Client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
            };
        }
        public async Task<string> CheckConnectionAsync()
        {
            var response = await Client.GetAsync($@"{URL}/GetQuestions");
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}
