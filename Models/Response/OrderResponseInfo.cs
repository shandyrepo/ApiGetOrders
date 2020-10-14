using System.Collections.Generic;

namespace ApiGetOrders.Models.Response
{
    public class OrderResponseInfo
    {
        public ICollection<Orders> Result { get; set; }
    }
}
