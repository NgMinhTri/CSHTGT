using CSHTGT.Data.Context;
using CSHTGT.Data.Models;
using CSHTGT.Service.IService;
using CSHTGT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.Service.Service
{
    public class PhuongTienService : IPhuongTienService
    {
        private readonly CSHTGTDbContext _context;
        public PhuongTienService(CSHTGTDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(PhuongTienViewModel model)
        {
            var nguoithamgiagiaothong = new NguoiThamGiaGiaoThong()
            {
                HoTen = model.HoTen,
                DiaChi = model.DiaChi,
                CMND = model.CMND,
                Email = model.Email,
                NgaySinh = model.NgaySinh,
                SDT = model.SDT,
                PassWord = model.PassWord,
                UserName = model.UserName,  
                
                PhuongTiens = new List<PhuongTien>()
                {
                    new PhuongTien()
                    {
                        TenPT =  model.TenPT,
                        BienSo = model.BienSo,
                        NhanHieu = model.NhanHieu,
                        SoChoNgoi = model.SoChoNgoi,
                        SoKhung = model.SoKhung,
                        SoMay = model.SoMay,
                        MaLoaiPT = model.MaLoaiPhuongTien,
                        MaCanBo = model.MaCanBo                      
                    }
                }
            };
            _context.NguoiThamGiaGiaoThongs.Add(nguoithamgiagiaothong);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
