using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSHTGT.Data.Context;
using CSHTGT.Data.Models;

namespace CSHTGT.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiThamGiaGiaoThongsController : ControllerBase
    {
        private readonly CSHTGTDbContext _context;

        public NguoiThamGiaGiaoThongsController(CSHTGTDbContext context)
        {
            _context = context;
        }

        // GET: api/NguoiThamGiaGiaoThongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiThamGiaGiaoThong>>> GetNguoiThamGiaGiaoThongs()
        {
            return await _context.NguoiThamGiaGiaoThongs.ToListAsync();
        }
        // GET: api/NguoiThamGiaGiaoThongs/find/id
        [HttpGet("find/{id}")]
        public async Task<ActionResult<IEnumerable<NguoiThamGiaGiaoThong>>> GetNguoiThamGiaGiaoThongbyCMNDHoten(string id)
        {
            if (Int32.TryParse(id, out int output))
            {
                var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs.Where(x => x.CMND == id).ToListAsync();
                if (nguoiThamGiaGiaoThong == null)
                {
                    return NotFound();
                }
                return nguoiThamGiaGiaoThong;
            }
            else
            {
                var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs.Where(x => x.HoTen == id).ToListAsync();
                if (nguoiThamGiaGiaoThong == null)
                {
                    return NotFound();
                }
                return nguoiThamGiaGiaoThong;
            }
        }
        // GET: api/NguoiThamGiaGiaoThongs/id
        [HttpGet("{id}")]
        public async Task<ActionResult<NguoiThamGiaGiaoThong>> GetNguoiThamGiaGiaoThong(int id)
        {
            var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs.FindAsync(id);

            if (nguoiThamGiaGiaoThong == null)
            {
                return NotFound();
            }

            return nguoiThamGiaGiaoThong;
        }

        // PUT: api/NguoiThamGiaGiaoThongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoiThamGiaGiaoThong(int id, NguoiThamGiaGiaoThong nguoiThamGiaGiaoThong)
        {
            if (id != nguoiThamGiaGiaoThong.ID)
            {
                return BadRequest();
            }

            _context.Entry(nguoiThamGiaGiaoThong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiThamGiaGiaoThongExists(id))
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

        // POST: api/NguoiThamGiaGiaoThongs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NguoiThamGiaGiaoThong>> PostNguoiThamGiaGiaoThong(NguoiThamGiaGiaoThong nguoiThamGiaGiaoThong)
        {
            _context.NguoiThamGiaGiaoThongs.Add(nguoiThamGiaGiaoThong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNguoiThamGiaGiaoThong", new { id = nguoiThamGiaGiaoThong.ID }, nguoiThamGiaGiaoThong);
        }

        // DELETE: api/NguoiThamGiaGiaoThongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NguoiThamGiaGiaoThong>> DeleteNguoiThamGiaGiaoThong(int id)
        {
            var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs.FindAsync(id);
            if (nguoiThamGiaGiaoThong == null)
            {
                return NotFound();
            }

            _context.NguoiThamGiaGiaoThongs.Remove(nguoiThamGiaGiaoThong);
            await _context.SaveChangesAsync();

            return nguoiThamGiaGiaoThong;
        }

        private bool NguoiThamGiaGiaoThongExists(int id)
        {
            return _context.NguoiThamGiaGiaoThongs.Any(e => e.ID == id);
        }
    }
}
