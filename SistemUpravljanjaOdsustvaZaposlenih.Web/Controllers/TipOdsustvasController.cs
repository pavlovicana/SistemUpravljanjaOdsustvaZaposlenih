using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemUpravljanjaOdsustvaZaposlenih.Web.Data;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Controllers
{
    public class TipOdsustvasController : Controller
    {
        private readonly ApplicationDbContext _context; //referenca ka klasi DbContext //patern Dependency Injection//zavisnost klasa

        public TipOdsustvasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipOdsustvas //fetch the data from the database - representation of table in database
        public async Task<IActionResult> Index()
        {
            //var data = SELECT * FROM TipOsustva
            var data = await _context.TipOdsustva.ToListAsync();
            return View(data);
        }

        // GET: TipOdsustvas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Select * from TipOdsustva WHERE Id = @id
            var tipOdsustva = await _context.TipOdsustva
                .FirstOrDefaultAsync(m => m.Id == id); //lambda expression
            if (tipOdsustva == null)
            {
                return NotFound(); //404 Error if id is not found
            }

            return View(tipOdsustva);
        }

        // GET: TipOdsustvas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipOdsustvas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,BrojDana")] TipOdsustva tipOdsustva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipOdsustva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipOdsustva);
        }

        // GET: TipOdsustvas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipOdsustva = await _context.TipOdsustva.FindAsync(id);
            if (tipOdsustva == null)
            {
                return NotFound();
            }
            return View(tipOdsustva);
        }

        // POST: TipOdsustvas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,BrojDana")] TipOdsustva tipOdsustva)
        {
            if (id != tipOdsustva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipOdsustva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipOdsustvaExists(tipOdsustva.Id))
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
            return View(tipOdsustva);
        }

        // GET: TipOdsustvas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipOdsustva = await _context.TipOdsustva
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipOdsustva == null)
            {
                return NotFound();
            }

            return View(tipOdsustva);
        }

        // POST: TipOdsustvas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipOdsustva = await _context.TipOdsustva.FindAsync(id);
            if (tipOdsustva != null)
            {
                _context.TipOdsustva.Remove(tipOdsustva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipOdsustvaExists(int id)
        {
            return _context.TipOdsustva.Any(e => e.Id == id);
        }
    }
}
