namespace IdentityServer4.WebServer
{
    using IdentityServer4.Models;
    using System.Collections.Generic;

    public static class Config
    {
        #region Methods

        /* You can show configuration of Identity Server 4, on
         * http://localhost:5000/.well-known/openid-configuration */

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                /* ClientID "cliente1", 
                 * with token "secreto1" at SHA256,
                 * with resource access "resourceApi1" and "resourceApi2" */
                new Client()
                {
                    ClientId = "cliente1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secreto1".Sha256()) },
                    AllowedScopes = { "resourceApi1", "resourceApi2" }
                },
                
                /* ClientID "cliente2", 
                 * with token "secreto2" at SHA256,
                 * with resource access "resourceApi3" and "resourceApi4" */
                new Client()
                {
                    ClientId = "cliente2",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secreto2".Sha256()) },
                    AllowedScopes = { "resourceApi3", "resourceApi4" }
                },
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("resourceApi1", "Mi recurso 1"),
                new ApiResource("resourceApi2", "Mi recurso 2"),
                new ApiResource("resourceApi3", "Mi recurso 3"),
                new ApiResource("resourceApi4", "Mi recurso 4"),
            };
        }

        #endregion
    }
}