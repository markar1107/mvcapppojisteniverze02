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
    public class ZaznamPojistenisController : Controller
    {
        private readonly mvcapppojisteniverze02Context _context;

        public ZaznamPojistenisController(mvcapppojisteniverze02Context context)
        {
            _context = context;
        }

        // GET: ZaznamPojistenis
        public async Task<IActionResult> Index()
        {
            var mvcapppojisteniverze02Context = _context.ZaznamyPojisteni.Include(z => z.Klient).Include(z => z.Produkt);
            return View(await mvcapppojisteniverze02Context.ToListAsync());
        }

        // GET: ZaznamPojistenis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ZaznamyPojisteni == null)
            {
                return NotFound();
            }

            var zaznamPojisteni = await _context.ZaznamyPojisteni
                .Include(z => z.Klient)
                .Include(z => z.Produkt)
                .FirstOrDefaultAsync(m => m.ZaznamPojisteniID == id);
            if (zaznamPojisteni == null)
            {
                return NotFound();
            }

            return View(zaznamPojisteni);
        }

        // GET: ZaznamPojistenis/Create
        public IActionResult Create()
        {
            //ViewData["KlientID"] = new SelectList(_context.Klienti, "ID", "Prijmeni");
            ViewData["ProduktID"] = new SelectList(_context.Produkty, "ProduktID", "Nazev");
            return View();
        }

        // POST: ZaznamPojistenis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ZaznamPojisteniID,KlientID,ProduktID,Cena,ZacatekPojisteni,KonecPojisteni")] ZaznamPojisteni zaznamPojisteni)
        public async Task<IActionResult> Create([Bind("ZaznamPojisteniID,ProduktID,Cena,ZacatekPojisteni,KonecPojisteni")] ZaznamPojisteni zaznamPojisteni, int id)
        {
            if (ModelState.IsValid)
            {
                zaznamPojisteni.KlientID = id;
                _context.Add(zaznamPojisteni);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                // tohle funguje taky
                //return RedirectToAction("Details", new RouteValueDictionary(
                //new { controller = "Klients", action = "Details", id = zaznamPojisteni.KlientID}));
                return RedirectToAction("Details", "Klients", new { id = zaznamPojisteni.KlientID });
            }
            ViewData["KlientID"] = new SelectList(_context.Klienti, "ID", "ID", zaznamPojisteni.KlientID);
            ViewData["ProduktID"] = new SelectList(_context.Produkty, "ProduktID", "ProduktID", zaznamPojisteni.ProduktID);
            return View(zaznamPojisteni);
        }

        // GET: ZaznamPojistenis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ZaznamyPojisteni == null)
            {
                return NotFound();
            }

            var zaznamPojisteni = await _context.ZaznamyPojisteni.FindAsync(id);
            if (zaznamPojisteni == null)
            {
                return NotFound();
            }
            ViewData["KlientID"] = new SelectList(_context.Klienti, "ID", "ID", zaznamPojisteni.KlientID);
            ViewData["ProduktID"] = new SelectList(_context.Produkty, "ProduktID", "ProduktID", zaznamPojisteni.ProduktID);
            return View(zaznamPojisteni);
        }

        // POST: ZaznamPojistenis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZaznamPojisteniID,KlientID,ProduktID,Cena,ZacatekPojisteni,KonecPojisteni")] ZaznamPojisteni zaznamPojisteni)
        {
            if (id != zaznamPojisteni.ZaznamPojisteniID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zaznamPojisteni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZaznamPojisteniExists(zaznamPojisteni.ZaznamPojisteniID))
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
            ViewData["KlientID"] = new SelectList(_context.Klienti, "ID", "ID", zaznamPojisteni.KlientID);
            ViewData["ProduktID"] = new SelectList(_context.Produkty, "ProduktID", "ProduktID", zaznamPojisteni.ProduktID);
            return View(zaznamPojisteni);
        }

        // GET: ZaznamPojistenis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ZaznamyPojisteni == null)
            {
                return NotFound();
            }

            var zaznamPojisteni = await _context.ZaznamyPojisteni
                .Include(z => z.Klient)
                .Include(z => z.Produkt)
                .FirstOrDefaultAsync(m => m.ZaznamPojisteniID == id);
            if (zaznamPojisteni == null)
            {
                return NotFound();
            }

            return View(zaznamPojisteni);
        }

        // POST: ZaznamPojistenis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ZaznamyPojisteni == null)
            {
                return Problem("Entity set 'mvcapppojisteniverze02Context.ZaznamyPojisteni'  is null.");
            }
            var zaznamPojisteni = await _context.ZaznamyPojisteni.FindAsync(id);
            if (zaznamPojisteni != null)
            {
                _context.ZaznamyPojisteni.Remove(zaznamPojisteni);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZaznamPojisteniExists(int id)
        {
          return _context.ZaznamyPojisteni.Any(e => e.ZaznamPojisteniID == id);
        }
    }
}
