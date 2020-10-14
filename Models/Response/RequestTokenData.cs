namespace ApiGetOrders.Models.Response
{
    public class RequestTokenData
    {
        public string RequestToken { get; set; }
        public bool Success { get; set; }

        public int Expires { get; set; }
    }
}
