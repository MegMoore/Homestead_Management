﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Homestead_Management.Data;
using Homestead_Management.Models.Animals;

namespace Homestead_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypesController : ControllerBase
    {
        private readonly Homestead_ManagementContext _context;

        public AnimalTypesController(Homestead_ManagementContext context)
        {
            _context = context;
        }

        // GET: api/AnimalTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalType>>> GetAnimalType()
        {
            return await _context.AnimalTypes.ToListAsync();
        }

        // GET: api/AnimalTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalType>> GetAnimalType(int id)
        {
            var animalType = await _context.AnimalTypes.FindAsync(id);

            if (animalType == null)
            {
                return NotFound();
            }

            return animalType;
        }

        // PUT: api/AnimalTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalType(int id, AnimalType animalType)
        {
            if (id != animalType.Id)
            {
                return BadRequest();
            }

            _context.Entry(animalType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalTypeExists(id))
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

        // POST: api/AnimalTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalType>> PostAnimalType(AnimalType animalType)
        {
            _context.AnimalTypes.Add(animalType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalType", new { id = animalType.Id }, animalType);
        }

        // DELETE: api/AnimalTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalType(int id)
        {
            var animalType = await _context.AnimalTypes.FindAsync(id);
            if (animalType == null)
            {
                return NotFound();
            }

            _context.AnimalTypes.Remove(animalType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalTypeExists(int id)
        {
            return _context.AnimalTypes.Any(e => e.Id == id);
        }
    }
}
