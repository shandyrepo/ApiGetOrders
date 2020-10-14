namespace ApiGetOrders.Models.Response
{
    public class Orders
    {
        public string Id { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; }
        public AdressInfo DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
