using CSHTGT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSHTGT.WebApp.Controllers
{
    public class BienBanViPhamController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<BienBanViPhamViewModel> listBienBan = new List<BienBanViPhamViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/bienbanvipham"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listBienBan = JsonConvert.DeserializeObject<List<BienBanViPhamViewModel>>(apiResponse);
                }
            }
            return View(listBienBan);
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
            var postTask = client.PostAsJsonAsync<BienBanViPhamViewModel>("api/bienbanvipham", bienBanViPhamViewModel);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["result"] = "Ghi bien ban thanh cong";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Ghi bien ban that bai");
            return View(bienBanViPhamViewModel);
        }

        public ActionResult DeleteBBVP(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var deleteTask = client.DeleteAsync("bienbanvipham/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["result"] = "Da xoa bien ban vi pham";
                    return RedirectToAction("Index");

                }
            }
            return RedirectToAction("Index");
        }
    }
}
