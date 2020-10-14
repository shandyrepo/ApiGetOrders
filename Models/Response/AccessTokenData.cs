namespace ApiGetOrders.Models.Response
{
    public class AccessTokenData
    {
        public string AccessToken { get; set; }
        public int Expires { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
    }
}
