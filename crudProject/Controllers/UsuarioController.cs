using crudProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace crudProject.Controllers
{
    public class UsuarioController : Controller
    {
        //get User
        public IActionResult Index()
        {
            using(UsuarioModel model =  new UsuarioModel())
            {
                List<UsuarioWeb> lista = model.Read();
                return View(lista);
            }   
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            UsuarioWeb usuario = new UsuarioWeb();
            usuario.nome = form["nome"];
            usuario.email= form["email"];

            using (UsuarioModel model = new UsuarioModel())
            {
                model.Create(usuario);
                return RedirectToAction("Index");
            }
        }

    }
}
