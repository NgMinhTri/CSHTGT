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
    public class DoanhNghiepVanTaisController : Controller
    {
        private readonly CSHTGTDbContext _context;

        public DoanhNghiepVanTaisController(CSHTGTDbContext context)
        {
            _context = context;
        }

        // GET: DoanhNghiepVanTais
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoanhNghiepVanTais.ToListAsync());
        }

        // GET: DoanhNghiepVanTais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doanhNghiepVanTai = await _context.DoanhNghiepVanTais
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doanhNghiepVanTai == null)
            {
                return NotFound();
            }

            return View(doanhNghiepVanTai);
        }

        // GET: DoanhNghiepVanTais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoanhNghiepVanTais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenDN,DiaChi,TinhTrang")] DoanhNghiepVanTai doanhNghiepVanTai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doanhNghiepVanTai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doanhNghiepVanTai);
        }

        // GET: DoanhNghiepVanTais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doanhNghiepVanTai = await _context.DoanhNghiepVanTais.FindAsync(id);
            if (doanhNghiepVanTai == null)
            {
                return NotFound();
            }
            return View(doanhNghiepVanTai);
        }

        // POST: DoanhNghiepVanTais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenDN,DiaChi,TinhTrang")] DoanhNghiepVanTai doanhNghiepVanTai)
        {
            if (id != doanhNghiepVanTai.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doanhNghiepVanTai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoanhNghiepVanTaiExists(doanhNghiepVanTai.ID))
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
            return View(doanhNghiepVanTai);
        }

        // GET: DoanhNghiepVanTais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doanhNghiepVanTai = await _context.DoanhNghiepVanTais
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doanhNghiepVanTai == null)
            {
                return NotFound();
            }

            return View(doanhNghiepVanTai);
        }

        // POST: DoanhNghiepVanTais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doanhNghiepVanTai = await _context.DoanhNghiepVanTais.FindAsync(id);
            _context.DoanhNghiepVanTais.Remove(doanhNghiepVanTai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoanhNghiepVanTaiExists(int id)
        {
            return _context.DoanhNghiepVanTais.Any(e => e.ID == id);
        }
    }
}
