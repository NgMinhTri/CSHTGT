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
    public class PhuongTienService : IPhuongTienService
    {
        private readonly CSHTGTDbContext _context;
        private readonly ILoaiPhuongTienService _loaiPhuongTienService;
        public PhuongTienService(CSHTGTDbContext context,
            ILoaiPhuongTienService loaiPhuongTienService)
        {
            _context = context;
            _loaiPhuongTienService = loaiPhuongTienService;

        }

        public async Task<List<PhuongTienViewModel>> GetAll()
        {
            var query = from n in _context.NguoiThamGiaGiaoThongs
                        join p in _context.PhuongTiens on n.ID equals p.MaNgTGGiaoThong                        
                        select new { n, p };
            return await query.Select(x => new PhuongTienViewModel()
            {                              
                MaPT = x.p.MaPT,
                TenPT = x.p.TenPT,
                BienSo = x.p.BienSo,
                NhanHieu = x.p.NhanHieu,
                SoChoNgoi = x.p.SoChoNgoi,
                SoKhung = x.p.SoKhung,
                SoMay = x.p.SoMay,
                UserName = x.n.UserName,
                MaLoaiPhuongTien = x.p.MaLoaiPT
            }).ToListAsync();
        }
        //đăng kí xe
        public async Task<int> CreatePT(PhuongTienViewModel model)
        {
            var query = _context.NguoiThamGiaGiaoThongs.Where(x => x.CMND == model.CMND).FirstOrDefaultAsync().Result;               
            var phuongtien = new PhuongTien()
            {
                TenPT = model.TenPT,
                BienSo = model.BienSo,
                NhanHieu = model.NhanHieu,
                SoChoNgoi = model.SoChoNgoi,
                SoKhung = model.SoKhung,
                SoMay = model.SoMay,
                TaiTrong = model.TaiTrong,
                TrangThai = model.TrangThai,
                MaLoaiPT = model.MaLoaiPhuongTien,
                MaNgTGGiaoThong = query.ID
            };
            _context.PhuongTiens.Add(phuongtien);
            await _context.SaveChangesAsync();
            return phuongtien.MaPT;
        }
        //thu hồi đăng kí xe
        public async Task<int> Delete(int phuongtienid)
        {
            var phuongtien = await _context.PhuongTiens.FindAsync(phuongtienid);
            if(phuongtien == null)
            {
                throw new Exception($"Không tìm thấy hồ sơ đăng kí: {phuongtienid}");
            }
            _context.PhuongTiens.Remove(phuongtien);
            return await _context.SaveChangesAsync();
        }
    }
}
