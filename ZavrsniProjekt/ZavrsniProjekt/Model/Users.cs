using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZavrsniProjekt.Model
{
    public class Users
    {
        public int id_user { get; set; }
        public string email { get; set; }
        public string create_time { get; set; }

        public async static Task<List<Users>> GetUsers()
        {
            List<Users> users = new List<Users>();
            var url = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=users");

            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var userRoot = JsonConvert.DeserializeObject<UserRoot>(json);
                users = userRoot.data as List<Users>;
            }

            return users;
        }
    }

    public class UserRoot
    {
        public int error { get; set; }
        public string msg { get; set; }
        public IList<Users> data { get; set; }
    }
}
