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
    public class BienBanViPhamController : Controller
    {

        public async Task<IActionResult> Index()
        {
            List<BienBanViPhamViewModel> listPhuongTien = new List<BienBanViPhamViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/BienBanViPham"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listPhuongTien = JsonConvert.DeserializeObject<List<BienBanViPhamViewModel>>(apiResponse);
                }
            }
            return View(listPhuongTien);
        }

        public IActionResult AddBBVP()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBBVP(BienBanViPhamViewModel bienBanViPhamViewModel)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            var postTask = client.PostAsJsonAsync<BienBanViPhamViewModel>("api/bienban", bienBanViPhamViewModel);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["result"] = "Tạo biên bản thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Tạo biên bản thất bại");
            return View(bienBanViPhamViewModel);
        }

        public ActionResult DeletePT(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var deleteTask = client.DeleteAsync("PhuongTien/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["result"] = "Đã xóa hồ sơ đăng kí";
                    return RedirectToAction("Index");

                }
            }
            return RedirectToAction("Index");
        }
    }
}
