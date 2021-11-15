using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;//se agrego 
using Microsoft.Extensions.Logging;
using proyecto_udemy.Data;
using proyecto_udemy.Models;

namespace proyecto_udemy.Controllers
{
    public class HomeController : Controller
    {
        //intancio el DBcontax de la carpera data
        private readonly ApplicationDbContext _context;

        //private readonly ILogger<HomeController> _logger; //propiedad no necesaria

        public HomeController(ApplicationDbContext context) //contructor (parametro de la clase ApplicationDbContext)
        {
            _context = context;
        }
        //metodo index 
        [HttpGet] //no es necesario
        //lo convertimos en asincrono 
        public async Task<IActionResult> Index()
        {
            return View(await _context.usuario.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//proteje los formularios 
        public async Task<IActionResult> Create(usuario usuario) {
            if (ModelState.IsValid)//si todos los campos son llenados correctamente
            {
                _context.usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }
            var usuario = _context.usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _context.usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//proteje los formularios 
        public async Task<IActionResult> Edit(usuario usuario)
        {
            if (ModelState.IsValid)//si todos los campos son llenados correctamente
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _context.usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]//acciona al nombre delete, como renombrar funcion
        [ValidateAntiForgeryToken]//proteje los formularios 
        public async Task<IActionResult> DeleteRegistro(int? id)            
        {
            var usuario = await _context.usuario.FindAsync(id);
            if (usuario == null) 
            {
                return View();
            }

            _context.usuario.Remove(usuario);//esto es entitiframewor
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
