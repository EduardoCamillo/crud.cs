using Microsoft.AspNetCore.Mvc;

namespace crudProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
