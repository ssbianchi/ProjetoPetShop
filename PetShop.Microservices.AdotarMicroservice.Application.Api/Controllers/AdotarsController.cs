using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate;
using PetShop.Microservices.AdotarMicroservice.Infra.DataAccess.Contexts;

namespace PetShop.Microservices.AdotarMicroservice.Application.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AdotarsController : ControllerBase
    {
        private readonly AdotarContext _context;
        private readonly IApiApplicationService apiApplicationService;

        public AdotarsController(AdotarContext context, IApiApplicationService apiApplicationService)
        {
            _context = context;
            this.apiApplicationService = apiApplicationService;
        }


        // GET: api/Adotars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adotar>>> GetAdocoes()
        {
            return await _context.Adocoes.ToListAsync();
        }

        // GET: api/Adotars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adotar>> GetAdotar(Guid id)
        {
            var adotar = await _context.Adocoes.FindAsync(id);

            if (adotar == null)
            {
                return NotFound();
            }

            return adotar;
        }

        // PUT: api/Adotars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdotar(Guid id, Adotar adotar)
        {
            if (id != adotar.Id)
            {
                return BadRequest();
            }

            _context.Entry(adotar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdotarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Adotars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Adotar>> PostAdotar(Adotar adotar)
        {
            //Utilizado antes de criar o CQRS
            //adotar.Id = Guid.NewGuid();
            //_context.Adocoes.Add(adotar);
            //await _context.SaveChangesAsync();

            await apiApplicationService.CreateAdotarAsync(adotar.ClienteId, adotar.AnimalId, adotar.DataAdocao);

            return CreatedAtAction("GetAdotar", new { id = adotar.Id }, adotar);
        }

        // DELETE: api/Adotars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Adotar>> DeleteAdotar(Guid id)
        {
            var adotar = await _context.Adocoes.FindAsync(id);
            if (adotar == null)
            {
                return NotFound();
            }

            _context.Adocoes.Remove(adotar);
            await _context.SaveChangesAsync();

            return adotar;
        }

        private bool AdotarExists(Guid id)
        {
            return _context.Adocoes.Any(e => e.Id == id);
        }
    }
}
