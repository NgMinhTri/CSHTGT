using CSHTGT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.Service.IService
{
    public interface IPhuongTienService
    {
        Task<List<PhuongTienGetViewModel>> GetAll();
    
        Task<int> CreatePT(PhuongTienCreateViewModel model);
        Task<int> Edit(PhuongTienUpdateViewModel model);
        Task<int> Delete(int phuongtienid);
        Task<PhuongTienGetViewModel> getById(int id);
        

    }
}
