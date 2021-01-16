using CSHTGT.Data.Context;
using CSHTGT.Data.Models;
using CSHTGT.Service.IService;
using CSHTGT.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSHTGT.Service.Service
{
    public class GPLXService : IGPLXService
    {
        private readonly CSHTGTDbContext _context;

        public GPLXService(CSHTGTDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(GPLXViewModel model)
        {
            var query = _context.NguoiThamGiaGiaoThongs
                                .Where(b => b.CMND == model.CMND).FirstOrDefaultAsync().Result;
            if (query == null)
                throw new Exception($"Không tồn tại người tham gia giao thông");
            var gplx = new GPLX()
            {
                MaNgTGGiaoThong = query.ID,
                MaDonVi = model.MaDonVi,
                Hang = model.Hang,
                NgayTao = model.NgayTao,
                NgayHetHan =model.NgayHetHan,
                SoGPLX = model.SoGPLX,
                TrangThai = model.TrangThai
            };
            _context.GPLXes.Add(gplx);
            await _context.SaveChangesAsync();
            return gplx.ID;
        }

        public async Task<int> Delete(int IDGPLX)
        {
            var gplx = await _context.GPLXes.FindAsync(IDGPLX);
            if (gplx == null)
            {
                throw new Exception($"Không tìm thấy GPLX: {IDGPLX}");
            }
            _context.GPLXes.Remove(gplx);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(GPLXViewModel model)
        {
            var gplx = await _context.GPLXes.FindAsync(model.ID);
            var ngtggiaothong = _context.NguoiThamGiaGiaoThongs.Where(x=> x.CMND == model.CMND).FirstOrDefaultAsync().Result;
            if (ngtggiaothong == null)
                throw new Exception($"Không tồn tại người tham gia giao thông");
            gplx.Hang = model.Hang;
            gplx.MaNgTGGiaoThong = ngtggiaothong.ID;
            gplx.MaDonVi = model.MaDonVi;
            gplx.SoGPLX = model.SoGPLX;
            gplx.NgayTao = model.NgayTao;
            gplx.NgayHetHan = model.NgayHetHan;
            gplx.TrangThai = model.TrangThai;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<GPLXViewModel>> GetAll()
        {
            var query = from g in _context.GPLXes
                        join n in _context.NguoiThamGiaGiaoThongs on g.MaNgTGGiaoThong equals n.ID
                        select new { g, n};
            return await query.Select(x => new GPLXViewModel()
            {
                ID = x.g.ID,
                HoTen = x.n.HoTen,
                DiaChi = x.n.DiaChi,
                CMND = x.n.CMND,
                Hang = x.g.Hang,
                NgayTao = x.g.NgayTao,
                NgayHetHan = x.g.NgayHetHan,
                SoGPLX = x.g.SoGPLX,
                TrangThai = x.g.TrangThai,
                MaDonVi = x.g.MaDonVi
            }).ToListAsync();
        }

        public async Task<GPLXViewModel> GetByID(int IDGPLX)
        {
            var query = from g in _context.GPLXes
                        join n in _context.NguoiThamGiaGiaoThongs on g.MaNgTGGiaoThong equals n.ID
                        where g.ID == IDGPLX
                        select new { g, n};
            return await query.Select(x => new GPLXViewModel()
            {
                ID = x.g.ID,
                HoTen = x.n.HoTen,
                DiaChi = x.n.DiaChi,
                CMND = x.n.CMND,
                Hang = x.g.Hang,
                NgayTao = x.g.NgayTao,
                NgayHetHan = x.g.NgayHetHan,
                SoGPLX = x.g.SoGPLX,
                TrangThai = x.g.TrangThai,
                MaDonVi = x.g.MaDonVi
            }).FirstOrDefaultAsync();
        }
    }
}
