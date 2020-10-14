using ApiGetOrders.Models.Response;
using System.Collections;
using System.Threading.Tasks;

namespace ApiGetOrders.Sevices.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable> GetOrdersAsync();
        Task<bool> Login();
    }
}
