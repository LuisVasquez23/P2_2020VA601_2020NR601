using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2020VA601_2020NR601.Data;
using P2_2020VA601_2020NR601.Models;

namespace P2_2020VA601_2020NR601.Controllers
{
    public class GenerosController : Controller
    {
        private readonly CovidDBContext _context;

        public GenerosController(CovidDBContext context)
        {
            _context = context;
        }

        // GET: Generos
        public async Task<IActionResult> Index()
        {
              return _context.generos != null ? 
                          View(await _context.generos.ToListAsync()) :
                          Problem("Entity set 'CovidDBContext.generos'  is null.");
        }

        // GET: Generos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.generos == null)
            {
                return NotFound();
            }

            var generos = await _context.generos
                .FirstOrDefaultAsync(m => m.id == id);
            if (generos == null)
            {
                return NotFound();
            }

            return View(generos);
        }

        // GET: Generos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Generos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,genero")] Generos generos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generos);
        }

        // GET: Generos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.generos == null)
            {
                return NotFound();
            }

            var generos = await _context.generos.FindAsync(id);
            if (generos == null)
            {
                return NotFound();
            }
            return View(generos);
        }

        // POST: Generos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,genero")] Generos generos)
        {
            if (id != generos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenerosExists(generos.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(generos);
        }

        // GET: Generos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.generos == null)
            {
                return NotFound();
            }

            var generos = await _context.generos
                .FirstOrDefaultAsync(m => m.id == id);
            if (generos == null)
            {
                return NotFound();
            }

            return View(generos);
        }

        // POST: Generos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.generos == null)
            {
                return Problem("Entity set 'CovidDBContext.generos'  is null.");
            }
            var generos = await _context.generos.FindAsync(id);
            if (generos != null)
            {
                _context.generos.Remove(generos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenerosExists(int id)
        {
          return (_context.generos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
