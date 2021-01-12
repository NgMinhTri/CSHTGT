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
        Task<int> Create(GPLXViewModel gplx);
        Task<int> Edit(GPLXViewModel gplx);
        Task<int> Delete(int IDGPLX);
        
    }
}
