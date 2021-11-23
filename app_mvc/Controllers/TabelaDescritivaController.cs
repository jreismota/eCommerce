using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eCommerce.Models.DataContext;
using eCommerce.Models.Table;

namespace eCommerce.Controllers
{
    public class TabelaDescritivaController : Controller
    {
        private readonly eCommerceContext _context;

        public TabelaDescritivaController(eCommerceContext context)
        {
            _context = context;
        }

        // GET: TabelaDescritiva
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabelaDescritivas.ToListAsync());
        }

        // GET: TabelaDescritiva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaDescritiva = await _context.TabelaDescritivas
                .FirstOrDefaultAsync(m => m.IdTabelaDescritiva == id);
            if (tabelaDescritiva == null)
            {
                return NotFound();
            }

            return View(tabelaDescritiva);
        }

        // GET: TabelaDescritiva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TabelaDescritiva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTabelaDescritiva,Nome")] TabelaDescritiva tabelaDescritiva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabelaDescritiva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabelaDescritiva);
        }

        // GET: TabelaDescritiva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaDescritiva = await _context.TabelaDescritivas.FindAsync(id);
            if (tabelaDescritiva == null)
            {
                return NotFound();
            }
            return View(tabelaDescritiva);
        }

        // POST: TabelaDescritiva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTabelaDescritiva,Nome")] TabelaDescritiva tabelaDescritiva)
        {
            if (id != tabelaDescritiva.IdTabelaDescritiva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabelaDescritiva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabelaDescritivaExists(tabelaDescritiva.IdTabelaDescritiva))
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
            return View(tabelaDescritiva);
        }

        // GET: TabelaDescritiva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaDescritiva = await _context.TabelaDescritivas
                .FirstOrDefaultAsync(m => m.IdTabelaDescritiva == id);
            if (tabelaDescritiva == null)
            {
                return NotFound();
            }

            return View(tabelaDescritiva);
        }

        // POST: TabelaDescritiva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabelaDescritiva = await _context.TabelaDescritivas.FindAsync(id);
            _context.TabelaDescritivas.Remove(tabelaDescritiva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabelaDescritivaExists(int id)
        {
            return _context.TabelaDescritivas.Any(e => e.IdTabelaDescritiva == id);
        }
    }
}
