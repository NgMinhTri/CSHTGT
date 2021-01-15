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
        //đăng kí xe
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
        //thu hồi đăng kí xe
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
    }
}
