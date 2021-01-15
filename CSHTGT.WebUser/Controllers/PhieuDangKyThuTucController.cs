using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.WebUser.Controllers
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

        public IActionResult AddPhieuDangKyThuTuc()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPhieuDangKyThuTUc(PhieuDangKyThuTucViewModel phieuDangKyThuTucViewModel)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            var postTask = client.PostAsJsonAsync<PhieuDangKyThuTucViewModel>("api/phieudangkythutuc", phieuDangKyThuTucViewModel);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["result"] = "Đăng kí lịch hẹn thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Đăng kí lịch hẹn thất bại");
            return View(phieuDangKyThuTucViewModel);
        }
    }
}
