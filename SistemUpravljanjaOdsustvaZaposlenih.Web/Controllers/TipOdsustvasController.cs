using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemUpravljanjaOdsustvaZaposlenih.Web.Data;
using SistemUpravljanjaOdsustvaZaposlenih.Web.Models.TipOdsustva;
using SistemUpravljanjaOdsustvaZaposlenih.Web.Services;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Controllers
{
    public class TipOdsustvasController(ISistemOdsustvaServisi _sistemOdsustvaServisi) : Controller
    {
        
        private const string NameExistsValidationMessage= "Ovo ime vec postoji u bazi.";



        // GET: TipOdsustvas //fetch the data from the database - representation of table in database
        public async Task<IActionResult> Index()
        {
            var viewData = await _sistemOdsustvaServisi.IspisiSveAsync();       
            return View(viewData);
           
        }

        // GET: TipOdsustvas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Select * from TipOdsustva WHERE Id = @id
            var tipOdsustva = await _sistemOdsustvaServisi.IspisiAsync<TipOdsustvaReadOnlyVM>(id.Value);

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
        //Overposting is enableing someone to add data from the browser when inspect element..
        //Overposting is letting to much data to come in.
        //because of that TipOdsustvaCreateVM nema Id properti.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipOdsustvaCreateVM tipOdsustvaCreateVM)
        {
            //Adding custom validation and model state
            if (await _sistemOdsustvaServisi.ProveriDaLiTipOdsustvaPostoji(tipOdsustvaCreateVM.Ime))
            {
                ModelState.AddModelError(nameof(tipOdsustvaCreateVM.Ime), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                _sistemOdsustvaServisi.Create(tipOdsustvaCreateVM);
                return RedirectToAction(nameof(Index));
            }
            return View(tipOdsustvaCreateVM);
        }

        // GET: TipOdsustvas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipOdsustva = await _sistemOdsustvaServisi.IspisiAsync<TipOdsustvaEditVM>(id.Value);

            if (tipOdsustva == null)
            {
                return NotFound(); //404 Error if id is not found
            }

            return View(tipOdsustva);

        }

        // POST: TipOdsustvas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TipOdsustvaEditVM tipOdsustvaEditVM)
        {
            if (id != tipOdsustvaEditVM.Id)
            {
                return NotFound();
            }

            if (await _sistemOdsustvaServisi.ProveriDaLiTipOdsustvaPostojiEdit(tipOdsustvaEditVM))
            {
                ModelState.AddModelError(nameof(tipOdsustvaEditVM.Ime), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _sistemOdsustvaServisi.Edit(tipOdsustvaEditVM);   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_sistemOdsustvaServisi.TipOdsustvaExists(tipOdsustvaEditVM.Id))
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
            return View(tipOdsustvaEditVM);
        }   

        // GET: TipOdsustvas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipOdsustva = await _sistemOdsustvaServisi.IspisiAsync<TipOdsustvaReadOnlyVM>(id.Value);

            if (tipOdsustva == null)
            {
                return NotFound(); //404 Error if id is not found
            }
            return View(tipOdsustva);

        }

        // POST: TipOdsustvas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sistemOdsustvaServisi.Obrisi(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
