﻿using CSHTGT.Data.Context;
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

        public async Task<List<PhuongTien_NTGGTViewModel>> GetAll()
        {
            var query = from n in _context.NguoiThamGiaGiaoThongs
                        join p in _context.PhuongTiens on n.ID equals p.MaNgTGGiaoThong                        
                        select new { n, p };
            return await query.Select(x => new PhuongTien_NTGGTViewModel()
            {               
                                
                UserName = x.n.UserName,
                MaPT = x.p.MaPT,
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
        public async Task<int> Create_NTGGT_PT(PhuongTien_NTGGTViewModel model)
        {
            
            var nguoithamgiagiaothong = new NguoiThamGiaGiaoThong()
            {               
                //HoTen = model.HoTen,                
                //CMND = model.CMND,
                //Email = model.Email,                
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
        public async Task<int> CreatePT(PhuongTienViewModel model)
        {
            
            var phuongtien = new PhuongTien()
            {
                TenPT = model.TenPT,
                BienSo = model.BienSo,
                NhanHieu = model.NhanHieu,
                SoChoNgoi = model.SoChoNgoi,
                SoKhung = model.SoKhung,
                SoMay = model.SoMay,
                TaiTrong = model.TaiTrong,
                MaLoaiPT = model.MaLoaiPhuongTien,
                MaNgTGGiaoThong = model.MaNTGGT
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

        //public async Task<int> Edit(PhuongTien_NTGGTViewModel model)
        //{
        //    var ngtggiaothong = await _context.NguoiThamGiaGiaoThongs.FindAsync(model.ID);
        //    var phuongtien = await _context.PhuongTiens.FirstOrDefaultAsync(x => x.MaNgTGGiaoThong == model.ID);
        //    if (ngtggiaothong == null || phuongtien == null)
        //        throw new Exception($"Không tồn tại chủ sở hữu phương tiện");
        //    ngtggiaothong.HoTen = model.HoTen;
        //    //ngtggiaothong.DiaChi = model.DiaChi;
        //    ngtggiaothong.CMND = model.CMND;
        //    ngtggiaothong.Email = model.Email;
        //   // ngtggiaothong.NgaySinh = model.NgaySinh;
        //   // ngtggiaothong.QueQuan = model.QueQuan;

        //    phuongtien.TenPT = model.TenPT;
        //    phuongtien.BienSo = model.BienSo;
        //    phuongtien.NhanHieu = model.NhanHieu;
        //    phuongtien.NhanHieu = model.NhanHieu;
        //    phuongtien.SoChoNgoi = model.SoChoNgoi;
        //    phuongtien.SoKhung = model.SoKhung;
        //    phuongtien.SoKhung = model.SoMay;
        //    return await _context.SaveChangesAsync();
        //}

        //public async Task<PhuongTienViewModel> GetById(int id)
        //{
        //    var query = from n in _context.NguoiThamGiaGiaoThongs
        //                join p in _context.PhuongTiens on n.ID equals p.MaNgTGGiaoThong
        //                where n.ID == id
        //                select new { n, p };

        //    return  query.Select(x => new PhuongTienViewModel()
        //    {
        //        ID = x.n.ID,
        //        HoTen = x.n.HoTen,
        //        DiaChi = x.n.DiaChi,
        //        CMND = x.n.CMND,
        //        Email = x.n.Email,
        //        NgaySinh = x.n.NgaySinh,
        //        QueQuan = x.n.QueQuan,
        //        SDT = x.n.SDT,
        //        PassWord = x.n.PassWord,
        //        UserName = x.n.UserName,

        //        MaPT = x.p.MaPT,
        //        TenPT = x.p.TenPT,
        //        BienSo = x.p.BienSo,
        //        NhanHieu = x.p.NhanHieu,
        //        SoChoNgoi = x.p.SoChoNgoi,
        //        SoKhung = x.p.SoKhung,
        //        SoMay = x.p.SoMay,
        //        MaLoaiPhuongTien = x.p.MaLoaiPT
        //    }).FirstOrDefault();
        //}
        //public async Task<PhuongTien_NTGGTViewModel> GetNgTGGTByUserName(string username)
        //{
        //    var query = from p in _context.NguoiThamGiaGiaoThongs
        //                where p.UserName == username
        //                select new { p };
        //    return await query.Select(x => new PhuongTien_NTGGTViewModel()
        //    {
        //        HoTen = x.p.HoTen,
        //        DiaChi = x.p.DiaChi,
        //        CMND = x.p.CMND,
        //        NgaySinh = x.p.NgaySinh,
        //        UserName = x.p.UserName
        //    }).FirstOrDefaultAsync();

        //}

      
    }
}
