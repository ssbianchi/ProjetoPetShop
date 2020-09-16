using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetShop.App.Application;
using PetShop.Microservices.AnimalMicroservice.Domain.AggregatesModel.AnimalAggregate;
using PetShop.Microservices.AnimalMicroservice.Infra.DataAccess.Contexts;

namespace PetShop.App.UI.WebApp.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly IAppService appService;
        private readonly AnimalContext _context;
        
        public AnimalsController(IAppService appService, AnimalContext context)
        {
            _context = context;
            this.appService = appService;
        }

        // GET: All Animals
        public async Task<IActionResult> Index()
        {
            //var animals = await _context.Animals.ToListAsync();
            //return View(animals);

            var token = HttpContext.Session.GetString("Token"); 
            var animals = await appService.GetAllAnimalsAsync(token);
            return View(animals);

            //var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Authorize", "bearer aki");
            ////PetShopWpf_ClientId
            //var result = await httpClient.GetAsync("https://petshop-animalmicroservice-api-sergio.azurewebsites.net/api/animals");

            //if (!result.IsSuccessStatusCode)
            //    return BadRequest();

            //var serializedAnimals = await result.Content.ReadAsStringAsync();

            //var animalsViewModel = JsonConvert.DeserializeObject<IEnumerable<PetShop.App.UI.WebApp.Models.AnimalViewModel>>(serializedAnimals);

            ////return View(await _context.Animals.ToListAsync());
            //return View(animalsViewModel);
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,Nome,Raca,DataNascimento,Peso")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                animal.Id = Guid.NewGuid();
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ClienteId,Nome,Raca,DataNascimento,Peso")] Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
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
            return View(animal);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var animal = await _context.Animals.FindAsync(id);
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(Guid id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }
    }
}
