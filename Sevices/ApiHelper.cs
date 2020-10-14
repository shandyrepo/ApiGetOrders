using ApiGetOrders.Models.Authentification;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
namespace ApiGetOrders.Sevices
{
    public static class ApiHelper
    {
        public static HttpClient Client { get; set; }
        public static void InitializeClient(string baseUrl)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(baseUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static string GeneratePassword(AuthentificationModel authInfo, string requestToken)
        {
            using SHA1 shaInstance = SHA1.Create();
            byte[] bytePass = Encoding.UTF8.GetBytes(requestToken + authInfo.PrivateKey);
            byte[] hashBytes = shaInstance.ComputeHash(bytePass);
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }
    }
}
