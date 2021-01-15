using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSHTGT.Data.Context;
using CSHTGT.Data.Models;

namespace CSHTGT.WebApp.Controllers
{
    public class BienBanViPhamsController : Controller
    {
        private readonly CSHTGTDbContext _context;

        public BienBanViPhamsController(CSHTGTDbContext context)
        {
            _context = context;
        }

        public ActionResult ThongKeTheoLoi()
        {
            //var bienbanbyloi = _context.BienBanViPhams
            //    .GroupBy(row => row.LoiViPham)
            //    .Select(group => new { name = group.Key, count = group.Count() });
            //ViewBag.bienbanbyloi = bienbanbyloi.ToList();
            //return View();
            return View("ThongKeTheoLoi");
        }

        public IActionResult DataThongKeTheoLoi()
        {
            var result = _context.BienBanViPhams
                .GroupBy(row => row.LoiViPham)
                .Select(group => new { name = group.Key, count = group.Count() })
                .OrderByDescending(o => o.count).ToList();

            var labels = result.Select(row => row.name).ToArray();
            var values = result.Select(row => row.count).ToArray();
            var max = values[0];
            List<object> list1 = new List<object>();
            list1.Add(labels);
            list1.Add(values);
            list1.Add(max);

            return Json(list1);
        }



        // GET: BienBanViPhams
        public async Task<IActionResult> Index()
        {
            var cSHTGTDbContext = _context.BienBanViPhams.Include(b => b.CanBo).Include(b => b.HinhThucXuPhat).Include(b => b.NguoiThamGiaGiaoThong);
            return View(await cSHTGTDbContext.ToListAsync());
        }

        // GET: BienBanViPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienBanViPham = await _context.BienBanViPhams
                .Include(b => b.CanBo)
                .Include(b => b.HinhThucXuPhat)
                .Include(b => b.NguoiThamGiaGiaoThong)
                .FirstOrDefaultAsync(m => m.MaBienBan == id);
            if (bienBanViPham == null)
            {
                return NotFound();
            }

            return View(bienBanViPham);
        }

        // GET: BienBanViPhams/Create
        public IActionResult Create()
        {
            ViewData["MaCanBo"] = new SelectList(_context.CanBos, "IDCanBo", "IDCanBo");
            ViewData["MaHinhThucXuPhat"] = new SelectList(_context.HinhThucXuPhats, "MaHinhThuc", "MaHinhThuc");
            ViewData["MaNgTGGiaoThong"] = new SelectList(_context.NguoiThamGiaGiaoThongs, "ID", "ID");
            return View();
        }

        // POST: BienBanViPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaBienBan,MaNgTGGiaoThong,MaHinhThucXuPhat,MaCanBo,NgayViPham,NgayLap,HanNopPhat,LoiViPham,SoQuyetDinh,SoTienPhat,TinhTrangNopPhat")] BienBanViPham bienBanViPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bienBanViPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCanBo"] = new SelectList(_context.CanBos, "IDCanBo", "IDCanBo", bienBanViPham.MaCanBo);
            ViewData["MaHinhThucXuPhat"] = new SelectList(_context.HinhThucXuPhats, "MaHinhThuc", "MaHinhThuc", bienBanViPham.MaHinhThucXuPhat);
            ViewData["MaNgTGGiaoThong"] = new SelectList(_context.NguoiThamGiaGiaoThongs, "ID", "ID", bienBanViPham.MaNgTGGiaoThong);
            return View(bienBanViPham);
        }

        // GET: BienBanViPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienBanViPham = await _context.BienBanViPhams.FindAsync(id);
            if (bienBanViPham == null)
            {
                return NotFound();
            }
            ViewData["MaCanBo"] = new SelectList(_context.CanBos, "IDCanBo", "IDCanBo", bienBanViPham.MaCanBo);
            ViewData["MaHinhThucXuPhat"] = new SelectList(_context.HinhThucXuPhats, "MaHinhThuc", "MaHinhThuc", bienBanViPham.MaHinhThucXuPhat);
            ViewData["MaNgTGGiaoThong"] = new SelectList(_context.NguoiThamGiaGiaoThongs, "ID", "ID", bienBanViPham.MaNgTGGiaoThong);
            return View(bienBanViPham);
        }

        // POST: BienBanViPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaBienBan,MaNgTGGiaoThong,MaHinhThucXuPhat,MaCanBo,NgayViPham,NgayLap,HanNopPhat,LoiViPham,SoQuyetDinh,SoTienPhat,TinhTrangNopPhat")] BienBanViPham bienBanViPham)
        {
            if (id != bienBanViPham.MaBienBan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bienBanViPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BienBanViPhamExists(bienBanViPham.MaBienBan))
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
            ViewData["MaCanBo"] = new SelectList(_context.CanBos, "IDCanBo", "IDCanBo", bienBanViPham.MaCanBo);
            ViewData["MaHinhThucXuPhat"] = new SelectList(_context.HinhThucXuPhats, "MaHinhThuc", "MaHinhThuc", bienBanViPham.MaHinhThucXuPhat);
            ViewData["MaNgTGGiaoThong"] = new SelectList(_context.NguoiThamGiaGiaoThongs, "ID", "ID", bienBanViPham.MaNgTGGiaoThong);
            return View(bienBanViPham);
        }

        // GET: BienBanViPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienBanViPham = await _context.BienBanViPhams
                .Include(b => b.CanBo)
                .Include(b => b.HinhThucXuPhat)
                .Include(b => b.NguoiThamGiaGiaoThong)
                .FirstOrDefaultAsync(m => m.MaBienBan == id);
            if (bienBanViPham == null)
            {
                return NotFound();
            }

            return View(bienBanViPham);
        }

        // POST: BienBanViPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bienBanViPham = await _context.BienBanViPhams.FindAsync(id);
            _context.BienBanViPhams.Remove(bienBanViPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BienBanViPhamExists(int id)
        {
            return _context.BienBanViPhams.Any(e => e.MaBienBan == id);
        }
    }
}
