using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcapppojisteniverze02.Data;
using mvcapppojisteniverze02.Models;

namespace mvcapppojisteniverze02.Controllers
{
    public class KlientsController : Controller
    {
        private readonly mvcapppojisteniverze02Context _context;

        public KlientsController(mvcapppojisteniverze02Context context)
        {
            _context = context;
        }

        // GET: Klients
        public async Task<IActionResult> Index(string? akce)
        {
            ViewBag.akce = akce;
            
            return _context.Klienti != null ?
                          View(await _context.Klienti.ToListAsync()) :
                          Problem("Entity set 'mvcapppojisteniverze02Context.Klient'  is null.");

        }

        // GET: Klients/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.Klienti == null)
            {
                return NotFound();
            }

            var klient = await _context.Klienti
                .Include(s => s.ZaznamPojisteniKolekce)
                .ThenInclude(e => e.Produkt)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // GET: Klients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Jmeno,Prijmeni,Telefon,Email,Ulice,Mesto,Psc")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klient);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Klients", new { akce = "nový" });
                //return RedirectToAction(nameof(Index));
            }
            return View(klient);
        }

        // GET: Klients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klienti == null)
            {
                return NotFound();
            }

            var klient = await _context.Klienti.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            return View(klient);
        }

        // POST: Klients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Jmeno,Prijmeni,Telefon,Email,Ulice,Mesto,Psc")] Klient klient)
        {
            if (id != klient.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.ID))
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
            return View(klient);
        }

        // GET: Klients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klienti == null)
            {
                return NotFound();
            }

            var klient = await _context.Klienti
                .FirstOrDefaultAsync(m => m.ID == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // POST: Klients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klienti == null)
            {
                return Problem("Entity set 'mvcapppojisteniverze02Context.Klient'  is null.");
            }
            var klient = await _context.Klienti.FindAsync(id);
            if (klient != null)
            {
                _context.Klienti.Remove(klient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Klients", new { akce = "odstranit" });
            //return RedirectToAction(nameof(Index));
        }

        private bool KlientExists(int id)
        {
            return (_context.Klienti?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
