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
    public class GPLXController:Controller
    {
        public async Task<IActionResult> Index()
        {
            List<GPLXViewModel> listGPLX = new List<GPLXViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/GPLX"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listGPLX = JsonConvert.DeserializeObject<List<GPLXViewModel>>(apiResponse);
                }
            }
            return View(listGPLX);
        }

        public IActionResult AddGPLX()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGPLX(GPLXViewModel gplxViewModel)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            var postTask = client.PostAsJsonAsync<GPLXViewModel>("api/GPLX", gplxViewModel);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["result"] = "Đăng kí GPLX thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Đăng kí GPLX thất bại");
            return View(gplxViewModel);
        }

        public ActionResult DeleteGPLX(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var deleteTask = client.DeleteAsync("GPLX/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["result"] = "Đã xóa GPLX";
                    return RedirectToAction("Index");

                }
            }
            return RedirectToAction("Index");
        }
    }
}
