using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSHTGT.WebApp.Controllers
{
    public class LoaiPhuongTienController : Controller
    {        
        public async Task<IActionResult> Index()
        {
            List<LoaiPhuongTienViewModel> listLoaiPhuongTien = new List<LoaiPhuongTienViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/LoaiPhuongTien"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listLoaiPhuongTien = JsonConvert.DeserializeObject<List<LoaiPhuongTienViewModel>>(apiResponse);
                }
            }
            return View(listLoaiPhuongTien);
        }
    }
}
