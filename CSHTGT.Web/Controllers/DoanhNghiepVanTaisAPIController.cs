using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSHTGT.Data.Context;
using CSHTGT.Data.Models;

namespace CSHTGT.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoanhNghiepVanTaisAPIController : ControllerBase
    {
        private readonly CSHTGTDbContext _context;

        public DoanhNghiepVanTaisAPIController(CSHTGTDbContext context)
        {
            _context = context;
        }

        // GET: api/DoanhNghiepVanTais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoanhNghiepVanTai>>> GetDoanhNghiepVanTais()
        {
            return await _context.DoanhNghiepVanTais.ToListAsync();
        }

        // GET: api/DoanhNghiepVanTais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoanhNghiepVanTai>> GetDoanhNghiepVanTai(int id)
        {
            var doanhNghiepVanTai = await _context.DoanhNghiepVanTais.FindAsync(id);

            if (doanhNghiepVanTai == null)
            {
                return NotFound();
            }

            return doanhNghiepVanTai;
        }

        // PUT: api/DoanhNghiepVanTais/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoanhNghiepVanTai(int id, DoanhNghiepVanTai doanhNghiepVanTai)
        {
            if (id != doanhNghiepVanTai.ID)
            {
                return BadRequest();
            }

            _context.Entry(doanhNghiepVanTai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoanhNghiepVanTaiExists(id))
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

        // POST: api/DoanhNghiepVanTais
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DoanhNghiepVanTai>> PostDoanhNghiepVanTai(DoanhNghiepVanTai doanhNghiepVanTai)
        {
            _context.DoanhNghiepVanTais.Add(doanhNghiepVanTai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoanhNghiepVanTai", new { id = doanhNghiepVanTai.ID }, doanhNghiepVanTai);
        }

        // DELETE: api/DoanhNghiepVanTais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DoanhNghiepVanTai>> DeleteDoanhNghiepVanTai(int id)
        {
            var doanhNghiepVanTai = await _context.DoanhNghiepVanTais.FindAsync(id);
            if (doanhNghiepVanTai == null)
            {
                return NotFound();
            }

            _context.DoanhNghiepVanTais.Remove(doanhNghiepVanTai);
            await _context.SaveChangesAsync();

            return doanhNghiepVanTai;
        }

        private bool DoanhNghiepVanTaiExists(int id)
        {
            return _context.DoanhNghiepVanTais.Any(e => e.ID == id);
        }
    }
}
