
using Microsoft.AspNetCore.Mvc;
using SustentavelStartUp.Models;
using SustentavelStartUp.Repository;

namespace SustentavelStartUp.Controllers
{
    public class UsuarioController : Controller
    {

        private UsuarioRepository usuarioRepository;

        public UsuarioController()
        {

            usuarioRepository = new UsuarioRepository();
        }

        public IActionResult Index()
        {
            // Retornando para View a lista de Representantes
            var lista = usuarioRepository.Listar();

            return View(lista);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Cadastrar()
        {
            // Retorna para a View Cadastrar um 
            // objeto modelo com as propriedades em branco 
            return View(new UsuarioModel());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {

                usuarioRepository.Inserir(usuario);

                TempData["mensagem"] = "Usuario cadastrado com sucesso";
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                return View(usuario);
            }
        }


        [HttpGet]
        public IActionResult Editar([FromRoute] int id)
        {
            var usuario = usuarioRepository.Consultar(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioRepository.Alterar(usuario);

                TempData["mensagem"] = "Usuario alterado com sucesso";
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                return View(usuario);
            }

        }


        [HttpGet]
        public IActionResult Consultar(int id)
        {
            var usuario = usuarioRepository.Consultar(id);
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            usuarioRepository.Excluir(id);

            TempData["mensagem"] = "Usuario excluído com sucesso";
            return RedirectToAction("Index", "Usuario");
        }


    }
}