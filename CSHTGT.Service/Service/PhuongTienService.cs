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
                ID = x.n.ID,
                HoTen = x.n.HoTen,
                DiaChi = x.n.DiaChi,
                CMND = x.n.CMND,
                Email = x.n.Email,
                NgaySinh = x.n.NgaySinh,
                QueQuan = x.n.QueQuan,
                SDT = x.n.SDT,
                PassWord = x.n.PassWord,
                UserName = x.n.UserName,

                TenPT = x.p.TenPT,
                BienSo = x.p.BienSo,
                NhanHieu = x.p.NhanHieu,
                SoChoNgoi = x.p.SoChoNgoi,
                SoKhung = x.p.SoKhung,
                SoMay = x.p.SoMay,
                MaLoaiPhuongTien = x.p.MaLoaiPT

            }).ToListAsync();
        }
        //đăng kí xe
        public async Task<int> Create(PhuongTienViewModel model)
        {
            var nguoithamgiagiaothong = new NguoiThamGiaGiaoThong()
            {
               
                HoTen = model.HoTen,
                DiaChi = model.DiaChi,
                CMND = model.CMND,
                Email = model.Email,
                NgaySinh = model.NgaySinh,
                QueQuan = model.QueQuan,
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
                    }
                }
            };
            _context.NguoiThamGiaGiaoThongs.Add(nguoithamgiagiaothong);
            await _context.SaveChangesAsync();
            return nguoithamgiagiaothong.ID;
        } 
        //thu hồi đăng kí xe
        public async Task<int> Delete(int ngtggiaothongid)
        {
            var ngtggiaothong = await _context.NguoiThamGiaGiaoThongs.FindAsync(ngtggiaothongid);
            if(ngtggiaothong == null)
            {
                throw new Exception($"Không tìm thấy hồ sơ đăng kí: {ngtggiaothongid}");
            }
            _context.NguoiThamGiaGiaoThongs.Remove(ngtggiaothong);
            return await _context.SaveChangesAsync();
        }
    }
}
