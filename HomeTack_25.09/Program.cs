
using Newtonsoft.Json;
using System.Text;

namespace HomeTack
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await GetAllCompaniesAsync();
            await PostCompanyAsync("CompanyName");
            await PutCompanyAsync(1);
            await DeleteCompanyAsync(1);

        }
        static async Task GetAllCompaniesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responce = await client.GetAsync("https://localhost:7153/api/Company/GetAllCompanies");
                var result = await responce.Content.ReadAsStringAsync();
                await Console.Out.WriteLineAsync(result);
            }
        }

        static async Task<string> PostCompanyAsync(string companyName)
        {
            var json = JsonConvert.SerializeObject(companyName);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            string url = "https://localhost:7153/api/Company/PostCompany";
            string responce;

            using (HttpClient client = new HttpClient())
            {
                responce = await client.PostAsync(url, content).Result.Content.ReadAsStringAsync();
            }
            return responce;
        }

        static async Task<string> PutCompanyAsync(int companyid)
        {
            string responce;

            using (HttpClient client = new HttpClient())
            {
                string query = string.Format("https://localhost:7153/api/Products/PutCompanyAsync/?id={1}", companyid);
                HttpContent content = new StringContent(query, Encoding.UTF8, "application/json");
                responce = await client.PutAsync(query, content).Result.Content.ReadAsStringAsync();
            }
            return responce;
        }

        static async Task<string> DeleteCompanyAsync(int id)
        {
            string responce = "";
            using (HttpClient client = new HttpClient())
            {
                string query = string.Format("https://localhost:7153/api/Products/DeleteCompanyAsync/?id={1}", id);
                var result = await client.DeleteAsync(query);
            }
            return responce;
        }
    }
}


