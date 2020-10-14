using ApiGetOrders.Models.Response;
using System.Collections;
using System.Threading.Tasks;

namespace ApiGetOrders.Sevices.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable> GetOrdersAsync();
        Task<RequestTokenData> GetRequestToken();
        Task<bool> Login();
    }
}
