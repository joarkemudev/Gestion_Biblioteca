using Gestion_Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Sockets;

namespace Gestion_Biblioteca.Controllers
{
    public class AutoresController : Controller
    {
        private readonly GBContext _context;

        public AutoresController(GBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Autores = _context.Autores;
            return View(Autores);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nombre")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Autores.Add(autor);
                _context.SaveChanges();
                return RedirectToAction("Index", "libros");
            }

            return View(autor);
        }

    }
}

