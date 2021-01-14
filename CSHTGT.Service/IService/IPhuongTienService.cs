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
        //Task<PhuongTienViewModel> GetById(int id);
        //Task<int> Create_NTGGT_PT(PhuongTien_NTGGTViewModel model);
       Task<int> CreatePT(PhuongTienCreateViewModel model);
       // Task<int> Edit(PhuongTien_NTGGTViewModel model);
       Task<int> Delete(int phuongtienid);
       // Task<PhuongTien_NTGGTViewModel> GetNgTGGTByUserName(string username);
      

    }
}
