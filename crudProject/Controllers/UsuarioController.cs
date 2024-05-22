using crudProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


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
                ViewData["UsuarioCount"] = lista.Count;
                return View(lista);
            }   
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            UsuarioWeb usuario = new UsuarioWeb();
            usuario.nome = form["nome"];
            usuario.email= form["email"];

            using (UsuarioModel model = new UsuarioModel())
            {
                model.Create(usuario);
                return RedirectToAction("index");
            }
        }

    }
}
