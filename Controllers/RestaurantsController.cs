﻿using System;
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
    public class RestaurantsController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;   
        public RestaurantsController(UserDbContext context ,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        /*        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
                {
                  if (_context.Restaurants == null)
                  {
                      return NotFound();
                  }
                    return await _context.Restaurants.ToListAsync();
                }
        */
        public ActionResult<List<Restaurant>> GetRestaurants()
        {
            return Ok(_context.Restaurants.Select(rst => _mapper.Map<RestaurantDto>(rst)));
        }


        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
          if (_context.Restaurants == null)
          {
              return NotFound();
          }
            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RestaurantDto>(restaurant));
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
             
        {
            if (id != restaurant.RestaurantId)
            {
                return BadRequest();
            }

            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
          if (_context.Restaurants == null)
          {
              return Problem("Entity set 'UserDbContext.Restaurants'  is null.");
          }
            _context.Restaurants.Add(restaurant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RestaurantExists(restaurant.RestaurantId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRestaurant", new { id = restaurant.RestaurantId }, restaurant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            if (_context.Restaurants == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

            return Ok("Restaurant Entry Deleted:"+_mapper.Map<RestaurantDto>(restaurant));
        }

        private bool RestaurantExists(int id)
        {
            return (_context.Restaurants?.Any(e => e.RestaurantId == id)).GetValueOrDefault();
        }
    }
}
