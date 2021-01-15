using CSHTGT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CSHTGT.Service.IService
{
    public interface IDonViService
    {
        Task<List<DonViViewModels>> GetAll();
    }


}
