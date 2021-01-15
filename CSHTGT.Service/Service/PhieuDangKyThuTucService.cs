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
    public class PhieuDangKyThuTucService : IPhieuDangKyThuTucService
    {
        private readonly CSHTGTDbContext _context;
        public PhieuDangKyThuTucService(CSHTGTDbContext context)
        {
            _context = context;

        }
        public async Task<List<PhieuDangKyThuTucViewModel>> GetAll()
        {
            var query = from p in _context.PhieuDangKyThuTucs select new { p };
            return await query.Select(x => new PhieuDangKyThuTucViewModel()
            {
                MaPhieu = x.p.MaPhieu,
                TenPT = x.p.TenPT,
                BienSo = x.p.BienSo,
                NhanHieu = x.p.NhanHieu,
                SoChoNgoi = x.p.SoChoNgoi,
                SoKhung = x.p.SoKhung,
                SoMay = x.p.SoMay,
                LoaiDangKy = x.p.LoaiDangKy,
                XetDuyet = x.p.XetDuyet,
                NgayDangKy = x.p.NgayDangKy,
                CMNDNgLienQuan = x.p.CMNDNgLienQuan
            }).ToListAsync();
        }
        //đăng kí xe
        public async Task<int> CreatePDK(PhieuDangKyThuTucViewModel model)
        {
            var phieu = new PhieuDangKyThuTuc()
            {
                TenPT = model.TenPT,
                BienSo = model.BienSo,
                NhanHieu = model.NhanHieu,
                SoChoNgoi = model.SoChoNgoi,
                SoKhung = model.SoKhung,
                SoMay = model.SoMay,
                LoaiDangKy = model.LoaiDangKy,
                NgayDangKy = model.NgayDangKy,
                CMNDNgLienQuan = model.CMNDNgLienQuan,
                XetDuyet = 0,
            };
            _context.PhieuDangKyThuTucs.Add(phieu);
            await _context.SaveChangesAsync();
            return phieu.MaPhieu;
        }

        Task<int> IPhieuDangKyThuTucService.Edit(PhieuDangKyThuTucViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
