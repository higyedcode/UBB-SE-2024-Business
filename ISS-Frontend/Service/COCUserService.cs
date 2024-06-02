using System.Text;
using Newtonsoft.Json;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Celebration_Of_Capitalism___The_Finale.Models;

namespace Celebration_Of_Capitalism___The_Finale.Services
{
    public class COCUserService : ICOCUserService
    {
        static string endpoint = "http://localhost:5049";
        public int AddUser(COCUser user)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                HttpResponseMessage response = Task.Run(() => client.PostAsync(endpoint + "/api/cocusers", content)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                COCUser? result = JsonConvert.DeserializeObject<COCUser>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }

                return result.Id;
            }
            catch
            {
                return -1;
            }
        }

        public int UserExists(COCUser user)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocusers")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCUser>? result = JsonConvert.DeserializeObject<List<COCUser>>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }

                List<COCUser> parsedResult = result.Where(member => member.Username == user.Username && member.Password == user.Password).ToList();
                if (parsedResult.Count > 0)
                {
                    return parsedResult[0].Id;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.DeleteAsync(endpoint + "/api/cocusers/" + id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<COCUser> GetAllUsers()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocusers")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCUser>? result = JsonConvert.DeserializeObject<List<COCUser>>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public COCUser? GetUser(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocusers" + id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCUser>? result = JsonConvert.DeserializeObject<List<COCUser>>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }
                return result[0];
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateUser(int id, COCUser user)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                HttpResponseMessage response = Task.Run(() => client.PutAsync(endpoint + "/api/cocusers" + id, content)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
