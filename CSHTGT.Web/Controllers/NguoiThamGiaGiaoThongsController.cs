using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSHTGT.Data.Context;
using CSHTGT.Data.Models;

namespace CSHTGT.Web.Controllers
{
    public class NguoiThamGiaGiaoThongsController : Controller
    {
        private readonly CSHTGTDbContext _context;

        public NguoiThamGiaGiaoThongsController(CSHTGTDbContext context)
        {
            _context = context;
        }

        // GET: NguoiThamGiaGiaoThongs
        public async Task<IActionResult> Index()
        {
            var cSHTGTDbContext = _context.NguoiThamGiaGiaoThongs.Include(n => n.DoanhNghiepVanTai);
            return View(await cSHTGTDbContext.ToListAsync());
        }

        // GET: NguoiThamGiaGiaoThongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs
                .Include(n => n.DoanhNghiepVanTai)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nguoiThamGiaGiaoThong == null)
            {
                return NotFound();
            }

            return View(nguoiThamGiaGiaoThong);
        }

        // GET: NguoiThamGiaGiaoThongs/Create
        public IActionResult Create()
        {
            ViewData["MaDoanhNghiepVanTai"] = new SelectList(_context.DoanhNghiepVanTais, "ID", "ID");
            return View();
        }

        // POST: NguoiThamGiaGiaoThongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaDoanhNghiepVanTai,HoTen,DiaChi,CMND,Email,NgaySinh,QueQuan,SDT,PassWord,UserName")] NguoiThamGiaGiaoThong nguoiThamGiaGiaoThong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiThamGiaGiaoThong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDoanhNghiepVanTai"] = new SelectList(_context.DoanhNghiepVanTais, "ID", "ID", nguoiThamGiaGiaoThong.MaDoanhNghiepVanTai);
            return View(nguoiThamGiaGiaoThong);
        }

        // GET: NguoiThamGiaGiaoThongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs.FindAsync(id);
            if (nguoiThamGiaGiaoThong == null)
            {
                return NotFound();
            }
            ViewData["MaDoanhNghiepVanTai"] = new SelectList(_context.DoanhNghiepVanTais, "ID", "ID", nguoiThamGiaGiaoThong.MaDoanhNghiepVanTai);
            return View(nguoiThamGiaGiaoThong);
        }

        // POST: NguoiThamGiaGiaoThongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaDoanhNghiepVanTai,HoTen,DiaChi,CMND,Email,NgaySinh,QueQuan,SDT,PassWord,UserName")] NguoiThamGiaGiaoThong nguoiThamGiaGiaoThong)
        {
            if (id != nguoiThamGiaGiaoThong.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiThamGiaGiaoThong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiThamGiaGiaoThongExists(nguoiThamGiaGiaoThong.ID))
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
            ViewData["MaDoanhNghiepVanTai"] = new SelectList(_context.DoanhNghiepVanTais, "ID", "ID", nguoiThamGiaGiaoThong.MaDoanhNghiepVanTai);
            return View(nguoiThamGiaGiaoThong);
        }

        // GET: NguoiThamGiaGiaoThongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs
                .Include(n => n.DoanhNghiepVanTai)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nguoiThamGiaGiaoThong == null)
            {
                return NotFound();
            }

            return View(nguoiThamGiaGiaoThong);
        }

        // POST: NguoiThamGiaGiaoThongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs.FindAsync(id);
            _context.NguoiThamGiaGiaoThongs.Remove(nguoiThamGiaGiaoThong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiThamGiaGiaoThongExists(int id)
        {
            return _context.NguoiThamGiaGiaoThongs.Any(e => e.ID == id);
        }
    }
}
