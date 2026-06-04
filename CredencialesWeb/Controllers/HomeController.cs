using CredencialesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using CredencialesWeb.Services;

namespace CredencialesWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly CredencialesContext _db;

        public HomeController(CredencialesContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Menu> lista = new List<Menu>();
            var ctx = new CredencialesService(_db);
            lista.Clear();
            lista.AddRange(await ctx.GetMenu());
            return View(lista);
        }
    }
}