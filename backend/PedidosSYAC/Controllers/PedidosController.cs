using Microsoft.AspNetCore.Mvc;

namespace PedidosSYAC.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
