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
    public class TabelaDescritivaConteudoController : Controller
    {
        private readonly eCommerceContext _context;

        public TabelaDescritivaConteudoController(eCommerceContext context)
        {
            _context = context;
        }

        // GET: TabelaDescritivaConteudo
        public async Task<IActionResult> Index()
        {
            var eCommerceContext = _context.TabelaDescritivaConteudos.Include(t => t.IdTabelaDescritivaNavigation);
            return View(await eCommerceContext.ToListAsync());
        }

        // GET: TabelaDescritivaConteudo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaDescritivaConteudo = await _context.TabelaDescritivaConteudos
                .Include(t => t.IdTabelaDescritivaNavigation)
                .FirstOrDefaultAsync(m => m.IdTabelaDescritivaConteudo == id);
            if (tabelaDescritivaConteudo == null)
            {
                return NotFound();
            }

            return View(tabelaDescritivaConteudo);
        }

        // GET: TabelaDescritivaConteudo/Create
        public IActionResult Create()
        {
            ViewData["IdTabelaDescritiva"] = new SelectList(_context.TabelaDescritivas, "IdTabelaDescritiva", "Nome");
            return View();
        }

        // POST: TabelaDescritivaConteudo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTabelaDescritivaConteudo,IdTabelaDescritiva,Descricao")] TabelaDescritivaConteudo tabelaDescritivaConteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabelaDescritivaConteudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTabelaDescritiva"] = new SelectList(_context.TabelaDescritivas, "IdTabelaDescritiva", "Nome", tabelaDescritivaConteudo.IdTabelaDescritiva);
            return View(tabelaDescritivaConteudo);
        }

        // GET: TabelaDescritivaConteudo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaDescritivaConteudo = await _context.TabelaDescritivaConteudos.FindAsync(id);
            if (tabelaDescritivaConteudo == null)
            {
                return NotFound();
            }
            ViewData["IdTabelaDescritiva"] = new SelectList(_context.TabelaDescritivas, "IdTabelaDescritiva", "Nome", tabelaDescritivaConteudo.IdTabelaDescritiva);
            return View(tabelaDescritivaConteudo);
        }

        // POST: TabelaDescritivaConteudo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTabelaDescritivaConteudo,IdTabelaDescritiva,Descricao")] TabelaDescritivaConteudo tabelaDescritivaConteudo)
        {
            if (id != tabelaDescritivaConteudo.IdTabelaDescritivaConteudo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabelaDescritivaConteudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabelaDescritivaConteudoExists(tabelaDescritivaConteudo.IdTabelaDescritivaConteudo))
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
            ViewData["IdTabelaDescritiva"] = new SelectList(_context.TabelaDescritivas, "IdTabelaDescritiva", "Nome", tabelaDescritivaConteudo.IdTabelaDescritiva);
            return View(tabelaDescritivaConteudo);
        }

        // GET: TabelaDescritivaConteudo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaDescritivaConteudo = await _context.TabelaDescritivaConteudos
                .Include(t => t.IdTabelaDescritivaNavigation)
                .FirstOrDefaultAsync(m => m.IdTabelaDescritivaConteudo == id);
            if (tabelaDescritivaConteudo == null)
            {
                return NotFound();
            }

            return View(tabelaDescritivaConteudo);
        }

        // POST: TabelaDescritivaConteudo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabelaDescritivaConteudo = await _context.TabelaDescritivaConteudos.FindAsync(id);
            _context.TabelaDescritivaConteudos.Remove(tabelaDescritivaConteudo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabelaDescritivaConteudoExists(int id)
        {
            return _context.TabelaDescritivaConteudos.Any(e => e.IdTabelaDescritivaConteudo == id);
        }
    }
}
