using System.Net.Http;

namespace ISS_Frontend.Service
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class UserService: IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public void LoginUser(string username, string password)
        {

            var loginRequest = new LoginRequest { Username = username, Password = password };


            var response = httpClient.PostAsJsonAsync("api/User/login", loginRequest).Result;

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new InvalidOperationException("Unauthorized. Please check your credentials.");
                }
                else
                {
                    throw new Exception($"Failed to login: {response.ReasonPhrase}");
                }
            }
        }
    }
}
