using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcapppojisteniverze02.Data;
using mvcapppojisteniverze02.Models;
using X.PagedList;

namespace mvcapppojisteniverze02.Controllers
{
    public class ProduktsController : Controller
    {
        private readonly mvcapppojisteniverze02Context _context;

        public ProduktsController(mvcapppojisteniverze02Context context)
        {
            _context = context;
        }

        // GET: Produkts
        public async Task<IActionResult> Index(string alert, string sortOrder, string currentFilter, string searchString, int? page)
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

            var produkty = from s in _context.Produkty
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                produkty = produkty.Where(s => s.Nazev.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    produkty = produkty.OrderByDescending(s => s.Nazev);
                    break;
                default:
                    produkty = produkty.OrderBy(s => s.Nazev);
                    break;
            }

            int pageNumber = page ?? 1;
            int pageSize = 5;


            return View(await produkty.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: Produkts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produkty == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkty
                .FirstOrDefaultAsync(m => m.ProduktID == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // GET: Produkts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produkts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduktID,Nazev,Popis")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkt);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Produkts", new { alert = "nový" });
            }
            return View(produkt);
        }

        // GET: Produkts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produkty == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkty.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }
            return View(produkt);
        }

        // POST: Produkts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProduktID,Nazev,Popis")] Produkt produkt)
        {
            if (id != produkt.ProduktID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktExists(produkt.ProduktID))
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
            return View(produkt);
        }

        // GET: Produkts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produkty == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkty
                .FirstOrDefaultAsync(m => m.ProduktID == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // POST: Produkts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produkty == null)
            {
                return Problem("Entity set 'mvcapppojisteniverze02Context.Produkty'  is null.");
            }
            var produkt = await _context.Produkty.FindAsync(id);
            if (produkt != null)
            {
                _context.Produkty.Remove(produkt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Produkts", new { alert = "odstraněn" });
        }

        private bool ProduktExists(int id)
        {
          return _context.Produkty.Any(e => e.ProduktID == id);
        }
    }
}
