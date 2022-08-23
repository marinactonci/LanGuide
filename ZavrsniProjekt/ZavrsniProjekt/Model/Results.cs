using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZavrsniProjekt.Model
{
    public class Results
    {
        public int id_user { get; set; }
        public string email { get; set; }
        public string create_time { get; set; }
        public string id_exercise { get; set; }
        public int result_percent { get; set; }
        public int result_score { get; set; }
        public int result_max { get; set; }
        public string skill { get; set; }
        public string language { get; set; }
        public string result_date { get; set; }

        public async static Task<List<Results>> GetResults()
        {
            List<Results> results = new List<Results>();
            var url = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=results&limit=300");

            HttpClient client = new HttpClient();

            var response = client.GetAsync(url).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var resultRoot = JsonConvert.DeserializeObject<ResultRoot>(json);
                results = resultRoot.data as List<Results>;
            }

            return results;
        }
    }

    public class ResultRoot
    {
        public int error { get; set; }
        public string msg { get; set; }
        public IList<Results> data { get; set; }
    }
}
