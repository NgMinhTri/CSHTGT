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
        public PhuongTienService(CSHTGTDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhuongTienGetViewModel>> GetAll()
        {
            var query = from n in _context.NguoiThamGiaGiaoThongs
                        join p in _context.PhuongTiens on n.ID equals p.MaNgTGGiaoThong
                        select new { n, p };
            return await query.Select(x => new PhuongTienGetViewModel()
            {
                MaPT = x.p.MaPT,
                CMND = x.n.CMND,
                TenPT = x.p.TenPT,
                BienSo = x.p.BienSo,
                NhanHieu = x.p.NhanHieu,
                SoChoNgoi = x.p.SoChoNgoi,
                SoKhung = x.p.SoKhung,
                SoMay = x.p.SoMay,
                TaiTrong = x.p.TaiTrong,
                TrangThai = x.p.TrangThai,
                MaLoaiPhuongTien = x.p.MaLoaiPT

            }).ToListAsync();
        }
        public async Task<PhuongTienGetViewModel> getById(int id)
        {
            var query = from p in _context.PhuongTiens
                        join l in _context.LoaiPhuongTiens on p.MaLoaiPT equals l.ID
                        where p.MaPT == id
                        select new { p, l };
            return await query.Select(x => new PhuongTienGetViewModel()
            {
                MaPT = x.p.MaPT,
                TenPT = x.p.TenPT,
                BienSo = x.p.BienSo,
                SoKhung = x.p.SoKhung,
                NhanHieu = x.p.NhanHieu,
                SoMay = x.p.SoMay,
                SoChoNgoi = x.p.SoChoNgoi,
                TaiTrong = x.p.TaiTrong,
                TrangThai = x.p.TrangThai,
                MaLoaiPhuongTien = x.l.ID
                

            }).FirstOrDefaultAsync();
        }
        public async Task<int> CreatePT(PhuongTienCreateViewModel model)
        {
            var query = _context.NguoiThamGiaGiaoThongs
                                .Where(b => b.CMND == model.CMND).FirstOrDefaultAsync().Result;
            if (query == null)
            {
                throw new Exception($"Chứng minh nhân dân không tồn tại");
            }
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

        //xóa phương tiện
        public async Task<int> Delete(int phuongtienid)
        {
            var phuongtien = await _context.PhuongTiens.FindAsync(phuongtienid);
            if (phuongtien == null)
            {
                throw new Exception($"Không tìm thấy hồ sơ đăng kí: {phuongtienid}");
            }
            _context.PhuongTiens.Remove(phuongtien);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(PhuongTienUpdateViewModel model)
        {
            var phuongtien = await _context.PhuongTiens.FindAsync(model.MaPT);
            var loaiphuongtien = await _context.LoaiPhuongTiens.FirstOrDefaultAsync(x => x.ID == model.MaLoaiPhuongTien);           
            if (phuongtien == null || loaiphuongtien == null) throw new Exception($"Lỗi không tồn tại phương tiện");
            phuongtien.TenPT = model.TenPT;
            phuongtien.BienSo = model.BienSo;
            phuongtien.NhanHieu = model.NhanHieu;
            phuongtien.SoChoNgoi = model.SoChoNgoi;
            phuongtien.SoKhung = model.SoKhung;
            phuongtien.SoMay = model.SoMay;
            phuongtien.TaiTrong = model.TaiTrong;
            phuongtien.TrangThai = model.TrangThai;
            phuongtien.MaLoaiPT = model.MaLoaiPhuongTien;
            return await _context.SaveChangesAsync();
        }

        
    }
}
