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

        
        public async Task<IActionResult> AddGPLX()
        {
            List<DonViViewModels> listDonVi = new List<DonViViewModels>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/DonVi"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listDonVi = JsonConvert.DeserializeObject<List<DonViViewModels>>(apiResponse);
                }
            }
            ViewData["MaDonVi"] = new SelectList(listDonVi, "MaDonVi", "TenDonVi");
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
        public async Task<IActionResult> EditGPLX()
        {
            List<DonViViewModels> listDonVi = new List<DonViViewModels>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/DonVi"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listDonVi = JsonConvert.DeserializeObject<List<DonViViewModels>>(apiResponse);
                }
            }
            ViewData["MaDonVi"] = new SelectList(listDonVi, "MaDonVi", "TenDonVi");
            return View();
        }
        [HttpPut]
        public IActionResult EditGPLX(int id)
        {
            GPLXViewModel gplx = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = client.GetAsync("GPLX?ID=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<GPLXViewModel>();
                    readTask.Wait();

                    gplx = readTask.Result;
                }
            }      
            return View(gplx);
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
