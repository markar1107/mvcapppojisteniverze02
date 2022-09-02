using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcapppojisteniverze02.Data;
using mvcapppojisteniverze02.Models;
using X.PagedList;

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
        public async Task<IActionResult> Index(string alert, string sortOrder, string currentFilter,string searchString, int? page)
        {
            ViewBag.alert = alert;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CurrentSort = sortOrder;
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var klienti = from s in _context.Klienti
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                klienti = klienti.Where(s => s.Prijmeni.Contains(searchString) || s.Jmeno.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    klienti = klienti.OrderByDescending(s => s.Prijmeni);
                    break;
                default:
                    klienti = klienti.OrderBy(s => s.Prijmeni);
                    break;
            }

            int pageNumber = page ?? 1;
            int pageSize = 5;


            return klienti != null ?
                          View(await klienti.ToPagedListAsync(pageNumber, pageSize)) :
                          Problem("Entity set 'mvcapppojisteniverze02Context.Klient'  is null.");
        }

        // GET: Klients/Details/5
        public async Task<IActionResult> Details(string sortOrder, int? id)
        {

            if (id == null || _context.Klienti == null)
            {
                return NotFound();
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CurrentSort = sortOrder;


           

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
                return RedirectToAction("Index", "Klients", new { alert = "nový" });
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
            return RedirectToAction("Index", "Klients", new { alert = "odstraněn" });
            //return RedirectToAction(nameof(Index));
        }

        private bool KlientExists(int id)
        {
            return (_context.Klienti?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
