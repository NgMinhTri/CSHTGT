using CSHTGT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.Service.IService
{
    public interface IGPLXService
    {
        Task<List<GPLXViewModel>> GetAll();
        Task<int> Create(GPLXViewModel model);
        Task<int> Edit(GPLXViewModel model);
        Task<int> Delete(int IDGPLX);
        Task<GPLXViewModel> GetByID(int IDGPLX);
    }
}
