using ApiGetOrders.Sevices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiGetOrders.Controllers
{
    public class HomeController : Controller
    {

        private readonly IApiService _apiService;
        public HomeController(IApiService apiService)
        {
            _apiService = apiService ?? throw new NullReferenceException();
        }

        public async Task<IActionResult> Index()
        {
            bool isLogin = await _apiService.Login();
            return View(isLogin);
        }

        public async Task<IActionResult> GetOrderList()
        {
            var orders = await _apiService.GetOrdersAsync();
            return View(orders);
        }
    }
}
