using CSHTGT.Data.Context;
using CSHTGT.Service.IService;
using CSHTGT.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CSHTGT.Service.Service
{
    public class LoaiPhuongTienService : ILoaiPhuongTienService
    {
        private readonly CSHTGTDbContext _context;

        public LoaiPhuongTienService(CSHTGTDbContext context)   
        {
            _context = context;
        }

        public async Task<List<LoaiPhuongTienViewModel>> GetAll()
        {
            var query = from p in _context.LoaiPhuongTiens select new { p };
            var data = await query.Select(x => new LoaiPhuongTienViewModel()
            {
                ID = x.p.ID,
                MoTa = x.p.MoTa,
                TenLoai = x.p.TenLoai
            }).ToListAsync();
            return data;
        }
        
    }
}
