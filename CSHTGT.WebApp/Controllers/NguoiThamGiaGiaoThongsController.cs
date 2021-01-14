using System;
using CSHTGT.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSHTGT.Data.Context;
using CSHTGT.Data.Models;
using Newtonsoft.Json;

namespace CSHTGT.WebApp.Controllers
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
            return View(await _context.NguoiThamGiaGiaoThongs.ToListAsync());
        }
        //public async Task<IActionResult> IndexSearch(string cmnd)
        //{
        //    var temp = await _context.NguoiThamGiaGiaoThongs.Where(x => x.CMND == cmnd).ToListAsync();
        //    return View("Index",temp);
        //}
        public async Task<IActionResult> IndexSearch([Bind("CMND")] string id)
        {
            if (Int32.TryParse(id, out int output))
            {
                var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs.Where(x => x.CMND == id).ToListAsync();
                if (nguoiThamGiaGiaoThong == null)
                {
                    return NotFound();
                }
                return View("Index", nguoiThamGiaGiaoThong);
            }
            else
            {
                var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs.Where(x => x.HoTen == id).ToListAsync();
                if (nguoiThamGiaGiaoThong == null)
                {
                    return NotFound();
                }
                return View("Index", nguoiThamGiaGiaoThong);
            }            
        }
        
        // GET: NguoiThamGiaGiaoThongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiThamGiaGiaoThong = await _context.NguoiThamGiaGiaoThongs
                .Include(n => n.PhuongTiens)
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
            return View();
        }

        // POST: NguoiThamGiaGiaoThongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HoTen,DiaChi,CMND,Email,NgaySinh,QueQuan,SDT,PassWord,UserName")] NguoiThamGiaGiaoThong nguoiThamGiaGiaoThong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiThamGiaGiaoThong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(nguoiThamGiaGiaoThong);
        }

        // POST: NguoiThamGiaGiaoThongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HoTen,DiaChi,CMND,Email,NgaySinh,QueQuan,SDT,PassWord,UserName")] NguoiThamGiaGiaoThong nguoiThamGiaGiaoThong)
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
