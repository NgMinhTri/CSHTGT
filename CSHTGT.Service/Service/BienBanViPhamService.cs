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
    public class BienBanViPhamService : IBienBanViPhamService
    {
        private readonly CSHTGTDbContext _context;
        private readonly ILoaiPhuongTienService _loaiPhuongTienService;
        public BienBanViPhamService(CSHTGTDbContext context)
        {
            _context = context;

        }

        public async Task<List<BienBanViPhamViewModel>> getAll()
        {
            var query = from n in _context.BienBanViPhams
                        select new { n } ;
            return await query.Select(x => new BienBanViPhamViewModel()
            {
                MaBienBan = x.n.MaBienBan,
                MaNgTGGiaoThong = x.n.MaNgTGGiaoThong,
                MaHinhThucXuPhat = x.n.MaHinhThucXuPhat,
                MaCanBo = x.n.MaCanBo,
                NgayViPham = x.n.NgayViPham,
                NgayLap = x.n.NgayLap,
                HanNopPhat = x.n.HanNopPhat,
                LoiViPham=x.n.LoiViPham,
                SoQuyetDinh=x.n.SoQuyetDinh,
                SoTienPhat=x.n.SoTienPhat,
                TinhTrangNopPhat=x.n.TinhTrangNopPhat


            }).ToListAsync();
        }

        public async Task<int> create(BienBanViPhamViewModel model)
        {
            var bBVP = new BienBanViPham()
            {
                MaNgTGGiaoThong = model.MaNgTGGiaoThong,
                MaHinhThucXuPhat = model.MaHinhThucXuPhat,
                MaCanBo = model.MaCanBo,
                NgayViPham = model.NgayViPham,
                NgayLap = model.NgayLap,
                HanNopPhat = model.HanNopPhat,
                LoiViPham = model.LoiViPham,
                SoQuyetDinh = model.SoQuyetDinh,
                SoTienPhat = model.SoTienPhat,
                TinhTrangNopPhat = model.TinhTrangNopPhat
            };
            _context.BienBanViPhams.Add(bBVP);
            await _context.SaveChangesAsync();
            return bBVP.MaBienBan;
        }

        public async Task<int> delete(int id)
        {
            var bBVP = await _context.BienBanViPhams.FindAsync(id);
            if (bBVP == null)
            {
                throw new Exception($"Không tìm thấy bien ban vi pham: {id}");
            }
            _context.BienBanViPhams.Remove(bBVP);
            return await _context.SaveChangesAsync();
        }

      
    }
}
