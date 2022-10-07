using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependanciesController : ControllerBase
    {
        private readonly custmanagementContext _context;

        public DependanciesController(custmanagementContext context)
        {
            _context = context;
        }

        // GET: api/Dependancies
        [HttpGet]
        public IEnumerable<Dependancy> GetDependancy()
        {
            return _context.Dependancy;
        }

        // GET: api/Dependancies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDependancy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dependancy = await _context.Dependancy.FindAsync(id);

            if (dependancy == null)
            {
                return NotFound();
            }

            return Ok(dependancy);
        }

        [HttpGet("dependent/{id}")]
        public async Task<IActionResult> GetDependancyByCustid([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dependancy = await _context.Dependancy.Where(x => x.Custid == id).ToListAsync();

            if (dependancy == null)
            {
                return NotFound();
            }

            return Ok(dependancy);
        }

        // PUT: api/Dependancies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDependancy([FromRoute] int id, [FromBody] Dependancy dependancy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dependancy.Deptid)
            {
                return BadRequest();
            }

            _context.Entry(dependancy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DependancyExists(id))
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

        // POST: api/Dependancies
        [HttpPost]
        public async Task<IActionResult> PostDependancy([FromBody] Dependancy dependancy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dependancy.Add(dependancy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDependancy", new { id = dependancy.Deptid }, dependancy);
        }

        // DELETE: api/Dependancies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDependancy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dependancy = await _context.Dependancy.FindAsync(id);
            if (dependancy == null)
            {
                return NotFound();
            }

            _context.Dependancy.Remove(dependancy);
            await _context.SaveChangesAsync();

            return Ok(dependancy);
        }

        private bool DependancyExists(int id)
        {
            return _context.Dependancy.Any(e => e.Deptid == id);
        }
    }
}