using CredencialesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CredencialesWeb.Services;

namespace CredencialesWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly CredencialesContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CredencialesContext db)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Menu> lista = new List<Menu>();
            var ctx = new CredencialesService(_db);
            lista.Clear();
            lista.AddRange(await ctx.GetMenu());
            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}