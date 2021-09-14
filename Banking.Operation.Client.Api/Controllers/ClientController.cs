using Microsoft.AspNetCore.Mvc;

namespace Banking.Operation.Client.Api.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
