using CSHTGT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.Service.IService
{
    public interface IBienBanViPhamService
    {
        Task<List<BienBanViPhamViewModel>> getAll();
        Task<int> create(BienBanViPhamViewModel model);
        Task<int> delete(int id);


    }
}
