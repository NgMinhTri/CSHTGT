using CSHTGT.Data.Context;
using CSHTGT.Service.IService;
using CSHTGT.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CSHTGT.Service.Service
{
    public class DonViService : IDonViService
    {
        private readonly CSHTGTDbContext _context;

        public DonViService(CSHTGTDbContext context)
        {
            _context = context;
        }

        public async Task<List<DonViViewModels>> GetAll()
        {
            var query = from d in _context.DonVis select new { d };
            var data = await query.Select(x => new DonViViewModels()
            {
                TenDonVi = x.d.TenDonVi,
                NhiemVu = x.d.NhiemVu,
                DiaDiem = x.d.DiaDiem
            }).ToListAsync();
            return data;
        }
    }
}
