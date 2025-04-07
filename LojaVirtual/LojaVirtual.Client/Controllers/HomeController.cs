using System.Diagnostics;
using LojaVirtual.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Client.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
