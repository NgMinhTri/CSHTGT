using CSHTGT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.Service.IService
{
    public interface IPhieuDangKyThuTucService
    {
        Task<List<PhieuDangKyThuTucViewModel>> GetAll();
        Task<int> CreatePDK(PhieuDangKyThuTucViewModel model);
        Task<int> Edit(PhieuDangKyThuTucViewModel model);
    }
}
