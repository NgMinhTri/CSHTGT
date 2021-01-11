using CSHTGT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.Service.IService
{
    public interface IPhuongTienService
    {
        Task<List<PhuongTienViewModel>> GetAll();
        Task<int> Create(PhuongTienViewModel model);
        //Task<int> Edit(PhuongTienViewModel model);
        Task<int> Delete(int ngtggiaothongid);
        
    }
}
