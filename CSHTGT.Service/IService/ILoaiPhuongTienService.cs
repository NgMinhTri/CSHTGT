using CSHTGT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.Service.IService
{
    public interface ILoaiPhuongTienService
    {
        Task<List<LoaiPhuongTienViewModel>> GetAll();
    }
}
