using Gestion_Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Sockets;

namespace Gestion_Biblioteca.Controllers
{
    public class LibrosController : Controller
    {
        private readonly GBContext _context;

        public LibrosController(GBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var libros = _context.Libros.Include(l => l.Autor).ToList();
            return View(libros);
        }

        public IActionResult Create()
        {
            // Crea un SelectList para los autores y lo pasa a la vista
            ViewBag.AutorID = new SelectList(_context.Autores, "AutorID", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Titulo,AutorID")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Libros.Add(libro);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    // Captura de errores de actualización en la base de datos
                    ModelState.AddModelError("", "Error al guardar en la base de datos: " + ex.Message);
                }
            }
            else
            {
                // Imprimir errores en la consola para depuración
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            // Si el modelo no es válido, se pasa el SelectList nuevamente a la vista
            ViewBag.AutorID = new SelectList(_context.Autores, "AutorID", "Nombre", libro.AutorID);
            return View(libro);
        }
    }
}