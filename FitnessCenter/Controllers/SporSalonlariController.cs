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
    public class SporSalonlariController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SporSalonlariController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SporSalonlari
        public async Task<IActionResult> Index()
        {
            return View(await _context.SporSalonlari.ToListAsync());
        }

        // GET: SporSalonlari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sporSalonu = await _context.SporSalonlari
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sporSalonu == null)
            {
                return NotFound();
            }

            return View(sporSalonu);
        }

        // GET: SporSalonlari/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SporSalonlari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Adres,CalismaSaatleri")] SporSalonu sporSalonu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sporSalonu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sporSalonu);
        }

        // GET: SporSalonlari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sporSalonu = await _context.SporSalonlari.FindAsync(id);
            if (sporSalonu == null)
            {
                return NotFound();
            }
            return View(sporSalonu);
        }

        // POST: SporSalonlari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Adres,CalismaSaatleri")] SporSalonu sporSalonu)
        {
            if (id != sporSalonu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sporSalonu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SporSalonuExists(sporSalonu.Id))
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
            return View(sporSalonu);
        }

        // GET: SporSalonlari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sporSalonu = await _context.SporSalonlari
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sporSalonu == null)
            {
                return NotFound();
            }

            return View(sporSalonu);
        }

        // POST: SporSalonlari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sporSalonu = await _context.SporSalonlari.FindAsync(id);
            if (sporSalonu != null)
            {
                _context.SporSalonlari.Remove(sporSalonu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SporSalonuExists(int id)
        {
            return _context.SporSalonlari.Any(e => e.Id == id);
        }
    }
}
