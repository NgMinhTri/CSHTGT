using CSHTGT.Data.Context;
using CSHTGT.Service.IService;
using CSHTGT.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSHTGT.Service.Service
{
    class GPLXService : IGPLXService
    {
        private readonly CSHTGTDbContext _context;

        public GPLXService(CSHTGTDbContext context)
        {
            _context = context;
        }

        public Task<int> Create(GPLXViewModel gplx)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Delete(int IDGPLX)
        {
            var gplx = await _context.GPLXes.FindAsync(IDGPLX);
            if (gplx == null)
            {
                throw new Exception($"Không tìm thấy hồ sơ đăng kí: {IDGPLX}");
            }
            _context.GPLXes.Remove(gplx);
            return await _context.SaveChangesAsync();
        }

        public Task<int> Edit(GPLXViewModel gplx)
        {
            throw new System.NotImplementedException();
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
    }
}
