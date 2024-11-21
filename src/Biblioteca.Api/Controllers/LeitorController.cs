using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    public class LeitorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
