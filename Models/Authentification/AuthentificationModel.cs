namespace ApiGetOrders.Models.Authentification
{
    public class AuthentificationModel
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string BaseUrl { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
