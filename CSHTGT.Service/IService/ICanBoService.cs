using CSHTGT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.Service.IService
{
    public interface ICanBoService
    {
        Task<List<CanBoViewModel>> GetAll();
        Task<int> Create(CanBoViewModel model);
        Task<int> Edit(CanBoViewModel model);
        Task<int> Delete(int canboid);
        Task<CanBoViewModel> getById(int id);

    }
}
