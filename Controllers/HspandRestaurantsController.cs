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
    public class HspandRestaurantsController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;
        public HspandRestaurantsController(UserDbContext context,IMapper  mapper)

        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/HspandRestaurants
        /*      [HttpGet]
              public async Task<ActionResult<IEnumerable<HspandRestaurant>>> GetHspandRestaurants()
              {
                if (_context.HspandRestaurants == null)
                {
                    return NotFound();
                }
                  return await _context.HspandRestaurants.ToListAsync();
              }*/

        [HttpGet]
        public ActionResult<List<HspandRestaurant>> GetHspandRestaurants()
        {
            return Ok(_context.HspandRestaurants.Select(rst => _mapper.Map<HspandRestaurantDto>(rst)));
        }
        // GET: api/HspandRestaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HspandRestaurant>> GetHspandRestaurant(int id)
        {
            if (_context.HspandRestaurants == null)
            {
                return NotFound();
            }
            var hspandRestaurant = await _context.HspandRestaurants.FindAsync(id);

            if (hspandRestaurant == null)
            {
                return NotFound();
            }

         return   Ok(_mapper.Map<HspandRestaurantDto>(hspandRestaurant));
        }

        // PUT: api/HspandRestaurants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHspandRestaurant(int id, HspandRestaurant hspandRestaurant)
        {
            if (id != hspandRestaurant.Id)
            {
                return BadRequest();
            }

            _context.Entry(hspandRestaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HspandRestaurantExists(id))
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

        // POST: api/HspandRestaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HspandRestaurant>> PostHspandRestaurant(HspandRestaurant hspandRestaurant)
        {
          if (_context.HspandRestaurants == null)
          {
              return Problem("Entity set 'UserDbContext.HspandRestaurants'  is null.");
          }
            _context.HspandRestaurants.Add(hspandRestaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHspandRestaurant", new { id = hspandRestaurant.Id }, hspandRestaurant);
        }

        // DELETE: api/HspandRestaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHspandRestaurant(int id)
        {
            if (_context.HspandRestaurants == null)
            {
                return NotFound();
            }
            var hspandRestaurant = await _context.HspandRestaurants.FindAsync(id);
            if (hspandRestaurant == null)
            {
                return NotFound();
            }

            _context.HspandRestaurants.Remove(hspandRestaurant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HspandRestaurantExists(int id)
        {
            return (_context.HspandRestaurants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
