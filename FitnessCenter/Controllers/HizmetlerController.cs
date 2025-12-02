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
    public class HizmetlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HizmetlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hizmetler
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Hizmetler.Include(h => h.Antrenor).Include(h => h.SporSalonu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Hizmetler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmet = await _context.Hizmetler
                .Include(h => h.Antrenor)
                .Include(h => h.SporSalonu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hizmet == null)
            {
                return NotFound();
            }

            return View(hizmet);
        }

        // GET: Hizmetler/Create
        public IActionResult Create()
        {
            ViewData["AntrenorId"] = new SelectList(_context.Antrenorler, "Id", "AdSoyad");
            ViewData["SporSalonuId"] = new SelectList(_context.SporSalonlari, "Id", "Ad");
            return View();
        }

        // POST: Hizmetler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,SureDakika,Ucret,AntrenorId,SporSalonuId")] Hizmet hizmet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hizmet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AntrenorId"] = new SelectList(_context.Antrenorler, "Id", "AdSoyad", hizmet.AntrenorId);
            ViewData["SporSalonuId"] = new SelectList(_context.SporSalonlari, "Id", "Ad", hizmet.SporSalonuId);
            return View(hizmet);
        }

        // GET: Hizmetler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmet = await _context.Hizmetler.FindAsync(id);
            if (hizmet == null)
            {
                return NotFound();
            }
            ViewData["AntrenorId"] = new SelectList(_context.Antrenorler, "Id", "AdSoyad", hizmet.AntrenorId);
            ViewData["SporSalonuId"] = new SelectList(_context.SporSalonlari, "Id", "Ad", hizmet.SporSalonuId);
            return View(hizmet);
        }

        // POST: Hizmetler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,SureDakika,Ucret,AntrenorId,SporSalonuId")] Hizmet hizmet)
        {
            if (id != hizmet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hizmet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HizmetExists(hizmet.Id))
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
            ViewData["AntrenorId"] = new SelectList(_context.Antrenorler, "Id", "AdSoyad", hizmet.AntrenorId);
            ViewData["SporSalonuId"] = new SelectList(_context.SporSalonlari, "Id", "Ad", hizmet.SporSalonuId);
            return View(hizmet);
        }

        // GET: Hizmetler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmet = await _context.Hizmetler
                .Include(h => h.Antrenor)
                .Include(h => h.SporSalonu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hizmet == null)
            {
                return NotFound();
            }

            return View(hizmet);
        }

        // POST: Hizmetler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hizmet = await _context.Hizmetler.FindAsync(id);
            if (hizmet != null)
            {
                _context.Hizmetler.Remove(hizmet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HizmetExists(int id)
        {
            return _context.Hizmetler.Any(e => e.Id == id);
        }
    }
}
