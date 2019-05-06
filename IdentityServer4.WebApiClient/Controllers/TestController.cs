namespace IdentityServer4.WebApiClient.Controllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using IdentityModel.Client;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class TestController : Controller
    {
        #region Methods

        // GET api/values
        [HttpGet]
        public async Task<string> GetAsync()
        {
            // Get token
            var token = GetToken().GetAwaiter().GetResult();

            // Generate a client with the access token
            var client = new HttpClient();
            client.SetBearerToken(token.AccessToken);

            // Get data from test API
            var response = await client.GetAsync("http://localhost:5001/api/test");

            // Check response code
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error at call to web api");

            // Return content data
            return await response.Content.ReadAsStringAsync();
        }

        private static async Task<TokenResponse> GetToken()
        {
            // Discover the client
            var discover = await DiscoveryClient.GetAsync("http://localhost:5000");

            // Check errors
            if (discover.IsError)
                throw new Exception("Error at discover client");

            // Generate a client token (send client and secret key)
            var clientToken = new TokenClient(discover.TokenEndpoint, "cliente1", "secreto1");

            // Get access token to resurce "resourceApi1"
            var token = await clientToken.RequestClientCredentialsAsync("resourceApi1");

            // Check errors
            if (token.IsError)
                throw new Exception("Error at request client credentials");

            // Return token
            return token;
        }

        #endregion
    }
}