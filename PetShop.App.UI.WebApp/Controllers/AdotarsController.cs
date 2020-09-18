using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate;
using PetShop.Microservices.AdotarMicroservice.Infra.DataAccess.Contexts;

namespace PetShop.App.UI.WebApp.Controllers
{
    public class AdotarsController : Controller
    {
        private readonly AdotarContext _context;

        public AdotarsController(AdotarContext context)
        {
            _context = context;
        }

        // GET: Adotars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adocoes.ToListAsync());
        }

        // GET: Adotars/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adotar = await _context.Adocoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adotar == null)
            {
                return NotFound();
            }

            return View(adotar);
        }

        // GET: Adotars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adotars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,AnimalId,DataAdocao")] Adotar adotar)
        {
            if (ModelState.IsValid)
            {
                adotar.Id = Guid.NewGuid();
                _context.Add(adotar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adotar);
        }

        // GET: Adotars/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adotar = await _context.Adocoes.FindAsync(id);
            if (adotar == null)
            {
                return NotFound();
            }
            return View(adotar);
        }

        // POST: Adotars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ClienteId,AnimalId,DataAdocao")] Adotar adotar)
        {
            if (id != adotar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adotar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdotarExists(adotar.Id))
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
            return View(adotar);
        }

        // GET: Adotars/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adotar = await _context.Adocoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adotar == null)
            {
                return NotFound();
            }

            return View(adotar);
        }

        // POST: Adotars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var adotar = await _context.Adocoes.FindAsync(id);
            _context.Adocoes.Remove(adotar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdotarExists(Guid id)
        {
            return _context.Adocoes.Any(e => e.Id == id);
        }
    }
}
