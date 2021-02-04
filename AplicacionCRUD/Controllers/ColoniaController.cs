using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicacionCRUD.Models;

namespace AplicacionCRUD.Controllers
{
    public class ColoniaController : Controller
    {
        private readonly TESTContext _context;

        public ColoniaController(TESTContext context)
        {
            _context = context;
        }

        // GET: Colonia
        public async Task<IActionResult> Index()
        {
            var tESTContext = _context.Colonia.Include(c => c.IdDelMunNavigation);
            return View(await tESTContext.ToListAsync());
        }

        // GET: Colonia/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colonia = await _context.Colonia
                .Include(c => c.IdDelMunNavigation)
                .FirstOrDefaultAsync(m => m.IdColonia == id);
            if (colonia == null)
            {
                return NotFound();
            }

            return View(colonia);
        }

        // GET: Colonia/Create
        public IActionResult Create()
        {
            ViewData["IdDelMun"] = new SelectList(_context.DelegacionMunicipio, "IdDelMun","Nombre");
            return View();
        }

        // POST: Colonia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdColonia,IdDelMun,Nombre")] Colonia colonia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colonia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDelMun"] = new SelectList(_context.DelegacionMunicipio, "IdDelMun", "IdDelMun", colonia.IdDelMun);
            return View(colonia);
        }

        // GET: Colonia/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colonia = await _context.Colonia.FindAsync(id);
            if (colonia == null)
            {
                return NotFound();
            }
            ViewData["IdDelMun"] = new SelectList(_context.DelegacionMunicipio, "IdDelMun", "IdDelMun", colonia.IdDelMun);
            return View(colonia);
        }

        // POST: Colonia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdColonia,IdDelMun,Nombre")] Colonia colonia)
        {
            if (id != colonia.IdColonia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colonia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColoniaExists(colonia.IdColonia))
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
            ViewData["IdDelMun"] = new SelectList(_context.DelegacionMunicipio, "IdDelMun", "IdDelMun", colonia.IdDelMun);
            return View(colonia);
        }

        // GET: Colonia/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colonia = await _context.Colonia
                .Include(c => c.IdDelMunNavigation)
                .FirstOrDefaultAsync(m => m.IdColonia == id);
            if (colonia == null)
            {
                return NotFound();
            }

            return View(colonia);
        }

        // POST: Colonia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var colonia = await _context.Colonia.FindAsync(id);
            _context.Colonia.Remove(colonia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColoniaExists(long id)
        {
            return _context.Colonia.Any(e => e.IdColonia == id);
        }
    }
}
