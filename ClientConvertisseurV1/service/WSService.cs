using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ClientConvertisseurV1.Model;

namespace ClientConvertisseurV1.service
{
    class WSService
    {
        public HttpClient client;

        public WSService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1970/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<Model.Devise>> GetAllDevisesAsync()
        {
            List<Devise> ld= new List<Devise>();
            HttpResponseMessage response = await client.GetAsync("Devise");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<List<Devise>>();
                ld = (List<Devise>) result;

            }
            return ld;
        }
    }
}
