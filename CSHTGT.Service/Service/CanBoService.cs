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
    public class CanBoService : ICanBoService
    {
        private readonly CSHTGTDbContext _context;
        public CanBoService(CSHTGTDbContext context)
        {
            _context = context;
        }

        public async Task<List<CanBoViewModel>> GetAll()
        {
            var query = from c in _context.CanBos
                        select new { c };
            return await query.Select(x => new CanBoViewModel()
            {
                IDCanBo = x.c.IDCanBo,
                MaDonVi = x.c.MaDonVi,
                HoTen = x.c.HoTen,
                CMND = x.c.CMND,
                DiaChi = x.c.DiaChi,
                Email = x.c.Email,
                NgaySinh = x.c.NgaySinh,
                SDT = x.c.SDT        
            }).ToListAsync();
        }
        public async Task<int> Create(CanBoViewModel model)
        {
            var canbo = new CanBo()
            {
                MaDonVi = model.MaDonVi,
                HoTen = model.HoTen,
                CMND = model.CMND,
                DiaChi = model.DiaChi,
                Email = model.Email,
                NgaySinh = model.NgaySinh,
                SDT = model.SDT,
                UserName = model.UserName,
                Password = model.Password,                          
            };
            _context.CanBos.Add(canbo);
            await _context.SaveChangesAsync();
            return canbo.IDCanBo;
        }    
        public async Task<int> Delete(int canboid)
        {
            var canbo = await _context.CanBos.FindAsync(canboid);
            if (canbo == null)
            {
                throw new Exception($"Không có cán bộ này trong hệ thống");
            }
            _context.CanBos.Remove(canbo);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(CanBoViewModel model)
        {
            var canbo = await _context.CanBos.FindAsync(model.IDCanBo);
            var donvi = await _context.DonVis.FirstOrDefaultAsync(x => x.MaDonVi == model.MaDonVi);
            if (canbo == null || donvi == null) throw new Exception($"Lỗi không tồn tại cán bộ");
            canbo.HoTen = model.HoTen;
            canbo.CMND = model.CMND;
            canbo.DiaChi = model.DiaChi;
            canbo.Email = model.Email;
            canbo.NgaySinh = model.NgaySinh;
            canbo.SDT = model.SDT;
            canbo.UserName = model.UserName;
            canbo.Password = model.Password;
            canbo.MaDonVi = model.MaDonVi;
            return await _context.SaveChangesAsync();
        }
        public async Task<CanBoViewModel> getById(int id)
        {
            var query = from c in _context.CanBos
                        join d in _context.DonVis on c.MaDonVi equals d.MaDonVi
                        where c.IDCanBo == id
                        select new { c, d };
            return await query.Select(x => new CanBoViewModel()
            {
                IDCanBo = x.c.IDCanBo,
                HoTen = x.c.HoTen,
                CMND = x.c.CMND,
                DiaChi = x.c.DiaChi,
                Email = x.c.Email,
                NgaySinh = x.c.NgaySinh,
                SDT = x.c.SDT,
                UserName = x.c.UserName,
                Password = x.c.Password,
                MaDonVi = x.d.MaDonVi
            }).FirstOrDefaultAsync();
        }
    }
}
