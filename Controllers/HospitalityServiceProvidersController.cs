using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCA2.Repository;
using WebApiCA2.Repository.Models;

namespace WebApiCA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalityServiceProvidersController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;
        public HospitalityServiceProvidersController(UserDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/HospitalityServiceProviders
  /*      [HttpGet]*/
        /*      public async Task<ActionResult<IEnumerable<HospitalityServiceProvider>>> GetHospitalityServiceProviders()
              {
                if (_context.HospitalityServiceProviders == null)
                {
                    return NotFound();
                }
                  return await _context.HospitalityServiceProviders.ToListAsync();
              }*/
        [HttpGet]

        public ActionResult<List<HospitalityServiceProvider>> GetUser()
        {

            //using mapper to return a DTO 
            return  Ok(_context.HospitalityServiceProviders.Select(user => _mapper.Map<HospitalityServiceProviderDto>(user)));
        }

        // GET: api/HospitalityServiceProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalityServiceProvider>> GetHospitalityServiceProvider(int id)
        {
          if (_context.HospitalityServiceProviders == null)
          {
              return NotFound();
          }
            var hospitalityServiceProvider = await _context.HospitalityServiceProviders.FindAsync(id);

            if (hospitalityServiceProvider == null)
            {
                return NotFound();
            }
            //here returning DTO OF Entity

            return Ok(_mapper.Map<HospitalityServiceProviderDto>(hospitalityServiceProvider));
        }

        // PUT: api/HospitalityServiceProviders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalityServiceProvider(int id, HospitalityServiceProvider hospitalityServiceProvider)
        {
            if (id != hospitalityServiceProvider.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospitalityServiceProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalityServiceProviderExists(id))
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

        // POST: api/HospitalityServiceProviders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HospitalityServiceProvider>> PostHospitalityServiceProvider(HospitalityServiceProvider hospitalityServiceProvider)
        {
          if (_context.HospitalityServiceProviders == null)
          {
              return Problem("Entity set 'UserDbContext.HospitalityServiceProviders'  is null.");
          }
            _context.HospitalityServiceProviders.Add(hospitalityServiceProvider);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HospitalityServiceProviderExists(hospitalityServiceProvider.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHospitalityServiceProvider", new { id = hospitalityServiceProvider.Id }, hospitalityServiceProvider);
        }

        // DELETE: api/HospitalityServiceProviders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospitalityServiceProvider(int id)
        {
            if (_context.HospitalityServiceProviders == null)
            {
                return NotFound();
            }
            var hospitalityServiceProvider = await _context.HospitalityServiceProviders.FindAsync(id);
            if (hospitalityServiceProvider == null)
            {
                return NotFound();
            }

            _context.HospitalityServiceProviders.Remove(hospitalityServiceProvider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospitalityServiceProviderExists(int id)
        {
            return (_context.HospitalityServiceProviders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
