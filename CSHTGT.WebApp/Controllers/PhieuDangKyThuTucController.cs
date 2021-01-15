using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.WebApp.Controllers
{
    public class PhieuDangKyThuTucController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<PhieuDangKyThuTucViewModel> listPhieuDangKy = new List<PhieuDangKyThuTucViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/PhieuDangKyThuTuc"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listPhieuDangKy = JsonConvert.DeserializeObject<List<PhieuDangKyThuTucViewModel>>(apiResponse);
                }
            }
            return View(listPhieuDangKy);
        }
    }
}
