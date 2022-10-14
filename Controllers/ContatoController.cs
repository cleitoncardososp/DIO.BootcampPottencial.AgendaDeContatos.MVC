using Dio.AgendaDeContatos.Context;
using Dio.AgendaDeContatos.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dio.AgendaDeContatos.MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaDeContatos = _context.Contatos.ToList();

            return View(listaDeContatos);
        }

        [HttpGet("contato/novo-contato")]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost("contato/novo-contato")]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = "Informações incompletas ou incorretas!!!";
            return View(contato);
        }

        [HttpGet("contato/editar-contato/{id}")]
        public IActionResult Editar([FromRoute] int id)
        {
            Contato contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        [HttpPost("contato/editar-contato/{id}")]
        public IActionResult Editar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Update(contato);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = "Informações incompletas ou incorretas!!!";
            return View(contato);
        }

        [HttpGet("contato/detalhes-contato/{id}")]
        public IActionResult Detalhes([FromRoute] int id)
        {
            Contato contato = _context.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        [HttpGet("contato/deletar-contato/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Contato contato = _context.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        [HttpPost("contato/deletar-contato/{id}")]
        public IActionResult Deletar(Contato contato)
        {
            if(contato == null)
                return RedirectToAction(nameof(Index));

            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
