using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessCenter.Data;
using FitnessCenter.Models;

namespace FitnessCenter.Controllers
{
    public class AntrenorlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AntrenorlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Antrenorler
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Antrenorler.Include(a => a.SporSalonu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Antrenorler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenor = await _context.Antrenorler
                .Include(a => a.SporSalonu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (antrenor == null)
            {
                return NotFound();
            }

            return View(antrenor);
        }

        // GET: Antrenorler/Create
        public IActionResult Create()
        {
            ViewData["SporSalonuId"] = new SelectList(_context.SporSalonlari, "Id", "Ad");
            return View();
        }

        // POST: Antrenorler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdSoyad,Uzmanlik,DeneyimYili,SporSalonuId")] Antrenor antrenor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antrenor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SporSalonuId"] = new SelectList(_context.SporSalonlari, "Id", "Ad", antrenor.SporSalonuId);
            return View(antrenor);
        }

        // GET: Antrenorler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenor = await _context.Antrenorler.FindAsync(id);
            if (antrenor == null)
            {
                return NotFound();
            }
            ViewData["SporSalonuId"] = new SelectList(_context.SporSalonlari, "Id", "Ad", antrenor.SporSalonuId);
            return View(antrenor);
        }

        // POST: Antrenorler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,Uzmanlik,DeneyimYili,SporSalonuId")] Antrenor antrenor)
        {
            if (id != antrenor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antrenor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntrenorExists(antrenor.Id))
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
            ViewData["SporSalonuId"] = new SelectList(_context.SporSalonlari, "Id", "Ad", antrenor.SporSalonuId);
            return View(antrenor);
        }

        // GET: Antrenorler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenor = await _context.Antrenorler
                .Include(a => a.SporSalonu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (antrenor == null)
            {
                return NotFound();
            }

            return View(antrenor);
        }

        // POST: Antrenorler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antrenor = await _context.Antrenorler.FindAsync(id);
            if (antrenor != null)
            {
                _context.Antrenorler.Remove(antrenor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntrenorExists(int id)
        {
            return _context.Antrenorler.Any(e => e.Id == id);
        }
    }
}
